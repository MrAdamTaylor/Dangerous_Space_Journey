using UnityEngine;

namespace Test.FSM.FSM_Test
{
    class SomeAction_Stay : SomeAction
    {
        public override void Execute()
        {
            Debug.Log("Я стою!");
        }
    }
}