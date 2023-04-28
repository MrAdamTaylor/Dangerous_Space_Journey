using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class QuaternionWork : MonoBehaviour
{
    [SerializeField] private Quaternion _myQuaternion;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.rotation = _myQuaternion;
    }
}
