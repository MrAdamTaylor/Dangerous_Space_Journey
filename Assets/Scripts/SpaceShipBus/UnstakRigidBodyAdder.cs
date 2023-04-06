using UnityEngine;

namespace SpaceShipBus
{
    class UnstakRigidBodyAdder : UnstakAdder
    {
        private ApartUnstaker _aparts;

        private void Awake()
        {
            _aparts = gameObject.GetComponent<ApartUnstaker>();
        }

        public void AddRigidBody()
        {
            if (_aparts._childsTransforms.Count > 0)
            {
                for (int i = 0; i < _aparts._childsTransforms.Count; i++)
                {
                    _aparts._childsTransforms[i].gameObject.AddComponent<Rigidbody>();
                }
            }
        }
    }
}