using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float timeBeforeDesroy;
    public int damage;
    void Start()
    {
        Destroy(gameObject, timeBeforeDesroy);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<Health>().TakeDamege(damage);
        }
        Destroy(gameObject);
    }

}
