using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateUFO : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float turnSpeed = 0.01f;
    private Quaternion _myQuaternion;
    private Quaternion _rootGoal;
    private Vector3 _direction;

    
    
    private void Update()
    {
        _myQuaternion = this.transform.rotation;
        _direction = (target.position - transform.position).normalized;
        _rootGoal = Quaternion.LookRotation(_direction);
        transform.rotation = Quaternion.Slerp(_myQuaternion, _rootGoal, turnSpeed);
    }
}
