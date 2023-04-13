using System;
using System.Collections.Generic;
using UnityEngine;

namespace Test.FSM.FSM_Test
{
    [Serializable]
    public  class StateInfo
    {
        public string _stateName;
        public SomeAction _action;
        [SerializeField] public List<StateTransition> _stateTransitions = new List<StateTransition>();
        
    }
}