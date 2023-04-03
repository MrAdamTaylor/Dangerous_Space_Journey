using UnityEngine;

namespace AbstractFactory
{
    class NetworkSpawnerFactory : ISpawnerFactory
    {
        public IUnit SpawnUnit()
        {
            var go = new GameObject("Unit(NET)");
            var unit = go.AddComponent<Unit>();
            go.AddComponent<NetworkBehaviour>();
            return unit;
        }

        public IInteractableObject spawnInteractableObject()
        {
            var go = new GameObject("InteractableObject (NET)");
            var io = go.AddComponent<InteractableObject>();
            go.AddComponent<NetworkBehaviour>();
            return io;
        }

        public IUnit SpawnPlayer()
        {
            var go = new GameObject("Player (NET)");
            var unit = go.AddComponent<Unit>();
            var player = go.AddComponent<Player>();
            go.AddComponent<NetworkBehaviour>();
            return unit;
        }

        public GameObject SpawnSpecialEffect(string path, Vector3 point)
        {
            var prefab = Resources.Load<GameObject>(path);
            return GameObject.Instantiate(prefab);
        }

        public GameObject SpawnBonus(string path, Vector3 place)
        {
            throw new System.NotImplementedException();
        }
    }
}