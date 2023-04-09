using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private GameObject _goal;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _goal.transform.rotation, _speed * Time.deltaTime);
    }
}
