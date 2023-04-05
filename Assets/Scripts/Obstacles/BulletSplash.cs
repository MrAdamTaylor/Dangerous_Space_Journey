using System;
using System.Collections;
using System.Collections.Generic;
using AbstractFactory;
using Infrastructure;
using Services.Input;
using UnityEngine;

public class BulletSplash : SpecialEffectCreater
{
    [SerializeField] private string path;
    private ISpawnerFactory _bulletFactory;

    public void Start()
    {
        _bulletFactory = Game.Factory;
    }
    

    private void OnParticleCollision(GameObject other)
    {
        if (this.gameObject != null)
        {
            EffectCreate();
        }
    }

    public override void EffectCreate()
    {
        _bulletFactory.SpawnSpecialEffect(path, transform.position);
    }
}
