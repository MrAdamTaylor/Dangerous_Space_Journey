using Services.AssertService;
using UnityEngine;

namespace AbstractFactory
{
    class LocalSpawnerFactory : ISpawnerFactory
    {

        private IAsserts _factoryAssert; 
        
        public LocalSpawnerFactory(IAsserts _assert)
        {
            _factoryAssert = _assert;
        }

        public IUnit SpawnUnit()
        {
            var go = new GameObject("Unit(LOCAL)");
            var unit = go.AddComponent<Unit>();
            return unit;
        }

        public IInteractableObject spawnInteractableObject()
        {
            var go = new GameObject("InteractableObject (LOCAL)");
            var io = go.AddComponent<InteractableObject>();
            return io;
        }

        public IUnit SpawnPlayer()
        {
            var go = new GameObject("Player (LOCAL)");
            var unit = go.AddComponent<Unit>();
            var player = go.AddComponent<Player>();
            return unit;
        }

        public GameObject SpawnSpecialEffect(string path)
        {
            /*var prefab = Resources.Load<GameObject>(path);
            var rig = prefab.AddComponent<Rigidbody>();
            return GameObject.Instantiate(prefab);*/

            GameObject prefab = _factoryAssert.Instantiate(path);
            var rig = prefab.AddComponent<Rigidbody>();
            return prefab;
        }
    }
}