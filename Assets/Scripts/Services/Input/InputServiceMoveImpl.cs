using UnityEngine;

namespace Services.Input
{
    class InputServiceMoveImpl : InputServiceMove
    {
        private float _yRotation;
        public override void AddForce(ref Rigidbody _rigidbody, Vector3 moveVec, float speed)
        {
            _rigidbody.AddRelativeForce(moveVec * speed);   
        }
        
        public override void ProcessRotation(float _turnSpeed, Transform obj)
        {
            if (UnityEngine.Input.GetKey(KeyCode.A))
            {
                ApplyRotation(_turnSpeed, obj);
            }
            else if (UnityEngine.Input.GetKey(KeyCode.D))
            {
                ApplyRotation(-_turnSpeed, obj);
            }
        }

        public override void ApplyRotation(float rotationThisFrame, Transform obj)
        {
            obj.Rotate(Vector3.down * rotationThisFrame * Time.deltaTime);
        }
    }
}