using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayIsConditions : MonoBehaviour
{
    [Serializable]
    private class StateInfo
    {
        public string name;
        public SomeState _state;
    }

    [SerializeField] private List<StateInfo> _stateInfoArray = new List<StateInfo>();
    
}