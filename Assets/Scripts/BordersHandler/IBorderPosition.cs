using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBorderPosition : IPosition
{
    Vector3 LeftSpawn(float dir);

    Vector3 RightSpawn(float dir);

    Vector3 TopSpawn(float dir);

    Vector3 BottomSpawn(float dir);
}

