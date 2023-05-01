using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateOnDistance : MonoBehaviour
{
    [SerializeField] private float _minimalDistance;
    
    public bool CheckDistance(Transform enemy, Transform player)
    {
        if (Vector3.Distance(enemy.position, player.position) < _minimalDistance)
        {
            //Debug.Log($"Достигнута минимальная дистанция: " +
                     // $"{Vector3.Distance(enemy.position, player.position)}" );
            return true;
        }
        else
        {
            //Debug.Log("Куда пашёл? Сюда иди!");
            return false;
        }
    }
}
