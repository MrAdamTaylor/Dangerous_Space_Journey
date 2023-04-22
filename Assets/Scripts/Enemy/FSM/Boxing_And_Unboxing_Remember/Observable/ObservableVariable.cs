using System;

namespace Enemy.FSM.Boxing_And_Unboxing_Remember.Observable
{
    class ObservableVariable<T> : IObservable
    {
        public event Action<object> OnChanged;

        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                OnChanged?.Invoke(value);
            }
        }

        public ObservableVariable()
        {
            Value = default;
        }

        public ObservableVariable(T defaultValue)
        {
            Value = defaultValue;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}