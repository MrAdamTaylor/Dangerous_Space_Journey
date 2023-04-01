using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    private int health;
    
    private void OnEnable()
    {
        health = _maxHealth;
    }

    public void DealDamage(int value)
    {
        health -= value;
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
