using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AsteroidMoveToPlayer : MonoBehaviour
{
    [FormerlySerializedAs("maxThrust")] [SerializeField]private float _maxThrust;
    [SerializeField] private Rigidbody _asteroidRigidBody;
    [SerializeField] private Transform _player;



    void Start()
    {
        transform.LookAt(_player);
        
        
        _asteroidRigidBody.AddForce(transform.forward * Time.deltaTime * _maxThrust);
    }

}
