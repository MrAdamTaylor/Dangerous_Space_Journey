using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class ExplosionForce : MonoBehaviour
{
    [Tooltip("Ссылка на префаб астеройда!")]
    [SerializeField] protected GameObject self;

    [Header("Максимальное количество осколков и радиус взрыва")]    
    [SerializeField] protected int _maxHits = 25;
    [SerializeField] protected float _radius = 10f;
    
    [Header("Слой, который отталкивает взрыв")]
    [SerializeField] protected LayerMask _hitLayer;
    [FormerlySerializedAs("ExplosiveForce")]
    [Header("Сила взрыва")]
    [SerializeField] protected float _explosiveForce;

    [Range(2f, 5f)] [SerializeField] protected float _timeDuration = 2f;


    protected abstract void CreateExplosionForce();
}