using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Enemy.FSM.FSM_Test
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
}