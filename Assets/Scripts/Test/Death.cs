using System;
using SpaceShipBus;
using UnityEngine;

public class Death : MonoBehaviour
{
    private UnstakForceAdder _unstakForceAdder;
    private UnstakRigidBodyAdder _unstakRigidBodyAdd;
    private ApartUnstaker _appartUnstacker;

    private bool isUnstack;
    private bool isUnstackForce;
    private bool isUnstackRigidBody;
    
    private void Awake()
    {
        CheckAppartUnstacker();
    }

    private void CheckAppartUnstacker()
    {
        if (gameObject.GetComponent<ApartUnstaker>() != null)
        {
            _appartUnstacker = gameObject.GetComponent<ApartUnstaker>();
            isUnstack = true;

            CheckAppartsRigidBodyComponent();
        }
        else
        {
            isUnstack = false;
        }
    }

    private void CheckAppartsRigidBodyComponent()
    {
        if (gameObject.GetComponent<UnstakRigidBodyAdder>() != null)
        {
            _unstakRigidBodyAdd = gameObject.GetComponent<UnstakRigidBodyAdder>();
            isUnstackRigidBody = true;
        }
        else
        {
            isUnstackRigidBody = false;
        }
    }

    public void Safety()
    {
        Debug.Log("Безопасность!");
    }

    public void Die()
    {
        Debug.Log("Смерть!");
        if (isUnstack)
        {
            _appartUnstacker.GetSpliters();
            _appartUnstacker.Unstack();
            if (isUnstack)
            {
                _unstakRigidBodyAdd.AddRigidBody();
            }
        }
    }

}