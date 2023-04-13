using UnityEngine;

namespace Test.FSM.FSM_Test
{
    class SomeAction_Do : SomeAction
    {
        private void Update()
        {
        }

        public override void Execute()
        {
            Debug.Log("Я делаю!");
        }
    }
}