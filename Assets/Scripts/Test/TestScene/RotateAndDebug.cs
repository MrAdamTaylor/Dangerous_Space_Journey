using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotateAndDebug : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject self;

    private Vector3 Ray1;
    private Vector3 Ray2;
    private float _dot;
    private float _angle;
    private float _angleDegrees;
    private int _clockwise;
    
    private void Start()
    {
        RotateObjectSystem();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            RotateObjectSystem();
        }
    }

    private void RotateObjectSystem()
    {
        CalculateLines(self, target);
        _dot = DotProduct(Ray1, Ray2);
        _angle = AngleBetween(_dot, Ray1, Ray2);
        _angleDegrees = AngleInDegrees(_angle);
        Cross(Ray1, Ray2);
        _clockwise = GetClockWise();
        RotateObject(_angleDegrees, _clockwise);
    }

    private void RotateObject(float angleDegrees, int clockwise)
    {
        if (_angleDegrees > 10f)
        {
            this.transform.Rotate(0, _angleDegrees * _clockwise, 0);
        }
    }

    private void CalculateLines(GameObject obj1, GameObject obj2)
    {
        Vector3 selfForward = obj1.transform.forward;
        Vector3 targedDirection = obj2.transform.position - transform.position;
        Debug.Log($"Obj1 position: {self.transform.position}, " +
                  $"Obj1 vectorForward: {selfForward}, " +
                  $"Obj2: {target.transform.position} " +
                  $"Direction between: {targedDirection}");
        Debug.DrawRay(self.transform.position, selfForward * 15, Color.green, 10);
        Debug.DrawRay(self.transform.position, targedDirection, Color.red, 10);

        Ray1 = selfForward;
        Ray2 = targedDirection;
    }

    private float DotProduct(Vector3 vec1, Vector3 vec2)
    {
        float dot = vec1.x * vec2.x + vec1.y * vec2.y;
        Debug.Log($"Dot product between object = {dot}");
        return dot;
    }

    private float AngleBetween(float dot, Vector3 vec1, Vector3 vec2)
    {
        float angle = Mathf.Acos(dot / (vec1.magnitude * vec2.magnitude));
        Debug.Log($"Magnitude from vec1: {vec1.magnitude}, Magnitude from vec2: {vec2.magnitude}, Angle between {angle}");
        return angle;
    }

    private float AngleInDegrees(float angle)
    {
        float _angleDegrees = angle * Mathf.Rad2Deg;
        Debug.Log($"Angle in Degree = {_angleDegrees} ");
        return _angleDegrees;
    }

    Vector3 Cross(Vector3 v, Vector3 w)
    {
        float xMult = v.y * w.z - v.z * w.y;
        float yMult = v.x * w.z - v.z * w.x;
        float zMult = v.x * w.y - v.y * w.x;
        Vector3 cross = new Vector3(xMult, yMult, zMult);
        Debug.Log($"Cross Vector: {cross}");
        Debug.DrawRay(self.transform.position, cross, Color.blue, 10f);
        return cross;
    }


    private int GetClockWise()
    {
        int clockwise = 1;
        if (Cross(Ray1, Ray2).z > 0)
        {
            clockwise = -1; 
        }
        return clockwise;
    }
}
