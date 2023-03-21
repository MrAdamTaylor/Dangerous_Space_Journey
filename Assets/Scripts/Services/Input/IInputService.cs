using UnityEngine;

namespace Services.Input
{
    public interface IInputService
    { 
        float AxisMove { get; }
        float AxisTorque { get; }

        bool Checking(float cordinate);
        
        bool IsAttackButtonUp();

    }
}