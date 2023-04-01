using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDestructible 
{
    public void InstanceExplosion();

    public void InstantiateExplosion();

    public void CreateExplosionPoint();

    public void CreateSplinters();

}
