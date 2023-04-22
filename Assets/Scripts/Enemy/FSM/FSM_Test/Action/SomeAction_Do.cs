using UnityEngine;

namespace Enemy.FSM.FSM_Test.Action
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