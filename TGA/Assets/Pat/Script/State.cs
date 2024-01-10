using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State
{
    protected Enemy enemy;
    public enum States { Idle, Patroll, Chase, Attack, block, Stun, Dead, Roll }
    public enum Events { Enter, Update, Exit }
    public States states;
    protected Events events;
    protected State nextState;
    public State(Enemy _enemy)
    {
        enemy = _enemy;
    }
    protected virtual void Enter() { events = Events.Update; }
    protected virtual void Update() { }
    protected virtual void Exit() { events = Events.Exit; }
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
    public Idle(Enemy _enemy) : base(_enemy)
    {
        states = States.Idle
    }

}
