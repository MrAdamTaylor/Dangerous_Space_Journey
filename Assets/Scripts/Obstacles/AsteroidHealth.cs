using System;
using Obstacles;
using UnityEngine;

public class AsteroidHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    private int Health { get; set; } 
    private SplitersSpawn _splitersSpawner;
    private ExplosionEffect _explosionEffect;
    private bool isSpliters;
    private bool isExplosion;
    
    private void OnEnable()
    {
        Health = _maxHealth;
    }

    private void Awake()
    {
        if (gameObject.GetComponent<SplitersSpawn>() != null)
        {
            _splitersSpawner = gameObject.GetComponent<SplitersSpawn>();
            isSpliters = true;
        }
        else
        {
            isSpliters = false;
        }

        if (gameObject.GetComponent<ExplosionEffect>() != null)
        {
            _explosionEffect = gameObject.GetComponent<ExplosionEffect>();
            isExplosion = true;
        }
        else
        {
            isSpliters = false;
        }
    }

    public void DealDamage(int value)
    {
        Health -= value;
        if (Health <= 0)
        {
            gameObject.SetActive(false);
            if (isExplosion)
            {
                _explosionEffect.ExplosionEffectCreate();
            }

            if (isSpliters)
            {
                _splitersSpawner.DestroyOnSplinters();
            }
        }
    }
}
