using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestExp : MonoBehaviour
{
    private Transform meeple;
    [HideInInspector] public List<Transform> _childsTransforms = new List<Transform>();
    private int childCount;
    private ExplosionEffect _explosionEffect;
    private List<SmokeCreater> _smokeParts = new List<SmokeCreater>();

    private void Awake()
    {
        _explosionEffect = gameObject.GetComponent<ExplosionEffect>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                meeple = gameObject.transform.GetChild(i);
                //Debug.Log($"Чилдрен! {meeple.name}");
                _childsTransforms.Add(meeple.transform);
                SmokeCreater _smoke = meeple.GetComponent<SmokeCreater>();
                _smokeParts.Add(_smoke);
                meeple = null;
                _smoke = null;
            }

            for (int i = 0; i < _childsTransforms.Count; i++)
            {
                _childsTransforms[i].transform.parent = null;
                _childsTransforms[i].transform.gameObject.AddComponent<Rigidbody>();
                //_smokeParts[i].EffectCreate();
            }
            _explosionEffect.ExplosionEffectCreate();
            this.gameObject.SetActive(false);
        }
    }
}
