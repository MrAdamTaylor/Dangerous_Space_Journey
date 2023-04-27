using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BorderSpawner : Spawner, IBorderPosition
{
    [Header("Диапозон значений для Y")]
    [SerializeField] private float minYRange = 73f;
    [SerializeField] private float maxYRange = 77f;
    
    [Header("Диапозон значений для X")]
    [SerializeField] private float minXRange = 105f;
    [SerializeField] private float maxXRange = 110f;

    private void OnEnable()
    {
        ReturnPosition();
    }

    public override Vector3 ReturnPosition()
    {
        Vector3 currentPosition = Vector3.zero;
        float xOffset = Random.Range(minXRange, minXRange);
        float yOffset = Random.Range(minYRange, maxYRange);   
        int side = Random.Range(0, 3);
        
            switch(side)
            {
                case 0:
                    currentPosition = LeftSpawn(-xOffset);
                    break;
                case 1:
                    currentPosition = RightSpawn(xOffset);
                    break;
                case 2:
                    currentPosition = TopSpawn(yOffset);
                    break;
                case 3:
                    currentPosition = BottomSpawn(-yOffset);
                    break;
            }
            return currentPosition;
    }
    
    public Vector3 BottomSpawn(float direction)
    {
        float xRange = Random.Range(-maxXRange, maxXRange);
        return new Vector3(xRange,direction,0);
    }

    public Vector3 TopSpawn(float direction)
    {
        float xRange = Random.Range(-maxXRange, maxXRange);
        return new Vector3(xRange,direction,0);
    }

    public Vector3 RightSpawn(float direction)
    {
        float yRange = Random.Range(-maxYRange, maxYRange);
        return new Vector3(direction,yRange,0);
    }

    public Vector3 LeftSpawn(float direction)
    {
        float yRange = Random.Range(-maxYRange, maxYRange);
        return new Vector3(direction,yRange,0);
    }
}
