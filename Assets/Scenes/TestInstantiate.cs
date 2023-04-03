using System;
using System.Collections;
using System.Collections.Generic;
using AbstractFactory;
using UnityEngine;

public class TestInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject _asteroid;
    public bool flag = false;

    private ISpawnerFactory _factory;
    
    
    private void OnEnable()
    {
        flag = true;
    }

    private void Update()
    {
        if (flag == true)
        {
            Instantiate(_asteroid, transform.position, Quaternion.identity);
            this.enabled = false;
        }

    }

    
}
