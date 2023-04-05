using System;
using System.Collections;
using Obstacles;
using UnityEngine;

public class ExplosionForce : MonoBehaviour
{
    
    [Tooltip("Ссылка на префаб астеройда!")]
    [SerializeField] private GameObject self;

    [Header("Позиции спавна осколков")]    
    [SerializeField] private int _maxHits = 25;
    [SerializeField] private float _radius = 10f;
    
    [Header("Слой, который отталкивает взрыв")]
    [SerializeField] private LayerMask _hitLayer;
    [Header("Сила взрыва")]
    [SerializeField] private float ExplosiveForce;


    private SplitersSpawn _splitersSpawn;


    private Collider[] Hits;

    private void Awake()
    {
        _splitersSpawn = self.GetComponent<SplitersSpawn>();
    }


    private void OnEnable()
    {
        _splitersSpawn.RecoveryObject();
    }
   
    
    private void Update()
    {
        Hits = new Collider[_maxHits];
        if ((self.activeSelf == false))
        {
            PhysicsDebug.DrawDebug(StartPoint(), _radius, 5f);
            int hits = Physics.OverlapSphereNonAlloc(StartPoint(), _radius, Hits, _hitLayer);

            for (int i = 0; i < hits; i++)
            {
                if (Hits[i].TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
                {
                    float distance = Vector3.Distance(StartPoint(), Hits[i].transform.position);
                    rigidbody.AddExplosionForce(ExplosiveForce, StartPoint(),_radius);
                }
            }

            StartCoroutine(disableObject());
            //StopCoroutine(disableObject());
            // this.enabled = false;

        }
        
        
    }

    private IEnumerator disableObject()
    { 
        //this.enabled = false;
        yield return new WaitForSeconds(2f);
        Debug.Log("Ка бум!");
        StopCoroutine(disableObject());
        this.gameObject.SetActive(false);
    }

    public Vector3 StartPoint()
    {
        return new Vector3(self.transform.position.x, self.transform.position.y, self.transform.position.z);
    }

}
