using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {//это базовый скрипт врага
    public float visionDistance;//область, в пределах которой враг видит игрока
    public float attackDistance;//область атаки
    public float fleeDistance;//если игрок слишком близко, убегать
    public float reloadTime;
    public float reloadingTimer;
    public GameObject player;
    public Rigidbody rb;
	public bool isSleeping;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        reloadingTimer = reloadTime;
        player = GameObject.FindWithTag("Player");
    }
	void Update () {
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
            if (distance < fleeDistance)
            {
                Flee();
            }
            if (reloadingTimer < reloadTime)
            {
                reloadingTimer += Time.deltaTime;
            }
        }
	}
	public void WakeUp(){
		isSleeping = false;
	}

    public virtual void Move() { }
    public virtual void Attack(){}
    public virtual void Flee(){}
}
