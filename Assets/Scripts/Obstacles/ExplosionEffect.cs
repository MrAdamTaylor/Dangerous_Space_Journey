using System;
using System.Collections;
using System.Collections.Generic;
using AbstractFactory;
using Infrastructure;
using Services.AssertService;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AsteroidHealth))]
public class ExplosionEffect : MonoBehaviour
{
    [SerializeField] private string path;
    private bool isExplosion;
    private ISpawnerFactory _explosionFactory;
    //private IAsserts _asserts;
    private Vector3 _explosionPosition;

    private void Start()
    {
        _explosionFactory = Game.Factory;
    }
    

    private void OnEnable()
    {
        isExplosion = true;
    }

    public void ExplosionEffectCreate()
    {
        _explosionPosition = transform.position;
        _explosionFactory.SpawnSpecialEffect(path,_explosionPosition);
    }
}
