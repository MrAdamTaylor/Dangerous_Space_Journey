using System;
using System.Collections;
using System.Collections.Generic;
using AbstractFactory;
using Infrastructure;
using Services.AssertService;
using UnityEngine;
using UnityEngine.UI;

public class ExplosionEffect : SpecialEffectCreater
{
    [SerializeField] private string path;
    private bool isExplosion;
    private ISpawnerFactory _explosionFactory;
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
        EffectCreate();
    }

    public override void EffectCreate()
    {
        _explosionPosition = transform.position;
        _explosionFactory.SpawnSpecialEffect(path,_explosionPosition);
    }
}
