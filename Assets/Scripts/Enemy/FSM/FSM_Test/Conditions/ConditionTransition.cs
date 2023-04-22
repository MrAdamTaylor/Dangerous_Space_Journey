using UnityEngine;

namespace Enemy.FSM.FSM_Test.Conditions
{
    public abstract class ConditionTransition : MonoBehaviour
    {
        public abstract bool Condition();
    }
}