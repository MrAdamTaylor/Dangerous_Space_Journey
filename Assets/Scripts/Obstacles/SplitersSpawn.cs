using System;
using UnityEngine;

namespace Obstacles
{
    public class SplitersSpawn : MonoBehaviour
    {
        [SerializeField] private GameObject _splinter;
        [SerializeField] private int _splinterCount;
        private bool flag;

        private void OnEnable()
        {
            flag = true;
        }
        
        public void DestroyOnSplinters()
        {
            if (flag == true)
            {
                InstantiateSplinters();
            }

            gameObject.SetActive(false);
        }

        public void RecoveryObject()
        {
            gameObject.SetActive(true);
        }

        private void InstantiateSplinters()
        {
            for (int i = 0; i < _splinterCount; i++)
            {
                var part = Instantiate(_splinter, transform.position, Quaternion.identity);
                part.AddComponent<Rigidbody>();
                Debug.Log($"Позиция осколка {i} - {_splinter.transform.position}");
                flag = false;
            }
        }
    }
}