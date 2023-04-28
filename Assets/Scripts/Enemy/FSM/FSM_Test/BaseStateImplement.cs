using System.Collections.Generic;
using Enemy.FSM.FSM_Test.Action;
using UnityEngine;

namespace Enemy.FSM.FSM_Test
{
    class BaseStateImplement : BaseState
    {
        private string _stateName;
        private SomeAction _myAction;
        private List<StateTransition> _transitions;

        public BaseStateImplement()
        {
        }

        public BaseStateImplement(string name, NewStateMachine stateMachine, 
            SomeAction action, List<StateTransition> transitions) 
            : base(name, stateMachine)
        {
            _myAction = action;
            _transitions = transitions;
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();
            for (int i = 0; i < _transitions.Count; i++)
            {
                Debug.Log($"CurrentStateName {_stateName} to State name: {_transitions[i]._toStateName}, State value: {_transitions[i]._condition}");
                if (_transitions[i]._condition.Condition())
                {
                    _stateMachine.ChangeState(_transitions[i]._toStateName);
                }
            }
            //_myAction.ExecuteCoroutine();
        }

        public override void UpdatePhysics()
        {
            base.UpdatePhysics();
            _myAction.Execute();
        }

    }
}