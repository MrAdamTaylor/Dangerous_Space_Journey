using System.Collections;
using Obstacles;
using UnityEngine;

public class ExplosionWithoutApparts : ExplosionForce
{
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
        CreateExplosionForce();
    }
    protected override void CreateExplosionForce()
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
                    rigidbody.AddExplosionForce(_explosiveForce, StartPoint(), _radius);
                }
            }

            StartCoroutine(disableObject());
        }
    }
    private IEnumerator disableObject()
    {
        yield return new WaitForSeconds(_timeDuration);
        StopCoroutine(disableObject());
        this.gameObject.SetActive(false);
    }
    public Vector3 StartPoint()
    {
        return new Vector3(self.transform.position.x, self.transform.position.y, self.transform.position.z);
    }
}