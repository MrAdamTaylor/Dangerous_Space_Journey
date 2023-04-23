using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[ExecuteInEditMode]
public class QuaternionRotateTest : MonoBehaviour
{
    [SerializeField] private GameObject _rect;
    [SerializeField] private Vector3 _quaternion;
    private Vector3 _result;
    private Vector3 _newResutl;

        private void Update()
    {
        _rect.transform.rotation = 
            Quaternion.Euler(_quaternion.x, _quaternion.y,_quaternion.z);
        _newResutl = Quaternion.Euler(_quaternion.x, _quaternion.y,_quaternion.z) * _result;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(this.transform.position, this.transform.position + _newResutl * 5f);
    }
}
