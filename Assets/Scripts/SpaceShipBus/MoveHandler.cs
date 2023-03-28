using System;
using System.Collections;
using System.Collections.Generic;
using Infrastructure;
using Services.Input;
using Services.Input2;
using UnityEngine;

public class MoveHandler : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBSpacesip;
    [SerializeField] private float _thrust;
    [SerializeField] private float _turnSpeed;

    private IInputService _inputService;
    private IInputService2 _inputService2;
    private Vector3 _movementVector;
    private float _thrustSpeed;
    

    private void OnEnable()
    {
        GlobalBus.Sync.Subscribe<GameControllerHandler>(Move);
    }

    private void OnDisable()
    {
        GlobalBus.Sync.Unsubscribe<GameControllerHandler>(Move);
    }

    private void Move(object sender, EventArgs eventArgs)
    {
        /*_inputService = Game.InputService;
        _rigidBSpacesip = GetComponent<Rigidbody>();
        
        if ((_inputService.AxisMove > Constants.PositiveEpsilonRange) || 
            (_inputService.AxisMove < Constants.NegativeEpsilonRange))
        {
            _movementVector = transform.forward;
            _thrustSpeed = _thrust * _inputService.AxisMove * Time.deltaTime;
        }
        _rigidBSpacesip.AddRelativeForce(_movementVector * _thrustSpeed);*/

        _inputService2 = Game.InputService2;
        _rigidBSpacesip = GetComponent<Rigidbody>();

        _movementVector = -transform.up;
        _thrustSpeed = _thrust * Time.deltaTime;
        if(Input.GetKey(KeyCode.W))
        _inputService2.AddForce(ref _rigidBSpacesip, _movementVector, _thrustSpeed);
        /*if((_inputService2.AxisTorque > Constants.PositiveEpsilonRange) || (_inputService2.AxisTorque < Constants.NegativeEpsilonRange))
            transform.rotation = _inputService2.Rotate(_turnSpeed);*/
        //transform.Rotate(Vector3.down * _turnSpeed * Time.deltaTime);
        ProcessRotation();
        

    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(_turnSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-_turnSpeed);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        _rigidBSpacesip.freezeRotation = true;
        transform.Rotate(Vector3.down * rotationThisFrame * Time.deltaTime);
        _rigidBSpacesip.freezeRotation = false;
    }
}
