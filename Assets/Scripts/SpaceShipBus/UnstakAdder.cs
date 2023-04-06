using UnityEngine;

namespace SpaceShipBus
{
    [RequireComponent(typeof(ApartUnstaker))]
    public abstract class UnstakAdder : MonoBehaviour
    {
    
    }


    [RequireComponent(typeof(Rigidbody))]
    class UnstakForceAdder : UnstakAdder
    {
    
    }
}