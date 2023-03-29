using UnityEngine;

namespace Services.Input
{
    abstract class InputServiceMove : IInputServiceMove
    {
        public abstract void AddForce(ref Rigidbody rigidbody, Vector3 moveVec, float speed);

        public abstract void ApplyRotation(float rotationThisFrame, Transform obj);

        public abstract void ProcessRotation(float _turnSpeed, Transform obj);
        
    }
}