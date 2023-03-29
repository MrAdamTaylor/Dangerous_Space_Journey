using System;
using System.Collections;
using System.Collections.Generic;
using Infrastructure;
using Services.Input;
using UnityEngine;

public class ShootHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] lasers;

    private IInputServiceShoot _inputServiceShoot;
    
    private void OnEnable()
    {
        GlobalBus.Sync.Subscribe<GameControllerHandler>(Shoot);
    }

    private void OnDisable()
    {
        GlobalBus.Sync.Unsubscribe<GameControllerHandler>(Shoot);
    }

    private void Shoot(object sender, EventArgs e)
    {
        _inputServiceShoot = Game.InputServiceShoot;
        _inputServiceShoot.ProcessShootingBullet(lasers);
    }
}
