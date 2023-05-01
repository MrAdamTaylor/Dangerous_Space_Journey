using System;
using System.Collections;
using System.Collections.Generic;
using AbstractFactory;
using Infrastructure;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class ShootToGoal : MonoBehaviour
{
    [SerializeField] private string _bulletPath;
    //[SerializeField] private GameObject _bullet;
    //[SerializeField] private GameObject _goal;
    [SerializeField] private float _maxDistance;
    [SerializeField] private LayerMask _attackingMask;
    [SerializeField] private List<Transform> _shootColliders = new List<Transform>();
    [SerializeField] private float shootingDelay;
    [SerializeField] private float _bulletSpeed;
    private float lastTimeShoot = 0f;
    private Color _color = Color.green;
    private ISpawnerFactory _bulletFactory;

    private void Start()
    {
        _bulletFactory = Game.Factory;
    }


    // Update is called once per frame
    void Update()
    {
        //Shoot();
    }

    public void Shoot()
    {
        Ray shootRay = new Ray(transform.position, -transform.up);
        int mask = 1 << LayerMask.NameToLayer("Ignore Raycast");
        mask |= 1 << _attackingMask;

        RaycastHit raycastHit;
        bool hit = Physics.Raycast(shootRay, out raycastHit, _maxDistance, mask);
        if (hit)
        {
            if (raycastHit.collider.gameObject.layer == LayerMask.NameToLayer("Ignore Raycast"))
            {
                Debug.DrawRay(transform.position, -transform.up * _maxDistance, Color.blue);
            }
            else
            {
                Debug.DrawRay(transform.position, -transform.up * _maxDistance, Color.red);
                if (Time.time > lastTimeShoot + shootingDelay)
                {
                    for (int i = 0; i < _shootColliders.Count; i++)
                    {
                        float speed = _bulletSpeed * Time.fixedDeltaTime;
                        Vector3 direction = -transform.up;
                        _bulletFactory.SpawnMovingObject(_bulletPath, _shootColliders[i], direction, speed);
                    }

                    lastTimeShoot = Time.time;
                }
            }
        }
    }
}
