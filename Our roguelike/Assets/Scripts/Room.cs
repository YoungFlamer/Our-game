using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {
	public GameObject[] enemyPrefabs;
	public Transform[] enemySpawnPoints;
	public List <GameObject> enemies;
	public bool isPlayerFightingEnemies;
	public GameObject walls;
	// Use this for initialization
	void Start () {
		SpawnEnemies ();
	}
	
	// Update is called once per frame
	void Update () {
		CheckDoorOpening ();
	}
	public void OnRoomEnter(){
		walls.SetActive (true);
		isPlayerFightingEnemies = true;
		for (int i = 0; i < enemies.Count; i++) {
			enemies[i].GetComponent<Enemy> ().WakeUp ();
		}
	}
	void SpawnEnemies(){
		walls.SetActive (false);
		for (int i = 0; i < enemySpawnPoints.Length; i++) {
			int rand = Random.Range (0, enemyPrefabs.Length);
			GameObject enemy = Instantiate (enemyPrefabs [rand], enemySpawnPoints [i].position, Quaternion.identity) as GameObject;
			enemies.Add (enemy);
		}
	}
	void CheckDoorOpening(){
		ClearEnemyList ();
		if (isPlayerFightingEnemies) {
			if (enemies.Count == 0) {
				walls.SetActive (false);
				isPlayerFightingEnemies = false;
			}
		}
	}
	void ClearEnemyList(){
		for (int i = 0; i < enemies.Count; i++) {
			if (enemies [i] == null) {
				enemies.RemoveAt (i);
			}
		}
	}
}
