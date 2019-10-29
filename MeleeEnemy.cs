using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy {
    public float speed;
    public int damage;
    override public void Move()
    {
        transform.LookAt(player.transform.position);
        rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
    }
    public override void Attack()
    {
        player.GetComponent<Health>().TakeDamege(damage);
    }
}
