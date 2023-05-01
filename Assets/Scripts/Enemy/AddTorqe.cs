using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTorqe : MonoBehaviour
{
    public float amount = 50f;
    private Rigidbody _rigidbody;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal") * amount * Time.deltaTime;
        float v = Input.GetAxis("Vertical") * amount * Time.deltaTime;
        
        _rigidbody.AddTorque(transform.up * h);
        _rigidbody.AddTorque(transform.right * v);
    }
}
