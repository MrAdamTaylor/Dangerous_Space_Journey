using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestExp : MonoBehaviour
{
    private Transform meeple;
    private List<Transform> _childsTransforms = new List<Transform>();
    private int childCount;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                meeple = gameObject.transform.GetChild(i);
                Debug.Log($"Чилдрен! {meeple.name}");
                _childsTransforms.Add(meeple.transform); 
                //meeple.gameObject.AddComponent<Rigidbody>();
                //meeple.transform.parent = null;
                meeple = null;
            }
            //this.gameObject.SetActive(false);

            for (int i = 0; i < _childsTransforms.Count; i++)
            {
                _childsTransforms[i].transform.parent = null;
                _childsTransforms[i].transform.gameObject.AddComponent<Rigidbody>();
            }
            this.gameObject.SetActive(false);
        }
        Debug.Log($"Количество осколков {_childsTransforms.Count}");
    }
}
