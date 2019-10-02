using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy {
    public float speed;
    public int damage;
    override public void Move()
    {
        rb.MovePosition(Vector2.MoveTowards(rb.position, player.GetComponent<Rigidbody2D>().position, speed * Time.deltaTime));
    }
    public override void Attack()
    {
        player.GetComponent<Health>().TakeDamege(damage);
    }
}
