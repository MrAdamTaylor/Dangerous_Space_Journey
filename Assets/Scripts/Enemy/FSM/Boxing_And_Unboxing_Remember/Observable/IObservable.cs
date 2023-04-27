using System;

namespace Enemy.FSM.Boxing_And_Unboxing_Remember.Observable
{
    public interface IObservable
    {
        event Action<object> OnChanged;

    }
}