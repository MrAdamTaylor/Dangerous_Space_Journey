using System;
using Infrastructure;
using Services.BorderService;
using UnityEngine;

namespace SpaceShipBus
{
    public class BorderHandler : MonoBehaviour
    {
        private IBorderChecker _borderService;
        private void OnEnable()
        {
            GlobalBus.Sync.Subscribe<GameControllerHandler>(Borders);
        }

        private void OnDisable()
        {
            GlobalBus.Sync.Unsubscribe<GameControllerHandler>(Borders);
        }

        private void Borders(object sender, EventArgs eventArgs)
        {
            _borderService = Game.BorderService;
            Vector3 _newPos = transform.position;
            _borderService.BorderCheck(ref _newPos);
            transform.position = _newPos;
        }
    }
}
