using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApartUnstaker : MonoBehaviour
{

    public List<Transform> _childsTransforms = new List<Transform>();
    private int childCount;

    private void GetSpliters()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Transform spliter = gameObject.transform.GetChild(i);
            _childsTransforms.Add(spliter.transform);
            spliter = null;
        }
    }

    private void Unstack()
    {
        for (int i = 0; i < _childsTransforms.Count; i++)
        {
            _childsTransforms[i].transform.parent = null;
        }
    }
}
