using UnityEngine;

namespace Enemy.FSM.FSM_Test.Conditions
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