using UnityEngine;

namespace Test.FSM.FSM_Test
{
    class ConditionTransition_OInput : ConditionTransition
    {
        public override bool Condition()
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                Debug.Log("Выполнено условие нажатия клавишы O");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}