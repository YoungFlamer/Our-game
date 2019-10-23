using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public int health;
	public bool canBeHurt;
    public void TakeDamege(int dmg)
    {
		if (!canBeHurt) {
			return;
		}
        health -= dmg;
        if (health < 1)
        {
            Destroy(gameObject);
        }
    }
}
