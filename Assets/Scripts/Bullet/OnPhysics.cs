using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPhysics : MonoBehaviour
{
    [SerializeField] private float _timeDelay;

    private Collider _collider;
    private float _startTime;

    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        _startTime = Time.time;
    }

    private void Update()
    {
        _collider = GetComponent<Collider>();
        if (Time.time > (_startTime + _timeDelay))
        {
            _collider.enabled = true;
        }
    }

    private void OnDisable()
    {
        _collider.enabled = false;
    }
}
