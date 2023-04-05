using System;
using System.Collections;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(ApartUnstaker))]
public abstract class UnstakAdder : MonoBehaviour
{
    
}


[RequireComponent(typeof(Rigidbody))]
class UnstakForceAdder : UnstakAdder
{
    
}

class UnstakRigidBodyAdder : UnstakAdder
{
    
}




