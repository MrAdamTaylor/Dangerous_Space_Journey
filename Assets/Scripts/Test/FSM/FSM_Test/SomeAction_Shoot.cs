using UnityEngine;

namespace Test.FSM.FSM_Test
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