using System;

namespace Test.FSM.FSM_Test
{
    [Serializable]
    public class StateTransition 
    {
        public string _toStateName;
        public ConditionTransition _condition;
    }
    
    
}