using UnityEngine;

namespace Test.FSM.FSM_Test
{
    class ConditionTransition_KInput : ConditionTransition
    {
        public override bool Condition()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                Debug.Log("Выполнено условие нажатия клавишы K");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}