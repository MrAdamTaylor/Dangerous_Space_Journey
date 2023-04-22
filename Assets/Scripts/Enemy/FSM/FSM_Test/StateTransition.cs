using System;
using Enemy.FSM.FSM_Test.Conditions;

namespace Enemy.FSM.FSM_Test
{
    [Serializable]
    public class StateTransition 
    {
        public string _toStateName;
        public ConditionTransition _condition;
    }
    
    
}