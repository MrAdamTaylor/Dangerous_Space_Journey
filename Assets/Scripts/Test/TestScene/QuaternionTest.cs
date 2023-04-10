using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

//[ExecuteInEditMode]
public class QuaternionTest : MonoBehaviour
{
    [SerializeField] private GameObject Rect;
    [SerializeField] private GameObject RectTarget;
    [SerializeField] private float AxisY;
    [SerializeField] private Vector3 result;

    [SerializeField] private float Axis_x;
    [SerializeField] private float Axis_z;
    
    
    private Vector3 Ray1;
    private Vector3 Ray2;
    private float _dot;
    private float _angle;
    private float _angleDegrees;
    private int _clockwise;

    // Start is called before the first frame update

    public void Awake()
    {
        Rotate();
    }

    void Start()
    {
        

        CalculateLines(Rect, RectTarget);
        _dot = DotProduct(Ray1, Ray2);
        _angle = AngleBetween(_dot, Ray1, Ray2);
        _angleDegrees = AngleInDegrees(_angle);
        Cross(Ray1, Ray2);
        _clockwise = GetClockWise();
    }

    // Update is called once per frame
    void Update()
    {
        //result = Vector3.forward * 10;
    }
    
    private void RotateObjectSystem()
    {
        CalculateLines(Rect, RectTarget);
        _dot = DotProduct(Ray1, Ray2);
        _angle = AngleBetween(_dot, Ray1, Ray2);
        _angleDegrees = AngleInDegrees(_angle);
        Cross(Ray1, Ray2);
        _clockwise = GetClockWise();
        RotateObject(_angleDegrees, _clockwise);
    }

    private void Rotate()
    {
        var temp = Quaternion.Euler(Axis_x, AxisY, Axis_z) * result;
        Rect.transform.eulerAngles = temp;
        Debug.DrawRay(Rect.transform.position,Rect.transform.forward*25,Color.red, 1);
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(this.transform.position, this.transform.forward);
    }*/
    
    
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
        Debug.Log($"(this.name{this.name}): Obj1 position: {Rect.transform.position}, " +
                  $"Obj1 vectorForward: {selfForward}, " +
                  $"Obj2: {RectTarget.transform.position} " +
                  $"Direction between: {targedDirection}");
        //Debug.DrawRay(self.transform.position, selfForward * 15, Color.green, 10);
        //Debug.DrawRay(self.transform.position, targedDirection, Color.red, 10);

        Ray1 = selfForward;
        Ray2 = targedDirection;
    }

    private float DotProduct(Vector3 vec1, Vector3 vec2)
    {
        float dot = vec1.x * vec2.x + vec1.y * vec2.y;
        Debug.Log($"(this.name{this.name}): Dot product between object = {dot}");
        return dot;
    }

    private float AngleBetween(float dot, Vector3 vec1, Vector3 vec2)
    {
        float angle = Mathf.Acos(dot / (vec1.magnitude * vec2.magnitude));
        Debug.Log($"(this.name{this.name}): Magnitude from vec1: {vec1.magnitude}, Magnitude from vec2: {vec2.magnitude}, Angle between {angle}");
        return angle;
    }

    private float AngleInDegrees(float angle)
    {
        float _angleDegrees = angle * Mathf.Rad2Deg;
        Debug.Log($"(this.name{this.name}): Angle in Degree = {_angleDegrees} ");
        return _angleDegrees;
    }

    Vector3 Cross(Vector3 v, Vector3 w)
    {
        float xMult = v.y * w.z - v.z * w.y;
        float yMult = v.x * w.z - v.z * w.x;
        float zMult = v.x * w.y - v.y * w.x;
        Vector3 cross = new Vector3(xMult, yMult, zMult);
        Debug.Log($"(this.name{this.name}): Cross Vector: {cross}");
        Debug.DrawRay(Rect.transform.position, cross, Color.blue, 10f);
        return cross;
    }


    private int GetClockWise()
    {
        int clockwise = 1;
        if (Cross(Ray1, Ray2).z > 0)
        {
            clockwise = -1; 
        }
        Debug.Log($"(this.name{this.name}): Direction {clockwise}");
        return clockwise;
    }
}
