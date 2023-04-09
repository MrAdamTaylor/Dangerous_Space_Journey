using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MoveToPlayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rigidBodyEnemy;
    [SerializeField] private Transform _player;
    [SerializeField] private float _rotationSPeed;
    private Vector3 _direction;
    private bool _autopilot;

    void Start()
    {
        _player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log(CalculateDistance());
            CalculateAngle();
        }
        //transform.LookAt(_player);
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            _autopilot = !_autopilot;
        }
        
        if(_autopilot)
            AutoPilot();
    }

    private void FixedUpdate()
    {
        //_direction = (_player.position - transform.position).normalized;
        //_rigidBodyEnemy.MovePosition(_rigidBodyEnemy.position + _direction * _speed * Time.fixedDeltaTime);
    }

    float CalculateDistance()
    {
        float distance = Mathf.Sqrt(Mathf.Pow
                    (_player.position.x - transform.position.x, 2)
                     + (_player.position.y - transform.position.y));
        return distance;
    }

    Vector3 Cross(Vector3 v, Vector3 w)
    {
        float xMult = v.y * w.z - v.z * w.y;
        float yMult = v.x * w.z - v.z * w.x;
        float zMult = v.x * w.y - v.y * w.x;
        
        return (new Vector3(xMult, yMult, zMult));
    }

    void CalculateAngle()
    {
        Vector3 enemyForward = -transform.forward;
        Vector3 playerDirection = _player.position - transform.position;
        
        Debug.DrawRay(this.transform.position, enemyForward, Color.green, 5);
        Debug.DrawRay(this.transform.position, playerDirection, Color.red, 5);

        float dot = enemyForward.x * playerDirection.x + enemyForward.y * playerDirection.y;
        float angle = Mathf.Acos(dot / (enemyForward.magnitude * playerDirection.magnitude));
        
        Debug.Log("Angle: " + angle * Mathf.Rad2Deg);
        Debug.Log("Unity Angle: " + Vector3.Angle(enemyForward,playerDirection));

        int clockwise = 1;
        if (Cross(enemyForward, playerDirection).y < 0)
            clockwise = -1;
        
        transform.Rotate(0,angle * Mathf.Rad2Deg * clockwise ,0); //* _rotationSPeed
        
    }

    void AutoPilot()
    {
        StartCoroutine(RotateToPlayer());
        //transform.position += -transform.forward * _speed * Time.deltaTime;
    }


    IEnumerator RotateToPlayer()
    {
        
        yield return new WaitForSeconds(1f);
        CalculateAngle();
    }
}
