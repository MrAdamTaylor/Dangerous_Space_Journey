using System;

namespace Enemy.FSM.Boxing_And_Unboxing_Remember.Observable
{
    public interface IObserver : IDisposable
    {
        void AddObservable(IObservable observable);
    }
}