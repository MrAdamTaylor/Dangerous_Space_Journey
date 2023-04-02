using System;
using System.Collections;
using System.Collections.Generic;
using Infrastructure;
using Services.Input;
using UnityEngine;

public class BulletSplash : MonoBehaviour
{
    [SerializeField] private GameObject _particleExplosion;

    //private ISpecialEffectService _specialEffectService;

    /*public void Awake()
    {
        _specialEffectService = Game.SpecialEffectService;
    }*/

    private void OnParticleCollision(GameObject other)
    {
        //GameObject special = _specialEffectService.InstantiateEffect(_particleExplosion, this.transform);

        Instantiate(_particleExplosion, transform.position, transform.rotation);
    }
}
