using System;
using Infrastructure;
using Services.Input;
using UnityEngine;

public class MoveHandler : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBSpacesip;
    [SerializeField] private float _thrust;
    [SerializeField] private float _turnSpeed;

    private IInputServiceMove _inputServiceMove;
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

        _inputServiceMove = Game.InputServiceMove;
        _rigidBSpacesip = GetComponent<Rigidbody>();

        _movementVector = -transform.up;
        _thrustSpeed = _thrust * Time.deltaTime;
        if(Input.GetKey(KeyCode.W))
        _inputServiceMove.AddForce(ref _rigidBSpacesip, _movementVector, _thrustSpeed);
        _inputServiceMove.ProcessRotation(_turnSpeed, transform);

    }

}
