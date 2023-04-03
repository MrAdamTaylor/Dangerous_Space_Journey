using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInstantiateControl : MonoBehaviour
{
    [SerializeField] private GameObject _distructableObject;
    private DistractionObject _distractionScenario;
    private AddSplittersForce _explosionForce;

    public bool TimeReady;
    public float TimeCD = 1.5f;
    public float TimeCurrent = 0f;
    
    void Awake()
    {
        _distractionScenario = _distructableObject.GetComponent<DistractionObject>();
        _explosionForce = _distructableObject.GetComponent<AddSplittersForce>();
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

        if (Input.GetKeyDown(KeyCode.F))
        {
            //TimeCurrent = 0.0f;
            //while (TimeCurrent < TimeCD)
            //{
                _explosionForce.AddExplosionRadius();
            //}
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _distractionScenario.DestroyOnSplinters();
            _explosionForce.AddExplosionRadius();
        }

        if (TimeCurrent >= TimeCD)
        {
            TimeReady = true;
        }
        else
        {
            TimeCurrent += Time.deltaTime;
            TimeReady = false;
            TimeCurrent = Mathf.Clamp(TimeCurrent, 0.0f, TimeCD);
        }
    }
}
