using UnityEngine;

namespace Services.Input
{
    public interface IInputService
    { 
        float AxisMove { get; }
        float AxisTorque { get; }
        
        
        bool IsAttackButtonUp();

    }
}