using UnityEngine;

namespace Enemy.FSM.FSM_Test.Action
{
    class SomeAction_Walk : SomeAction
    {
        private void Update()
        {
        }

        public override void Execute()
        {
            Debug.Log("Я хожу!");
        }

        public override void ExecuteCoroutine()
        {
        }
    }
}