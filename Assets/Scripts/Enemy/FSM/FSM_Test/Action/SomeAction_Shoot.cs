using UnityEngine;

namespace Enemy.FSM.FSM_Test.Action
{
    class SomeAction_Shoot : SomeAction
    {
        private void Update()
        {
        }

        public override void Execute()
        {
            Debug.Log("Я стреляю!");
        }
    }
}