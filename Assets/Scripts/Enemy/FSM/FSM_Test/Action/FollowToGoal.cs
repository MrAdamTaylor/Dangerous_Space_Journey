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
    [SerializeField] private float _angleSpeed;
    [SerializeField] private float _angleTarget;
    private Vector3 _direction;
    
    private Vector3 Ray1;
    private Vector3 Ray2;
    private float _dot;
    private float _angle;
    private float _angleDegrees;
    private Vector3 _crossVector;
    private int _clockwise;

    void Start()
    {
        _enemyRigidbody = transform.GetComponent<Rigidbody>();
    }


    public override void Execute()
    {
        _direction = (_player.transform.position - transform.position).normalized;
        _enemyRigidbody.MovePosition(_enemyRigidbody.position + _direction * _speed * Time.fixedDeltaTime);

        RotateTo();
    }

    private void RotateTo()
    {
        
        
        CalculateDirection(gameObject, _player);
        _dot = MathModule.DotProductXY(Ray1, Ray2);
        _angle = MathModule.AngleBetween(_dot, Ray1, Ray2);
        _angleDegrees = MathModule.TranslateAngleInDegrees(_angle);
        _crossVector = MathModule.CrossProduct(Ray1, Ray2);
        _clockwise = MathModule.GetClockWise(_crossVector);
        Debug.Log($"Направление угла: {_clockwise}");
        float newAngle = transform.eulerAngles.z + (_clockwise * _angleDegrees);
        if (newAngle < 0)
        {
            newAngle = Mathf.Abs(newAngle) + 180;
        }

        float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, transform.eulerAngles.z + (_clockwise * _angleDegrees),
            newAngle);
        transform.eulerAngles = new Vector3(0, 0, angle);
        
    }

    private void CalculateDirection(GameObject obj1, GameObject obj2)
    {
        Vector3 selfForward = -obj1.transform.up;
        Vector3 targedDirection = obj2.transform.position - transform.position;
        Debug.Log($"(this.name{this.name}): Obj1 position: {transform.position}, " +
                  $"Obj1 vectorForward: {selfForward}, " +
                  $"Obj2: {_player.transform.position} " +
                  $"Direction between: {targedDirection}");
        Debug.DrawRay(transform.position, selfForward * 35, Color.green, 2);
        Debug.DrawRay(transform.position, targedDirection, Color.red, 2);

        Ray1 = selfForward;
        Ray2 = targedDirection;
    }
}
