using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDeath : MonoBehaviour
{
    public Death _death;
    public TriggerObserver TriggerObserver;

    private void Start()
    {
        TriggerObserver.TriggerEnter += TriggerEnter;
        TriggerObserver.TriggerExit += TriggerExit;
    }

    private void TriggerExit(Collider obj)
    {
        if (obj.gameObject.tag != "Player")
        {
            _death.Safety();
        }
    }

    private void TriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag != "Player")
        {
            _death.Die();
        }
    }
}