using System;

namespace Test.FSM.Boxing_And_Unboxing_Remember.Observable
{
    public interface IObserver : IDisposable
    {
        void AddObservable(IObservable observable);
    }
}