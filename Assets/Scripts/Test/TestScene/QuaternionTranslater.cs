using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class QuaternionTranslater : MonoBehaviour
{
    public Vector3 result;
    public float rotation;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        result = Vector3.forward * 5;
        result = Quaternion.Euler(0, rotation, 0) * result;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(this.transform.position, this.transform.position + result);
    }
}
