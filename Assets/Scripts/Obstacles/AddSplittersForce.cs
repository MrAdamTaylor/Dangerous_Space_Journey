using System;
using System.Collections;
using System.Collections.Generic;
using Obstacles;
using UnityEngine;

//[RequireComponent(typeof(SplitersSpawn))]
public class AddSplittersForce : MonoBehaviour
{
    [Tooltip("Максимальное количество задеваемых волной осколков")]
    [SerializeField] private int _maxHits;

    [Tooltip("Радиус взрыва")]
    [SerializeField] private float _radius;
    
    [Tooltip("Слой задеваемых объектов")]
    [SerializeField] private LayerMask _hitLayer;

    [Tooltip("Сила взрыва")]
    [SerializeField] private float ExplosiveForce;
    
    //[SerializeField] private Cooldown _explosionCooldown;

    public Collider[] Hits { get; set; }

    public void Update()
    {
        PhysicsDebug.DrawDebug(CrashedPosition(), _radius, 5f);
        /*if (Input.GetKeyDown(KeyCode.S))
        {
            AddExplosionRadius();
        }*/
    }

    

    public void AddExplosionRadius()
    {

        Hits = new Collider[_maxHits];
            int hits = Physics.OverlapSphereNonAlloc(CrashedPosition(), _radius, Hits, _hitLayer);
            PhysicsDebug.DrawDebug(CrashedPosition(), _radius, 5f);
            for (int i = 0; i < hits; i++)
            {
                if (Hits[i].TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
                {
                    Debug.Log($"Я получил! от {Hits[i]}");
                    float distance = Vector3.Distance(CrashedPosition(), Hits[i].transform.position);
                    rigidbody.AddExplosionForce(ExplosiveForce, CrashedPosition(), _radius);
                }
            }
    }

    private Vector3 CrashedPosition()
    {
        return new Vector3(transform.position.x, transform.position.y, transform.position.y);
    }
}
