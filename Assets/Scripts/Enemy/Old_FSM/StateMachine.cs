using UnityEngine;

namespace Enemy.Old_FSM
{
    public class StateMachine : MonoBehaviour
    {
        private BaseState _currentState;

        private void Start()
        {
            _currentState = GetInitialState();
            if (_currentState != null)
            {
                _currentState.Enter();
            }
        }

        protected virtual BaseState GetInitialState()
        {
            return null;
        }


        private void Update()
        {
            if (_currentState != null)
            {
                _currentState.UpdateLogic();
            }
        }

        private void LateUpdate()
        {
            if (_currentState != null)
            {
                _currentState.UpdatePhysics();
            }
        }

        public void ChangeState(BaseState newState)
        {
            _currentState.Exit();

            _currentState = newState;
            _currentState.Enter();
        }

        private void OnGUI()
        {
            string content = _currentState != null ? _currentState._name : "{No current state}";
            GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
        }
    }
}
