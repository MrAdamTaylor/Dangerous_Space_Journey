using System;
using System.Collections;
using System.Collections.Generic;
using Enemy.FSM.States;
using UnityEngine;

public class MovementSM : StateMachine
{
    [HideInInspector] public IdleState _idleState;
    [HideInInspector] public MoveState _movingState;

     public Rigidbody _rigidbody;
    [SerializeField] public float _speed;

    private void Awake()
    {
        _idleState = new IdleState(this);
        _movingState = new MoveState(this);
    }

    protected override BaseState GetInitialState()
    {
        return _idleState;
    }
}
