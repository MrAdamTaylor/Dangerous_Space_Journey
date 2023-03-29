using UnityEngine;

namespace Services.Input
{
    public interface IInputServiceMove
    {
        void AddForce(ref Rigidbody rigidbody, Vector3 moveVec, float speed);

        void ApplyRotation(float rotationThisFrame, Transform obj);

        void ProcessRotation(float _turnSpeed, Transform obj);

    }
}