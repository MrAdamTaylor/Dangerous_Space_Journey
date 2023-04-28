using UnityEngine;

namespace Enemy.FSM.FSM_Test.Action
{
    class SomeAction_Stay : SomeAction
    {
        public override void Execute()
        {
            Debug.Log("Я стою!");
        }

        public override void ExecuteCoroutine()
        {
        }
    }
}