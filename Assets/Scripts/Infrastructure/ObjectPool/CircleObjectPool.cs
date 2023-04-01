using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class CircleObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _asteroidPrefab;
    [SerializeField] public int poolSize = 5;
    [SerializeField] private float _spawnTimer = 1f;
    [SerializeField] private Spawner _spawnPoint;

    [HideInInspector] public GameObject[] pool;

    void Awake()
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
        for (int i = 0; i < poolSize - 1; i++)
        {
             pool[i] = Instantiate(_asteroidPrefab,_spawnPoint.ReturnPosition(), Quaternion.identity);
             pool[i].SetActive(false);
        }
    }

    void EnableObjectPool()
    {
        for (int i = 0; i < pool.Length-1; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }

    void OnEnable()
    {
        StartCoroutine(SpawnAsteroids());
    }


    IEnumerator SpawnAsteroids()
    {
        while (true)
        {
            EnableObjectPool();
            yield return new WaitForSeconds(_spawnTimer );
        }
    }


}
