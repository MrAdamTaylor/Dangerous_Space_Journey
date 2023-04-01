using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    [SerializeField] private GameObject _particleExplosion;

    private void OnParticleCollision(GameObject other)
    {
        Instantiate(_particleExplosion, transform.position, transform.rotation);
    }
}
