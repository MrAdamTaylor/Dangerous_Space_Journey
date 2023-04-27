using System;
using System.Collections;
using System.Collections.Generic;
using Enemy.FSM.FSM_Test.Action;
using UnityEngine;

public class FollowToPlayer : SomeAction
{
    //TODO это нужно вынести в ScriptableObject
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speed;

    private Rigidbody _enemyRigidbody;
    private Vector3 _direction;

    void Start()
    {
        _enemyRigidbody = transform.GetComponent<Rigidbody>();
    }


    public override void Execute()
    {
        _direction = (_player.transform.position - transform.position).normalized;
        _enemyRigidbody.MovePosition(_enemyRigidbody.position + _direction * _speed * Time.fixedDeltaTime);
    }
}
