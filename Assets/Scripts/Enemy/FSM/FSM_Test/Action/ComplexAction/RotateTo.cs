using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class RotateTo : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [Range(0.1f, 0.5f)] [SerializeField] private float _time;
    
    private Vector3 Ray1;
    private Vector3 Ray2;
    private float _dot;
    private float _angle;
    private float _angleDegrees;
    private Vector3 _crossVector;
    private int _clockwise;
    private Coroutine _runningCoroutine;

    private void OnEnable()
    {
        //StartCoroutineRotate();
    }

    /*public void StartCoroutineRotate()
    {
        if (_runningCoroutine == null)
           _runningCoroutine = StartCoroutine(RotateCoroutine());
    }*/

    /*public void StopCoroutineRotate()
    {
        if(_runningCoroutine != null)
            StopCoroutine(RotateCoroutine());
    }*/

    private void Update()
    {
        
    }

    //TODO хотел сделать через корутины, но не подумал зааранее при проектировании State Machine
    /*public IEnumerator RotateCoroutine()
    {
        yield return new WaitForSeconds(_time);
        RotateToObject();
        Debug.Log($"Я корутина поворота работаю {Time.time}");
    }*/

    public void RotateToObject()
    {
        CalculateDirection(gameObject, _player);
        _dot = MathModule.DotProductXY(Ray1, Ray2);
        _angle = MathModule.AngleBetween(_dot, Ray1, Ray2);
        _angleDegrees = MathModule.TranslateAngleInDegrees(_angle);
        _crossVector = MathModule.CrossProduct(Ray1, Ray2);
        _clockwise = MathModule.GetClockWise(_crossVector);
        Debug.Log($"Направление угла: {_clockwise}");
        float newAngle = transform.eulerAngles.z + (_clockwise * _angleDegrees);
        if (newAngle < 0)
        {
            newAngle = Mathf.Abs(newAngle) + 180;
        }

        float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, transform.eulerAngles.z + (_clockwise * _angleDegrees),
            newAngle);
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    private void CalculateDirection(GameObject obj1, GameObject obj2)
    {
        Vector3 selfForward = -obj1.transform.up;
        Vector3 targedDirection = obj2.transform.position - transform.position;
        Debug.Log($"(this.name{this.name}): Obj1 position: {transform.position}, " +
                  $"Obj1 vectorForward: {selfForward}, " +
                  $"Obj2: {_player.transform.position} " +
                  $"Direction between: {targedDirection}");
        Debug.DrawRay(transform.position, selfForward * 35, Color.green, 2);
        Debug.DrawRay(transform.position, targedDirection, Color.red, 2);

        Ray1 = selfForward;
        Ray2 = targedDirection;
    }

    private void OnDisable()
    {
        //StartCoroutineRotate();
    }
}
