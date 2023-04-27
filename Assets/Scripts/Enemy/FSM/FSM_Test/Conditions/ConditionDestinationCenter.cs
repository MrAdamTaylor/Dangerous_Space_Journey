using System.Collections;
using System.Collections.Generic;
using Enemy.FSM.FSM_Test.Conditions;
using UnityEngine;

public class ConditionDestinationCenter : ConditionTransition
{
    private Vector3 center;
    
    public override bool Condition()
    {
        center = new Vector3(0, 0, transform.position.z);
        if (Vector3.Distance(transform.position, center) < 2f)
        {
            Debug.Log("Приближение");
            return true;
        }
        else
        {
            return false;
        }
    }
}
