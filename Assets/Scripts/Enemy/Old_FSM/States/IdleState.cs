using UnityEngine;

namespace Enemy.Old_FSM.States
{
    public class IdleState : BaseState
    {

        private float _horizontalInput;
        public override void Enter()
        {
            base.Enter();
            _horizontalInput = 0f;
        }


        public override void UpdateLogic()
        {
            base.UpdateLogic();
            _horizontalInput = Input.GetAxis("Horizontal");
            if (Mathf.Abs(_horizontalInput) > Mathf.Epsilon)
            {
                _stateMachine.ChangeState(((MovementSM)_stateMachine)._movingState);
            }
            // .transition to moving
            
        }

        public IdleState(MovementSM stateMachine) 
            : base("Idle", stateMachine)
        {
            
        }
    }
}