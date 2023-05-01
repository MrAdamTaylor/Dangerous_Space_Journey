using UnityEngine;

namespace AbstractFactory
{
    public interface ISpawnerFactory
    {
        GameObject SpawnSpecialEffect(string path, Vector3 point);

        GameObject SpawnBonus(string path, Vector3 place);

        GameObject SpawnMovingObject(string path, Transform position, 
            Vector3 direction, float speed);
    }
}