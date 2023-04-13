using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Test.FSM.FSM_Test
{
    public class NewStateMachine : MonoBehaviour
    {
        [SerializeField] protected string _currentStateName;
        private BaseState _currentState;
    
        private BaseState tempState;


        [SerializeField] protected List<StateInfo> _stateInfoArray = new List<StateInfo>();

        protected Dictionary<string, BaseState> states = new Dictionary<string, BaseState>();

        private void Awake()
        {
            for (int i = 0; i < _stateInfoArray.Count; i++)
            {
                tempState = new BaseStateImplement(_stateInfoArray[i]._stateName, 
                    this, _stateInfoArray[i]._action, _stateInfoArray[i]._stateTransitions);
                states.Add(_stateInfoArray[i]._stateName,tempState);
            }
        }

        private void Start()
        {
            if (_currentState != null)
            {
                _currentState.Enter();
            }

            GetInitialState();
        }
    
        private void Update()
        {
            //GetInitialState();
        
            if (_currentState != null)
            {
                _currentState.UpdateLogic();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                for (int i = 0; i < states.Count; i++)
                {
                    Debug.Log($"Key: {states.ElementAt(i).Key}, Value: {states.ElementAt(i).Value._name}");
                }
            }
        }

        private void LateUpdate()
        {
            if (_currentState != null)
            {
                _currentState.UpdatePhysics();
            }
        }

        public void ChangeState(string KeyName)
        {
            _currentState.Exit();
            if (states.TryGetValue(KeyName, out _currentState))
            {
                _currentState.Enter();
            }
            else
            {
                throw new Exception("Состояние не найдено");
            }
            //_currentState = newState;
        }
    
        protected virtual BaseState GetInitialState()
        {
            //BaseState currentAwakeState = new BaseStateImplement();
        
            if (states.TryGetValue(_currentStateName, out _currentState))
            {
                return _currentState;
            }
            else
            {
                return null;
            }
        }
    
        private void OnGUI()
        {
            string content = _currentState != null ? _currentState._name : "{No current state}";
            GUILayout.Label($"<color='black'><size=120>{content}</size></color>");
        }
    }

    /*public class EnemyStateMachine : NewStateMachine
    {

    
        public void Awake()
        {
        
        }

        public void Update()
        {
        
        }
        
        
    }*/

    public class BaseState
    {
        public string _name;
        protected NewStateMachine _stateMachine;

        public BaseState()
        {
        }

        public BaseState(string name, NewStateMachine stateMachine)
        {
            this._name = name;
            this._stateMachine = stateMachine;
        }

        public virtual void Enter()
        {
        }

        public virtual void UpdateLogic()
        {
        }

        public virtual void UpdatePhysics()
        {
        
        }

        public virtual void Exit()
        {
        }
    }

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
        }

        public override void UpdatePhysics()
        {
            base.UpdatePhysics();
            _myAction.Execute();
        }

    }
}