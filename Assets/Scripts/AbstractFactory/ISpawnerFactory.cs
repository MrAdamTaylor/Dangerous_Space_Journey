using UnityEngine;

namespace AbstractFactory
{
    public interface ISpawnerFactory
    {
        //IUnit SpawnUnit();
        //IInteractableObject spawnInteractableObject();
        //IUnit SpawnPlayer();
        GameObject SpawnSpecialEffect(string path, Vector3 point);

        GameObject SpawnBonus(string path, Vector3 place);
    }
}