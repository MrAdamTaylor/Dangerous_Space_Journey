using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSystem : MonoBehaviour
{
    [SerializeField] private GameObject Rect;
    [SerializeField] private GameObject RectTarget;
    [SerializeField] private float _speed = 1f; 
    //[SerializeField] private Vector3 result;
    
    private Vector3 Ray1;
    private Vector3 Ray2;
    private float _dot;
    private float _angle;
    private float _angleDegrees;
    private int _clockwise;
    private Quaternion current;
    private float _xValue = 90;
    private const float _yValue = 270;
    private const float _zValue = 90;
    private Vector3 _targetPosition;

    private Coroutine _lerpCoroutine;
    private bool rotate;

    void Start()
    {
        _targetPosition = RectTarget.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        /*if (ChangePositionCheck())
        {
            RotateObjectSystem();
            _targetPosition = RectTarget.transform.position;
            rotate = true;
        }*/

        if (Input.GetKeyDown(KeyCode.Z))
        {
            RotateObjectSystem();
            rotate = true;
        }
    }

    private bool ChangePositionCheck()
    {
        if (RectTarget.transform.position != _targetPosition)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    


    private void RotateObjectSystem()
    {
        if (rotate)
        {
             CalculateLines(Rect, RectTarget);
            _dot = DotProduct(Ray1, Ray2);
            _angle = AngleBetween(_dot, Ray1, Ray2);
             _angleDegrees = AngleInDegrees(_angle);
             Cross(Ray1, Ray2);
              _clockwise = GetClockWise();
             RotateObject(_angleDegrees, _clockwise);
        }

        rotate = false;

    }

    private void RotateObject(float angleDegrees, int clockwise)
    {
        if (_angleDegrees > 10f)
        {
            var current = Quaternion.Euler(_xValue, _yValue, _zValue);
            Vector3 resultDestination = new Vector3(_xValue - _angleDegrees, _yValue, _zValue);
            var temp = Quaternion.Euler(0, 0, 0) * resultDestination;
            //Rect.transform.eulerAngles = temp;
            var smoth = Quaternion.Euler(_xValue - _angleDegrees, _yValue, _zValue);
            if (_lerpCoroutine != null)
            {
                StopCoroutine(_lerpCoroutine);
            }
            _lerpCoroutine = StartCoroutine(SmothRotate(current,smoth,_speed));
            _xValue = _xValue - _angleDegrees;
        }
    }

    private IEnumerator SmothRotate(Quaternion quaternion, Quaternion temp, float speed)
    {
        float time = 0;
        while (time < 1)
        {
            yield return new WaitForSeconds(0.1f);
            Rect.transform.rotation = Quaternion.Slerp(quaternion, temp, time);
            time += Time.deltaTime * speed;
        }
        Debug.Log("Остановка!");
    }

    private void CalculateLines(GameObject obj1, GameObject obj2)
    {
        Vector3 selfForward = obj1.transform.forward;
        Vector3 targedDirection = obj2.transform.position - transform.position;
        Debug.Log($"(this.name{this.name}): Obj1 position: {Rect.transform.position}, " +
                  $"Obj1 vectorForward: {selfForward}, " +
                  $"Obj2: {RectTarget.transform.position} " +
                  $"Direction between: {targedDirection}");
        Debug.DrawRay(Rect.transform.position, selfForward * 15, Color.green, 10);
        Debug.DrawRay(Rect.transform.position, targedDirection, Color.red, 10);

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
        int clockwise = -1;
        if (Cross(Ray1, Ray2).z > 0)
        {
            clockwise = 1; 
        }
        Debug.Log($"(this.name{this.name}): Direction {clockwise}");
        return clockwise;
    }
}
