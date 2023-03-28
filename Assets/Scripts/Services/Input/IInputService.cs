using UnityEngine;

namespace Services.Input
{
    public interface IInputService
    { 
        float AxisMove { get; }
        float AxisTorque { get; }

        bool IsAttackButtonUp();
    }

    class InputServiceImplementation2 : IInputService
    {
        public float AxisMove { get; }
        public float AxisTorque { get; }
        public bool IsAttackButtonUp()
        {
            throw new System.NotImplementedException();
        }
    }
}