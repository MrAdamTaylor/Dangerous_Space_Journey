using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Test.FSM.Boxing_And_Unboxing_Remember.Observable
{
    //Observable - объект за которым следят
    public class ObservableExample : MonoBehaviour
    {
        private ObservableVariable<int> _observableVariableInt;
        private ObservableVariable<bool> _observableVariableBool;
        private ObservableLogger _logger;

        private void Start()
        {
            _observableVariableInt = new ObservableVariable<int>(10);
            _observableVariableBool = new ObservableVariable<bool>(false);
            _logger = new ObservableLogger(_observableVariableInt);
            _logger.AddObservable(_observableVariableBool);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                RandomizeInt();
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                InvertBool();
            }
        }

        private void RandomizeInt()
        {
            var rInt = Random.Range(0, 100);
            _observableVariableInt.Value = rInt;
        }

        private void InvertBool()
        {
            _observableVariableBool.Value = !_observableVariableBool.Value;
        }
    }
}