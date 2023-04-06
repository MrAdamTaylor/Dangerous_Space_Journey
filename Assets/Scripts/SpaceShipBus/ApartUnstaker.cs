using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipBus
{
    public class ApartUnstaker : MonoBehaviour
    {

        [HideInInspector] public List<Transform> _childsTransforms = new List<Transform>();
        private int childCount;

        public void GetSpliters()
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                Transform spliter = gameObject.transform.GetChild(i);
                _childsTransforms.Add(spliter.transform);
                spliter = null;
            }
        }

        public void Unstack()
        {
            for (int i = 0; i < _childsTransforms.Count; i++)
            {
                _childsTransforms[i].transform.parent = null;
            }
        }
    }
}
