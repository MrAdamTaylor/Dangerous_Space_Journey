using System.Collections;
using System.Collections.Generic;
using Enemy.FSM.FSM_Test.Conditions;
using UnityEngine;

public class ConditionFollow : ConditionTransition
{
    [SerializeField] private TriggerObserver TriggerObserver;

    private bool _agroFlag;
    void Start()
    {
        TriggerObserver.TriggerEnter += EnemyDetection;
    }

    private void EnemyDetection(Collider obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            _agroFlag = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool Condition()
    {
        return _agroFlag;
    }
}
