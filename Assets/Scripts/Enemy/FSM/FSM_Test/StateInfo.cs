using System;
using System.Collections.Generic;
using Enemy.FSM.FSM_Test.Action;
using UnityEngine;

namespace Enemy.FSM.FSM_Test
{
    [Serializable]
    public  class StateInfo
    {
        public string _stateName;
        public SomeAction _action;
        [SerializeField] public List<StateTransition> _stateTransitions = new List<StateTransition>();
        
    }
}