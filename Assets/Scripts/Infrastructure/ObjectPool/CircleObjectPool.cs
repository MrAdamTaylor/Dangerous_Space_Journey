using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class CircleObjectPool : MonoBehaviour
{
    #region Данные, которые нужно перенести в статик

        [SerializeField] private GameObject _asteroidPrefab;
        [SerializeField] public int poolSize = 5;
        [SerializeField] private Spawner _spawnPoint;
        [SerializeField] private string _poolName;
        
        //TODO То, что надо будет перенести в статику и правильно разбить на ответственность
        [Header("Это нужно перенести в спавнер")]
        [SerializeField] private float _spawnTimer = 1f;
        
        [Header("Это тоже не зона ответственности пула")]
        [SerializeField]private Transform _player;
        [SerializeField]private float _maxThrust;
    #endregion
    
    

    [HideInInspector] public GameObject[] pool;
    private Queue<GameObject> qPool = new Queue<GameObject>();
    private Rigidbody _asteroidRigidBody;
    

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
        GameObject poolPosition = new GameObject();
        SpawnPoolPoint(poolPosition);
        
        pool = new GameObject[poolSize];
        for (int i = 0; i < poolSize - 1; i++)
        {
             pool[i] = Instantiate(_asteroidPrefab,_spawnPoint.ReturnPosition(), Quaternion.identity);
             pool[i].SetActive(false);
             pool[i].transform.SetParent(poolPosition.transform);
             qPool.Enqueue(pool[i]);
        }
    }

    private void SpawnPoolPoint(GameObject pool)
    {
        Instantiate(pool, transform.position, Quaternion.identity);
        pool.name = _poolName;
    }

    void EnableObjectPool()
    {
        for (int i = 0; i < qPool.Count; i++)
        {
            GameObject elementInOrder = qPool.Dequeue();
            if (!elementInOrder.activeInHierarchy)
            {
                elementInOrder.SetActive(true);
               // _asteroidRigidBody = elementInOrder.GetComponentInChildren<Rigidbody>();
                //elementInOrder.transform.LookAt(_player);
                //_asteroidRigidBody.AddForce(elementInOrder.transform.forward * Time.deltaTime * _maxThrust * 200f);
                qPool.Enqueue(elementInOrder);
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
