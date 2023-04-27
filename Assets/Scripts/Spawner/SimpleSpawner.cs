using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawner: Spawner , IPosition
{
    [Tooltip("Ссылка на префаб астеройда!")]
    [SerializeField] private GameObject self;
    
    [Header("Смещение от осколков!")]
    [Tooltip("Минимальный диапозон осколков!")]
    [SerializeField] private float minRange = -5f;
    [Tooltip("Максимальный диапозон осколков")]
    [SerializeField] private float maxRange = 5f;
    
    public override Vector3 ReturnPosition()
    {
        float xOffset = Random.Range(minRange, maxRange);
            float yOffset = Random.Range(minRange, maxRange);
            Debug.Log($"Смещение по {xOffset} и по {yOffset }");

            return new Vector3(self.transform.position.x + xOffset,
                self.transform.position.y + yOffset, self.transform.position.z);
        
    }
}
