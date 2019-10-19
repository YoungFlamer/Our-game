using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed;
    public int damage;
    public float range;
    void Update()
    {
        float f = speed * Time.deltaTime;
        transform.Translate(Vector3.forward * f);
        range -= f;
        if (range < 0)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<Health>().TakeDamege(damage);
        }
        Destroy(gameObject);
    }

}
