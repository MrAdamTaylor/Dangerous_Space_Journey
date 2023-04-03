using System;
using Obstacles;
using UnityEngine;

public class AsteroidHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    private int health;
    private SplitersSpawn _splitersSpawner;
    private bool isSpliters;
    
    private void OnEnable()
    {
        health = _maxHealth;
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
    }

    public void DealDamage(int value)
    {
        health -= value;
        if (health <= 0)
        {
            gameObject.SetActive(false);
            if (isSpliters == true)
            {
                _splitersSpawner.DestroyOnSplinters();
            }
        }
    }
}
