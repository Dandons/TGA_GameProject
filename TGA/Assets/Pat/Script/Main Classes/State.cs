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

    public enum States { Idle, Patroll, Chase, Attack, Block, Stun, Dead, Roll, InCombat }
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
        Debug.Log(states.ToString());
        Debug.Log(events.ToString());
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
            nextState = new InCombat(enemy, player);
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
            nextState = new InCombat(enemy, player);
            events = Events.Exit;
        }
    }
    public override void Exit()
    {
        enemy.agent.SetDestination(enemy.transform.position);
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
        base.Enter();
    }
    public override void Update()
    {
        enemy.Attack();
        nextState = new Stun(enemy, player);
    }
    public override void Exit()
    {
        base.Exit();
    }
}

public class Block : State
{
    public Block(Enemy _enemy, GameObject _player) : base(_enemy, _player)
    {
        states = States.Block;
    }
}
public class Stun : State
{
    public Stun(Enemy _enemy, GameObject _player) : base(_enemy, _player)
    {
        states = States.Stun;
    }
    public override void Enter()
    {
        enemy.SetAnim("stun");
        base.Enter();
    }
    public override void Update()
    {
        enemy.StartCoroutine("stun");
        base.Update();
    }
    public override void Exit()
    {
        enemy.ResetAnim("stun");
        base.Exit();
    }
    public IEnumerator stun(float Stuntime)
    {
        yield return new WaitForSeconds(1);
        nextState = new InCombat(enemy, player);
        events = Events.Exit;
    }
}
public class Dead : State
{
    public Dead(Enemy _enemy, GameObject _player) : base(_enemy, _player)
    {
        states = States.Dead;
    }
    public override void Enter()
    {
        enemy.SetAnim("dead");
        base.Enter();
    }
    public override void Exit()
    {
    }
}
public class InCombat : State
{
    public InCombat(Enemy _enemy, GameObject _player) : base(_enemy, _player)
    {
        states = States.InCombat;
    }
    public override void Enter()
    {
        enemy.SetAnim("inCombat");
        base.Enter();
    }
    public override void Update()
    {
        if ((enemy.transform.position - player.transform.position).magnitude <= enemy.attackRange)
        {
            nextState = new Attack(enemy, player);
            events = Events.Exit;
        }
        else if (!enemy.DetectPlayer())
        {
            nextState = new Idle(enemy,player);
            events = Events.Exit;
        }
        else
        {
            nextState = new Chase(enemy, player);
            events = Events.Exit;
        }
    }
    public override void Exit()
    {
        enemy.ResetAnim("inCombat");
        base.Exit();
    }
}








