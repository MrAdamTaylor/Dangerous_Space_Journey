using UnityEngine;

namespace Enemy.FSM.FSM_Test.Conditions
{
    class ConditionTransition_LInput : ConditionTransition
    {
        public override bool Condition()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                Debug.Log("Выполнено условие нажатия клавишы L");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}