using System;
using System.Collections;
using System.Collections.Generic;
using AbstractFactory;
using Infrastructure;
using UnityEngine;


public class SmokeCreater : SpecialEffectCreater
{
    [SerializeField] private string path = "Prefabs/Smoke";
    private bool isExplosion;
    private ISpawnerFactory _smokeFactory;
    private Vector3 _explosionPosition;

    private void Awake()
    {
        _smokeFactory = Game.Factory;
    }

    private void OnEnable()
    {
        isExplosion = true;
    }

    public override void EffectCreate()
    {
        _explosionPosition = transform.position;
        GameObject _smokeOfPart = _smokeFactory.SpawnSpecialEffect(path,_explosionPosition);
        _smokeOfPart.transform.parent = gameObject.transform;
    }
}
