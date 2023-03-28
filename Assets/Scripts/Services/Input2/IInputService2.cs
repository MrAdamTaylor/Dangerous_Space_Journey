using UnityEngine;

namespace Services.Input2
{
    public interface IInputService2
    {
        void AddForce(ref Rigidbody rigidbody, Vector3 moveVec, float speed);

        float AxisTorque { get; }

        Quaternion Rotate(float thrust);
  

        bool IsAttackButtonUp();

    }

    abstract class InputService2 : IInputService2
    {
        public abstract void AddForce(ref Rigidbody rigidbody, Vector3 moveVec, float speed);

        public abstract float AxisTorque { get; }

        public abstract Quaternion Rotate(float thrust);

        public bool IsAttackButtonUp()
        {
            return true;
        }
    }

    class InputService2Impl : InputService2
    {
        private float _yRotation;
        public override void AddForce(ref Rigidbody _rigidbody, Vector3 moveVec, float speed)
        {
            _rigidbody.AddRelativeForce(moveVec * speed);   
        }

        public override float AxisTorque
        {
            get
            {
                float axis = UnityEngine.Input.GetAxisRaw("Horizontal");
                return axis;
            }
        }

        public override Quaternion Rotate(float _turnThrust)
        {
            var quater = Quaternion.Euler(0,0,0);
            
                float rotate = AxisTorque * Time.deltaTime * _turnThrust;
                _yRotation += rotate;
                quater = Quaternion.Euler(0, _yRotation, 0);
                return quater;
            
        }
    }
}