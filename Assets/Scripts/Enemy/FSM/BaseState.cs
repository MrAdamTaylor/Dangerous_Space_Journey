using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState
{
    //TODO это возможно в будущем придёться убрать, так как нужно лишь для вывода на экран
    public string _name;
    protected StateMachine _stateMachine;
    
    
    public BaseState(string name, StateMachine stateMachine)
    {
        this._name = name;
        this._stateMachine = stateMachine;
    }

    public virtual void Enter()
    {
    }

    public virtual void UpdateLogic()
    {
    }

    public virtual void UpdatePhysics()
    {
    }

    public virtual void Exit()
    {
    }
}
