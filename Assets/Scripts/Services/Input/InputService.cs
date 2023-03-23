using UnityEngine;

namespace Services.Input
{
    public abstract class InputService : IInputService
    {
        public abstract float AxisMove { get; }
        public abstract float AxisTorque { get; }

        public bool IsAttackButtonUp()
        {
            return true;
        }
    }
}