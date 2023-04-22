using UnityEngine;

namespace Enemy.FSM.FSM_Test.Action
{
    public abstract class SomeAction : MonoBehaviour
    {
        public abstract void Execute();
    }

    class MoveToBorder : SomeAction
    {
        public override void Execute()
        {
            
        }
    }
}