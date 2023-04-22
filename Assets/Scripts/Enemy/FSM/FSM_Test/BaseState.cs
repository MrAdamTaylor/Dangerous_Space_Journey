namespace Enemy.FSM.FSM_Test
{
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
}