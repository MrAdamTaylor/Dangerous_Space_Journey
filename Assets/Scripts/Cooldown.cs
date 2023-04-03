using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Cooldown
{
   [SerializeField] private float cooldownTime;

    public float _nextTime; //Время завершения

    public bool IsCoolingDown => Time.time < _nextTime;
    public void StartCooldown() => _nextTime = Time.time + cooldownTime;
}
