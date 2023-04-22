using UnityEngine;

namespace Enemy.Old_FSM.States
{
    public class MoveState : BaseState
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
            if (Mathf.Abs(_horizontalInput) < Mathf.Epsilon)
            {
                _stateMachine.ChangeState(((MovementSM)_stateMachine)._idleState);
            }
            
        }
        
        public override void UpdatePhysics()
        {
            base.UpdatePhysics();
            Vector3 vel = ((MovementSM)_stateMachine)._rigidbody.velocity;
            vel.x = _horizontalInput * ((MovementSM)_stateMachine)._speed * Time.deltaTime;
        }

        public MoveState(MovementSM stateMachine) 
            : base("Move", stateMachine)
        {
        }
    }
}