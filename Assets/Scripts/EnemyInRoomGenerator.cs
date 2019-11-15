using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInRoomGenerator : MonoBehaviour
{
	public GameObject[] enemyPrefs;
	public Transform[] spawnPoints;
	public bool firstTime = true;
	public void SpawnEnemies(){
		if (firstTime){
		    for (int i = 0; i < spawnPoints.Length; i++){
			    Instantiate(enemyPrefs[Random.Range(0, enemyPrefs.Length - 1)], spawnPoints[i].position, Quaternion.identity);
		    }
			firstTime = false;
		}
	}
}
