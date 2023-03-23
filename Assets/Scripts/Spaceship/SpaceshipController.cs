using System;
using System.Collections;
using System.Collections.Generic;
using Infrastructure;
using Services.BorderService;
using Services.Input;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public Rigidbody _rigBodySpaceShip;
    [SerializeField] private float _thrust;
    [SerializeField] private float _turnTrust;
    private IInputService _inputService;
    private IBorderChecker _borderService;

    private float _thrustSpeed;
    private float _turnSpeed;

    private Vector3 _movementVector;
    private Vector3 _rotationVector;

    private float _yRotation;

    private float rotate;

    public void Awake()
    {
        _inputService = Game.InputService;
        _borderService = Game.BorderService;
    }

    void Start()
    {
        _rigBodySpaceShip = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float _tempSpeed = 1f;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _tempSpeed = 2f;
        }


        if ((_inputService.AxisMove > Constants.PositiveEpsilonRange) || 
            (_inputService.AxisMove < Constants.NegativeEpsilonRange))
        {
            _movementVector = transform.forward;
            _thrustSpeed = _thrust * _inputService.AxisMove * Time.deltaTime * _tempSpeed;
        }

        if ((_inputService.AxisTorque > Constants.PositiveEpsilonRange) || 
            (_inputService.AxisTorque < Constants.NegativeEpsilonRange))
        {
            rotate = Input.GetAxisRaw("Horizontal") * Time.deltaTime * _turnTrust;

            _yRotation += rotate;

            //TODO реализация через сервис
            //_rotationVector = transform.up;
            //_turnSpeed = _turnTrust * _inputService.AxisTorque * Time.deltaTime;

            _rotationVector.y = rotate;
        }


        Vector3 _newPos = transform.position;
        _borderService.BorderCheck(ref _newPos);
        transform.position = _newPos;

        
    }

    void FixedUpdate()
    {
        _rigBodySpaceShip.AddRelativeForce(_movementVector * _thrustSpeed);
        transform.Rotate(_rotationVector);
        //transform.rotation = Quaternion.Euler(0,_yRotation,0);
        
        //TODO реализация через сервис, которая работает
        //_rigBodySpaceShip.AddTorque(_rotationVector * _turnSpeed);
    }
}
