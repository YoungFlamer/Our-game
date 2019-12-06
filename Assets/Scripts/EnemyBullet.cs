using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
	public DamageData dd;
	public float speed;
	public float flyDistance;
    // Update is called once per frame
    void Update()
    {
		float s = speed * Time.deltaTime;
		flyDistance -= s;
		transform.Translate(transform.forward * s);
		if (flyDistance < 0){
			Destroy(gameObject);
		}
    }
	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "MainCharacter"){
			col.gameObject.GetComponent<HeroDamageSystem>().TakeDamage(dd);
		}
		Destroy(gameObject);
	}
}
