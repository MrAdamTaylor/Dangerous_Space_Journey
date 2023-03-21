using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace Services.Input
{
    class InputServiceImpl : InputService
    {
        public Vector3 _movementVector;

        public override bool Checking(float cordinates)
        {
            if (cordinates > 20f)
                return true;
            else
                return false;
        }

        public override float AxisMove
        {
            get
            {
                float axis = UnityEngine.Input.GetAxis("Vertical");
                return axis;
            }
        }

        public override float AxisTorque
        {
            get
            {
                float axis = UnityEngine.Input.GetAxis("Horizontal");
                return axis;
            }

        }
    }
}