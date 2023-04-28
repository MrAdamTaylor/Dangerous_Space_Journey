using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowRot : MonoBehaviour
{
    public Transform target;
    public float turnSpeed = .01f;
    private Quaternion rotGoal;
    private Vector3 direction;

    private Rigidbody _rigidbody;
    private Vector3 m_EulerAngleVelocity;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        m_EulerAngleVelocity = new Vector3(0, 100, 0);
    }

    private void Update()
    {
        //Method1();
        Method2();
    }

    private void Method2()
    {
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
        _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotation);
    }

    private void Method1()
    {
        direction = (target.position - transform.position).normalized;
        rotGoal = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotGoal, turnSpeed);
    }
}
