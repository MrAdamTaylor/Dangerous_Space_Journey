using System;
using System.Collections;
using Obstacles;
using UnityEngine;

public class ExplosionWithApparts : ExplosionForce
{
    private Collider[] Hits;

    private void Update()
    {
        CreateExplosionForce();
    }

    protected override void CreateExplosionForce()
    {
        Hits = new Collider[_maxHits];
        if ((self.activeSelf == false))
        {
            PhysicsDebug.DrawDebug(StartPoint(), _radius, Constants.MIDDLE_LIFE_TIME);
            int hits = Physics.OverlapSphereNonAlloc(StartPoint(), _radius, Hits, _hitLayer);

            for (int i = 0; i < hits; i++)
            {
                if (Hits[i].TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
                {
                    float distance = Vector3.Distance(StartPoint(), Hits[i].transform.position);
                    rigidbody.AddExplosionForce(_explosiveForce * Constants.COEF_EXPLOSION_POWER, StartPoint(), _radius);
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
