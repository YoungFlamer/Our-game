using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2;
    public float range = 20;
    public DamageData damage;
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
}