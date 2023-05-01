using SpaceShipBus;
using UniRx;
using UnityEngine;

public class Death : MonoBehaviour
{
    private UnstakForceAdder _unstakForceAdder;
    private UnstakRigidBodyAdder _unstakRigidBodyAdd;
    private ApartUnstaker _appartUnstacker;
    private UnstakSpecialEffectAdder _appartSpecialEffectAdder;
    private UnstackBoxColliderAdder _unstackBoxColliderAdder;
    private ExplosionEffect _explosionEffect;

    private bool isUnstack;
    private bool isUnstackForce;
    private bool isUnstackRigidBody;
    private bool isSpecialEffect;
    private bool isBoxCollider;
    private bool isExplosion;

    private void Awake()
    {
        CheckAppartUnstacker();
    }

    public BoolReactiveProperty IsDead { get; } = new BoolReactiveProperty();

    private void CheckAppartUnstacker()
    {
        if (gameObject.GetComponent<ApartUnstaker>() != null)
        {
            _appartUnstacker = gameObject.GetComponent<ApartUnstaker>();
            isUnstack = true;
            CheckBoxColliderComponent();
            CheckAppartsRigidBodyComponent();
            CheckSpecialEffectComponent();
            CheckExplosionEffect();
        }
        else
        {
            isUnstack = false;
        }
    }

    private void CheckExplosionEffect()
    {
        if (gameObject.GetComponent<ExplosionEffect>() != null)
        {
            _explosionEffect = gameObject.GetComponent<ExplosionEffect>();
            
            isExplosion = true;
        }
        else
        {
            isExplosion = false;
        }
    }

    private void CheckBoxColliderComponent()
    {
        if (gameObject.GetComponent<UnstackBoxColliderAdder>() != null)
        {
            _unstackBoxColliderAdder = gameObject.GetComponent<UnstackBoxColliderAdder>();
            
            isBoxCollider = true;
        }
        else
        {
            isBoxCollider = false;
        }
    }

    private void CheckSpecialEffectComponent()
    {
        if (_appartSpecialEffectAdder != null)
        {
            _appartSpecialEffectAdder.enabled = false;
            isSpecialEffect = true;
        }
        else
        {
            isSpecialEffect = false;
            //Debug.Log("Нет пробития!");
        }
    }

    private void CheckAppartsRigidBodyComponent()
    {
        if (gameObject.GetComponent<UnstakRigidBodyAdder>() != null)
        {
            _unstakRigidBodyAdd = gameObject.GetComponent<UnstakRigidBodyAdder>();
            
            isUnstackRigidBody = true;
        }
        else
        {
            isUnstackRigidBody = false;
        }
    }

    public void Safety()
    {
        //Debug.Log("Безопасность!");
    }

    public void Die()
    {
        //Debug.Log("Смерть!");
        
        if (isUnstack && !IsDead.Value)
        {
            _appartUnstacker.GetSpliters();
            _appartUnstacker.Unstack();

            if (isBoxCollider)
            {
                _unstackBoxColliderAdder.AddBoxCollider();
            }

            if (isUnstackRigidBody)
            {
                _unstakRigidBodyAdd.AddRigidBody();
            }

            IsDead.Value = true;
            _explosionEffect.ExplosionEffectCreate();
            this.gameObject.SetActive(false);
        }
    }

}