using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpecialEffectService
{
    public GameObject InstantiateEffect(GameObject effect,Transform attachedObject);
}

class SpecialEffectService : ISpecialEffectService
{
    public GameObject InstantiateEffect(GameObject effect,Transform attachedObject)
    {
        effect = GameObject.Instantiate(effect, attachedObject.position, attachedObject.rotation) as GameObject;
        return effect;
    }
}
