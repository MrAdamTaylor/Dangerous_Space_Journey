using System.Collections.Generic;
using UnityEngine;

namespace Test.FSM.Boxing_And_Unboxing_Remember.Observable
{
    public class ObservableLogger : IObserver
    {
        private List<IObservable> _observables;

        public ObservableLogger()
        {
            _observables = new List<IObservable>();
        }

        public ObservableLogger(IObservable observable)
        {
            _observables = new List<IObservable> { observable};
            observable.OnChanged += OnChanged;
        }

        public ObservableLogger(IObservable[] observables)
        {
            _observables = new List<IObservable>(observables);
            foreach (var observable in _observables)
            {
                observable.OnChanged += OnChanged;
            }
        }

        public void Dispose()
        {
            foreach (var observable in _observables)
            {
                observable.OnChanged -= OnChanged;
            }
        }

        public void AddObservable(IObservable observable)
        {
            if(_observables.Contains(observable))
                return;
            
            _observables.Add(observable);
            observable.OnChanged += OnChanged;
        }

        private void OnChanged(object obj)
        {
            Debug.Log($"{obj.GetType().Name} value changed. New Value: {obj.ToString()}");
        }
    }
}