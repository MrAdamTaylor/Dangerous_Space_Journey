using Infrastructure;
using Services.AssertService;
using UnityEngine;

namespace AbstractFactory
{
    class LocalSpawnerFactory : ISpawnerFactory
    {

        private IAsserts _factoryAssert; 
        
        public LocalSpawnerFactory(IAsserts asserts)
        {
            _factoryAssert = asserts;
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

        public GameObject SpawnSpecialEffect(string path, Vector3 point)
        {
            /*var prefab = Resources.Load<GameObject>(path);
            return GameObject.Instantiate(prefab, point, Quaternion.identity);*/
            return _factoryAssert.Instantiate(path,point);
        }

        public GameObject SpawnBonus(string path, Vector3 place)
        {
            throw new System.NotImplementedException();
        }
    }
}