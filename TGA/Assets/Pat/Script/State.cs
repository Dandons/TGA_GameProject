using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State
{
    public Enemy enemy;
    public GameObject player;
    public Animator anim;

    public enum States { Idle, Patroll, Chase, Attack, block, Stun, Dead, Roll }
    public enum Events { Enter, Update, Exit }
    public States states;
    protected Events events;
    protected State nextState;
    public State(Enemy _enemy, GameObject _player)
    {
        enemy = _enemy;
        player = _player;
    }
    public virtual void Enter() { events = Events.Update; }
    public virtual void Update() { }
    public virtual void Exit() { events = Events.Exit; }
    public State Process()
    {
        if (events == Events.Enter) Enter();
        if (events == Events.Update) Update();
        if (events == Events.Exit)
        {
            Exit();
            return nextState;
        }
        return this;
    }
}

public class Idle : State
{
    public Idle(Enemy _enemy, GameObject _player) : base(_enemy, _player)
    {
        states = States.Idle;
    }
    public override void Enter()
    {
        enemy.SetAnim("idle");
        base.Enter();
    }
    public override void Update()
    {
        //If player in detection range
        if (enemy.DetectPlayer())
        {
            nextState = new Chase(enemy, player);
            events = Events.Exit;
        }
        //10% chance for going patrol
    }
    public override void Exit()
    {
        enemy.ResetAnim("idle");
        base.Exit();
    }
}

public class Chase : State
{
    public Chase(Enemy _enemy, GameObject _player) : base(_enemy, _player)
    {
        states = States.Chase;
    }
    public override void Enter()
    {
        enemy.SetAnim("chase");
        base.Enter();
    }
    public override void Update()
    {
        enemy.agent.SetDestination(player.transform.position);
        //Player in atk range
        if ((enemy.transform.position - player.transform.position).magnitude <= enemy.attackRange)
        {
            nextState = new Attack(enemy,player);
            events = Events.Exit;
        }
    }
    public override void Exit()
    {
        enemy.ResetAnim("chase");
        base.Exit();
    }
}
public class Attack : State
{
    public Attack(Enemy _enemy, GameObject _player) : base(_enemy, _player)
    {
        states = States.Attack;
    }
    public override void Enter()
    {
        states = States.Attack;
        base.Enter();
    }
    public override void Update(){}
}
