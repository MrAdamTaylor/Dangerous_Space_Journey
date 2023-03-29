using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AsteroidMove : MonoBehaviour
{
    [FormerlySerializedAs("maxThrust")] [SerializeField]private float _maxThrust;
    [SerializeField] private Rigidbody _asteroidRigidBody;

    private Vector3 direction;

    void Start()
    {
        direction = new Vector3(Random.Range(-_maxThrust,_maxThrust),
            Random.Range(-_maxThrust,_maxThrust),0);
        
        _asteroidRigidBody.AddForce(direction * Time.deltaTime);
    }

}
