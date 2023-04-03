using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInstantiateControl : MonoBehaviour
{
    [SerializeField] private GameObject _distructableObject;
    private DistractionObject _distractionScenario;
    void Awake()
    {
        _distractionScenario = _distructableObject.GetComponent<DistractionObject>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            _distractionScenario.DestroyOnSplinters();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            _distractionScenario.RecoveryObject();
        }
    }
}
