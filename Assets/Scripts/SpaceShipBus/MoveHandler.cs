using System;
using Infrastructure;
using Services.Input;
using UnityEngine;

namespace SpaceShipBus
{
    public class MoveHandler : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidBSpacesip;
        [Range(5f,25f)][SerializeField] private float _thrust = 10f;
        [Range(5f,50f)][SerializeField] private float _turnSpeed = 40f;

        private IInputServiceMove _inputServiceMove;
        private Vector3 movementVector;
        //private float thrustSpeed;
    
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

            movementVector = -transform.up;
            float thrustSpeed = _thrust * Time.deltaTime * Constants.COEF_PLAYER_MOVE;
            float turnSpeed = _turnSpeed * Time.deltaTime * Constants.COEF_TURN_MOVE;
            if(Input.GetKey(KeyCode.W))
                _inputServiceMove.AddForce(ref _rigidBSpacesip, movementVector, thrustSpeed);
            _inputServiceMove.ProcessRotation(turnSpeed, transform);

        }

    }
}
