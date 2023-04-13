using UnityEngine;

namespace Test.FSM.FSM_Test
{
    public abstract class ConditionTransition : MonoBehaviour
    {
        public abstract bool Condition();
    }
}