using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public int health;
    public void TakeDamege(int dmg)
    {
        health -= dmg;
        if (health < 1)
        {
            Destroy(gameObject);
        }
    }
}
