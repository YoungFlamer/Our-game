using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(DamageSystem))]
public class Enemy :  MonoBehaviour
{//это базовый скрипт врага
    public float visionDistance = 5 ;//область, в пределах которой враг видит игрока
    public float attackDistance = 2f;//область атаки
    
    public Element type;


    public GameObject player;
    public Rigidbody m_rigidbody;
    public bool isSleeping;

    private DamageSystem m_damageSystem;

    public virtual void Start()
    {
        m_rigidbody = gameObject.GetComponent<Rigidbody>();
        m_damageSystem = GetComponent<DamageSystem>();
        
        player = GameObject.FindWithTag("MainCharacter");
    }


    public virtual void Move() { }
    public virtual void Attack() { }

    //public virtual void DealDamage() { }

    public void OnCollisionEnter( Collision collision)
    {
       
        GameObject collisionObject = collision.gameObject;
        
        if (collisionObject.tag == "Bullet")
        {

            Bullet bullet = collisionObject.GetComponent<Bullet>(); 
            m_damageSystem.TakeDamage(bullet.damage);
            Destroy(collisionObject);
        }
    }
}