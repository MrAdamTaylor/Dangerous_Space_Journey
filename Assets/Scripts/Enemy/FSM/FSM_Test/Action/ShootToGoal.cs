using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ShootToGoal : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _goal;
    [SerializeField] private float _maxDistance;
    [SerializeField] private LayerMask _attackingMask;
    private Transform _pointer;
    private Color _color = Color.green;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Version1();

        Ray shootRay = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 20f, Color.blue);

        RaycastHit raycastHit;
        if (Physics.Raycast(shootRay, out raycastHit, _maxDistance, _attackingMask))
        {
            Debug.Log($"Имя попадаемого объекта: " + raycastHit.collider.gameObject.transform.name);
            //InfluenceOnOtherObjetc(raycastHit);
        }
        else
        {
            Debug.Log("Ничего нет!");
        }
    }

    private static void InfluenceOnOtherObjetc(RaycastHit raycastHit)
    {
        Selectable selectable = raycastHit.collider.gameObject.GetComponent<Selectable>();
        if (selectable)
        {
            selectable.Select();
        }
    }

    private void Version1()
    {
        Ray shootRay = new Ray(transform.position, transform.forward);
        //Debug.DrawRay(transform.position, transform.forward * 20f, _color);
        int mask = 1 << LayerMask.NameToLayer("Enemy");
        mask |= 1 << LayerMask.NameToLayer("Default");

        RaycastHit raycastHit;

        bool hit = Physics.Raycast(transform.position, transform.forward, out raycastHit, _maxDistance, mask);

        if (hit)
        {
            if (raycastHit.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                Debug.DrawRay(transform.position, transform.forward * 20f, Color.green);
                Debug.Log("Обнаружен союзник: ");
            }
            else
            {
                Debug.DrawRay(transform.position, transform.forward * 20f, Color.red);
                Debug.Log("Обнаружен противник: ");
            }
        }
    }
}
