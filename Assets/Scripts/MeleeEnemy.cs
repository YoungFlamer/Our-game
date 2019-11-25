using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    public float speed = 3f;
    private float reloadTime = 3f;
    public float damage = 25f;
    private float reloadingTimer;
    
    /* public void Update()
     {
         Move();
     }
     */
    public override void Start()
    {
        base.Start();

        reloadingTimer = reloadTime;
    }

    void Update()
    {
        if (player != null && !isSleeping)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);

            if (distance <= visionDistance && distance >= attackDistance)
            {
                Move();
            }
            if (distance <= attackDistance && reloadingTimer >= reloadTime)
            {
                Attack();
                reloadingTimer = 0;
            }
  
            if (reloadingTimer < reloadTime)
            {
                reloadingTimer += Time.deltaTime;
            }
        }
    }
    override public void Move()
    {
        transform.LookAt(player.transform.position);
        m_rigidbody.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
    }
    public override void Attack()
    {
        HeroDamageSystem dd = player.GetComponent<HeroDamageSystem>();
        dd.TakeDamage(DealDamage());
    }
    public DamageData DealDamage()
    {
         return new DamageData(damage, type);
       // else print("something wrong with Enemy.type");
       // return new DamageData();
    }
}
