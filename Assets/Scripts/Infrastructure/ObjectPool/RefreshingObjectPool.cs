using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshingObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _asteroidPrefab;
    [SerializeField] public int poolSize = 5;
    [SerializeField] private float _spawnTimer = 1f;
    [SerializeField] private Spawner _spawnPoint;

    [HideInInspector] public GameObject[] pool;

    void Start()
    {
        if (_spawnPoint.GetComponent<BorderSpawner>() != null)
        {
            _spawnPoint.GetComponent<BorderSpawner>();
        }
        else
        {
            _spawnPoint.GetComponent<SimpleSpawner>();
        }

        PopulatePool();
    }
    
    
    private void PopulatePool()
    {
        pool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            pool[i] = Instantiate(_asteroidPrefab,_spawnPoint.ReturnPosition(), Quaternion.identity);
            pool[i].SetActive(false);
        }
    }

    public void Restart()
    {
        EnableObjectPool();
    }

    private void EnableObjectPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
            }
        }
    }
    
    
}
