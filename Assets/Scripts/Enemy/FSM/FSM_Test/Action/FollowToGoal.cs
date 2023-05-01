using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Enemy.FSM.FSM_Test.Action;
using Unity.Rendering.HybridV2;
using UnityEngine;

public class FollowToGoal : SomeAction
{
    //TODO это нужно вынести в ScriptableObject
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _enemyRigidbody;
    private Vector3 _direction;
    
    private RotateTo _rotateTo;
    private ShootToGoal _shootToGoal;
    private StateOnDistance _stateOnDistance;


    #region Булевые переменные

    private bool isRotate;
    private bool isShoot;
    private bool isState;
    

    #endregion
    
    private void Awake()
    {
        CheckRotateSystem();
        CheckShootSystem();
        CheckStateSystem();
    }

    private void CheckStateSystem()
    {
        if (gameObject.GetComponent<StateOnDistance>() != null)
        {
            _stateOnDistance = GetComponent<StateOnDistance>();
            isState = true;
        }
        else
        {
            isState = false;
        }
    }

    private void CheckRotateSystem()
    {
        if (gameObject.GetComponent<RotateTo>() != null)
        {
            _rotateTo = GetComponent<RotateTo>();
            isRotate = true;
        }
        else
        {
            isRotate = false;
        }
    }

    private void CheckShootSystem()
    {
        if (gameObject.GetComponent<ShootToGoal>() != null)
        {
            _shootToGoal = GetComponent<ShootToGoal>();
            isShoot = true;
        }
        else
        {
            isShoot = false;
        }
    }

    public override void Execute()
    {
        if (isState)
        {
            if (_stateOnDistance.CheckDistance(transform,_player.transform))
            {
                OtherActions();
                //MoveToGoal();
            }
            else
            {
                MoveToGoal();
                OtherActions();
            }
            
        }
        else
        {
            MoveToGoal();
            OtherActions();
        }

        //MoveToGoal();
        //OtherActions();
    }

    private void OtherActions()
    {
        /*if (isRotate)
        {
            _rotateTo.RotateToObject();
        }*/
        if (isShoot)
        {
            _shootToGoal.Shoot();
        }
    }

    private void MoveToGoal()
    {
        _direction = (_player.transform.position - transform.position).normalized;
        _enemyRigidbody.MovePosition(_enemyRigidbody.position + _direction * _speed * Time.deltaTime);
    }

    public override void ExecuteCoroutine()
    {
        if (isRotate)
        {
            //Debug.Log("Поворот: ");
            _rotateTo.RotateToObject();
        }
    }
}
