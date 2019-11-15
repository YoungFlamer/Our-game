using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEnterer : MonoBehaviour
{
	public string roomTag;
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == roomTag){
			col.gameObject.GetComponent<EnemyInRoomGenerator>().SpawnEnemies();
		}
	}
}
