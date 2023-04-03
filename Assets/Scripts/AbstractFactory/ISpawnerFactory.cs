using UnityEngine;

namespace AbstractFactory
{
    public interface ISpawnerFactory
    {
        IUnit SpawnUnit();
        IInteractableObject spawnInteractableObject();
        IUnit SpawnPlayer();
        GameObject SpawnSpecialEffect(string path);
    }
}