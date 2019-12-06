using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy
{
	public float speed;
	public float reloadTime;
	private float reloadingTimer;
	public GameObject projectile;
	public Transform firePoint;
    // Start is called before the first frame update
    public override void Start()
    {
		base.Start();
    }

    // Update is called once per frame
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
	public override void Attack(){
		transform.LookAt(player.transform.position);
		GameObject d = Instantiate (projectile, firePoint.position, Quaternion.identity);
		d.transform.LookAt (player.transform.position);

	}
	override public void Move()
	{
		transform.LookAt(player.transform.position);
		m_rigidbody.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
	}
}
