using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SpaceShipBus
{
    class UnstakSpecialEffectAdder : UnstakAdder
    {
        private ApartUnstaker _apparts;
        [SerializeField] private SpecialEffectCreater _effectCreater;
        [SerializeField] private TriggerObserver _triggerObserver;
        
        private bool isExecuted;

        private bool isOnceOperation = true;
        private List<SpecialEffectCreater> _partsEffect = new List<SpecialEffectCreater>();

        private void Awake()
        {
            _apparts = gameObject.GetComponent<ApartUnstaker>();
        }

        private void Start()
        {
            _triggerObserver.TriggerEnter += TriggerEnter;
            _triggerObserver.TriggerExit += TriggerExit;
        }

        private void TriggerExit(Collider obj)
        {

            if (isExecuted == false)
            {
                PrepareAndExecute();
            }
        }

        private void TriggerEnter(Collider obj)
        {
            //Debug.Log("Нет класса - пойдём!");
        }


        public void PrepareAndExecute()
        {
            if (_apparts._childsTransforms.Count != 0)
            {
                PrepareSpecialEffects();
                AddSpecialEffect();
                
            }
        }

        public void AddSpecialEffect()
        {
            for (int i = 0; i < _partsEffect.Count; i++)
            { 
                _partsEffect[i].EffectCreate();
            }
            
        }

        public void PrepareSpecialEffects()
        {
                 for (int i = 0; i < _apparts._childsTransforms.Count; i++)
                {
                    var _type = _effectCreater.GetType();
                    _apparts._childsTransforms[i].gameObject.AddComponent(_type);
                    SpecialEffectCreater effect = _apparts._childsTransforms[i].gameObject.GetComponent<SpecialEffectCreater>();//gameObject.GetComponent<SpecialEffectCreater>();
                    //_apparts._childsTransforms[i].gameObject.AddComponent<SpecialEffectCreater>();
                    _partsEffect.Add(effect);
                    effect = null;
                }
                 isExecuted = true;
        }
    }
}