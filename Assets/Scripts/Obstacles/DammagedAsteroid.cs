using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DammagedAsteroid : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private AsteroidHealth _asteroidHealth;
    private void OnParticleCollision(GameObject other)
    {
        _asteroidHealth = GetComponent<AsteroidHealth>();
        Debug.Log($"{name} hited by {other.gameObject.name}");
        if (_asteroidHealth != null)
        {
            _asteroidHealth.DealDamage(_damage);
        }
    }
}
