using System;
using System.Collections;
using System.Collections.Generic;
using AbstractFactory;
using Services.AssertService;
using UnityEngine;

public class FactorySpawner : MonoBehaviour
{
    /*private IAsserts _asserts;
    private ISpawnerFactory _factory;
    private const string _myObject = "Obstacles/Asteroids/Prefabs/Missile";

    private void Awake()
    {
        _asserts = new Asserts();
    }

    private void Start()
    {
        SetModeLocal();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetModeLocal();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetModeNetwork();
        }

        /*if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _factory.SpawnUnit();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _factory.spawnInteractableObject();
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            _factory.SpawnPlayer();
        }#1#

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            _factory.SpawnSpecialEffect(_myObject);
        }
    }
    
    private void SetModeLocal()
    {
        _factory = new LocalSpawnerFactory(_asserts);
        
        Debug.Log("Local mode enabled");
    }

    private void SetModeNetwork()
    {
        _factory = new NetworkSpawnerFactory();
        
        Debug.Log("Network mode enabled");
    }*/
}
