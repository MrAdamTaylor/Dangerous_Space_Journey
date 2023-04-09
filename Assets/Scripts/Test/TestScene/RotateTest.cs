using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTest : MonoBehaviour
{
    [SerializeField] private Transform target;
    
    void Start()
    {
        
    }

  
    void Update()
    {
        Vector3 relativePos = target.position - transform.position;

        // the second argument, upwards, defaults to Vector3.up
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.forward);
        transform.rotation = rotation;
    }
}