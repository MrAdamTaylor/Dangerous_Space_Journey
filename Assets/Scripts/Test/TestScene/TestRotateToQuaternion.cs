using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotateToQuaternion : MonoBehaviour
{
    [SerializeField] private float angle;
    private Quaternion _writeQuaternion;
    private Quaternion _startPosition;
    
    
    void Start()
    {
        _startPosition = transform.rotation;
        _writeQuaternion = transform.rotation;
        OutputAngles();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            RotateToX(angle);
            OutputAngles();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            RotateToY(angle);
            OutputAngles();

        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            RotateToZ(angle);
            OutputAngles();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            StartCoroutine(RotateTo());
        }
        
        if (Input.GetKeyDown(KeyCode.N))
        {
            StartCoroutine(NegativeRotateTo());
        }

    }

    IEnumerator RotateTo()
    {
        int cout = 0;
        while (cout < Mathf.Abs(angle))
        {
            transform.Rotate(0,1,0);
            cout++;
            yield return new WaitForSeconds(0.1f);
            _writeQuaternion = transform.rotation;
            OutputAngles(cout);
        }
    }
    
    IEnumerator NegativeRotateTo()
    {
        int cout = 0;
        while (cout < Mathf.Abs(angle))
        {
            transform.Rotate(0,-1,0);
            cout++;
            yield return new WaitForSeconds(0.1f);
            _writeQuaternion = transform.rotation;
            OutputAngles(cout);
        }
    }
    
    

    private void RotateToX(float angle)
    {
        transform.rotation = _startPosition;
        transform.Rotate(angle,0,0);
        _writeQuaternion = transform.rotation;
    }
    
    private void RotateToY(float angle)
    {
        transform.rotation = _startPosition;
        transform.Rotate(0,angle,0);
        _writeQuaternion = transform.rotation;

    }
    
    private void RotateToZ(float angle)
    {
        transform.rotation = _startPosition;
        transform.Rotate(0,0,angle);
        _writeQuaternion = transform.rotation;
    }

    private void OutputAngles()
    {
        var x = _writeQuaternion.x;
        var y = _writeQuaternion.y;
        var z = _writeQuaternion.z;
        var xE = _writeQuaternion.eulerAngles.x;
        var yE = _writeQuaternion.eulerAngles.y;
        var zE = _writeQuaternion.eulerAngles.z;
        Debug.Log($" transform rotation  ({x} {y} {z}); transfrom euler ({xE} {yE} {zE}); angle = {angle}");
    }
    
    private void OutputAngles(int index)
    {
        var x = _writeQuaternion.x;
        var y = _writeQuaternion.y;
        var z = _writeQuaternion.z;
        var xE = _writeQuaternion.eulerAngles.x;
        var yE = _writeQuaternion.eulerAngles.y;
        var zE = _writeQuaternion.eulerAngles.z;
        Debug.Log($"Index{index} transform rotation  ({x} {y} {z}); transfrom euler ({xE} {yE} {zE}); angle = {angle}");
    }
}
