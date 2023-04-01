using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ExplosionForce : MonoBehaviour
{
    
    [Tooltip("Эффект взрыва!")]
    [SerializeField] private GameObject _explosionEffect;
    [Tooltip("Ссылка на префаб астеройда!")]
    [SerializeField] private GameObject self;


    [Header("Всё, что связанно с осколками")]
    [Tooltip("Ссылка на префаб осколка!")]
    [SerializeField] private GameObject _splinter;
    [Tooltip("Количество осколков!")]
    [SerializeField] private int _splinterCount;

    [Header("Позиции спавна осколков")]    
    [SerializeField] private int _maxHits = 25;
    [SerializeField] private float _radius = 10f;
    
    [Header("Слой, который отталкивает взрыв")]
    [SerializeField] private LayerMask _hitLayer;
    [Header("Сила взрыва")]
    [SerializeField] private float ExplosiveForce;
    
    [SerializeField] private RefreshingObjectPool objectPool;
    [SerializeField] private Spawner _spawnPoint;


    private Collider[] Hits;
    private bool isExplosion = false;
    private bool isSplintersSpawn = false;

    private bool isCrashed = false;
    
    private void Awake()
    {
        objectPool = GetComponent<RefreshingObjectPool>();
        objectPool.enabled = false;
        if (_spawnPoint.GetComponent<BorderSpawner>() != null)
        {
            _spawnPoint.GetComponent<BorderSpawner>();
        }
        else
        {
            _spawnPoint.GetComponent<SimpleSpawner>();
        }
    }

    
    
    private void Update()
    {
        CheckSelfAction();
        Hits = new Collider[_maxHits];
        if (self.activeSelf == false && isCrashed == true)
        {
            //isSplintersSpawn = false;
            PhysicsDebug.DrawDebug(StartPoint(), _radius, 5f);
            InstantiateExplosion();
            InstantiateSplinters();
            StartCoroutine(SplinterCalls());
            StopCoroutine(SplinterCalls());
            //spawner.enabled = true;
            //spawner.Restart();
            //spawner.enabled = false;
            int hits = Physics.OverlapSphereNonAlloc(StartPoint(), _radius, Hits, _hitLayer);

            for (int i = 0; i < hits; i++)
            {
                if (Hits[i].TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
                {
                    float distance = Vector3.Distance(StartPoint(), Hits[i].transform.position);
                    rigidbody.AddExplosionForce(ExplosiveForce, StartPoint(),_radius);
                }
            }
        }
        
        
    }

    private void CheckSelfAction()
    {
        if (self.activeSelf == true)
        {
            isCrashed = true;
        }
    }


    IEnumerator SplinterCalls()
    {
        yield return new WaitForSeconds(0.05f);
        //InstantiateSplinters();
    }

    private void InstantiateExplosion()
    {
        if (isExplosion == false)
        {
            Instantiate(_explosionEffect, StartPoint() + new Vector3(0,0,-10), Quaternion.identity);
            isExplosion = true;
        }
    }

    public Vector3 StartPoint()
    {
        return new Vector3(self.transform.position.x, self.transform.position.y, self.transform.position.z);
    }

    

    private void InstantiateSplinters()
    {
        if (isSplintersSpawn == false)
        {
            for (int i = 0; i < _splinterCount; i++)
            {
                Instantiate(_splinter, _spawnPoint.ReturnPosition(), Quaternion.identity);
                Debug.Log($"Позиция осколка {i} - {_splinter.transform.position}");
            }
            isSplintersSpawn = true;
        }
    }

    IEnumerator SpawnSplinters()
    {
        for (int j = 0; j < _splinterCount; j++)
        {
            Instantiate(_splinter, _spawnPoint.ReturnPosition(), Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }
}
