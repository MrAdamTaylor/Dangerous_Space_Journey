using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipBus
{
    class UnstakSpecialEffectAdder : UnstakAdder
    {
        private ApartUnstaker _apparts;
        [SerializeField] private SpecialEffectCreater _effectCreater;
        private List<SpecialEffectCreater> _partsEffect = new List<SpecialEffectCreater>();

        private void Awake()
        {
            _apparts = gameObject.GetComponent<ApartUnstaker>();
        }

        private void AddSpecialEffect()
        {
            for (int i = 0; i < _apparts._childsTransforms.Count; i++)
            {
                _partsEffect[i].EffectCreate();
            }
        }

        private void ReadySpecialEffects()
        {
            for (int i = 0; i < _apparts._childsTransforms.Count; i++)
            {
                SpecialEffectCreater effect = gameObject.GetComponent<SpecialEffectCreater>();
                _partsEffect.Add(effect);
                effect = null;
            }
        }

    }
}