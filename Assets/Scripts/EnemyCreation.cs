using UnityEngine;

public class EnemyCreation : MonoBehaviour
{
    public GameObject[] Enemies;
	public Transform[] spawnPoints;
	public GameObject hero;
	public bool acted = false;
    
    void Start()
    {
		hero = GameObject.FindWithTag("MainCharacter");
    }

	void CreateEnemies(){
		int n = spawnPoints.Length;
		for (int i = 0; i < n; i++){
			int c = Random.Range(0, Enemies.Length - 1);
			GameObject enemyToSpawn = Enemies[c];
			Vector3 pos = spawnPoints[i].position;
			Instantiate(enemyToSpawn, pos, Quaternion.identity);
		}
		acted = true;
	}

	void Update(){
		if (!acted){
			CheckPlayerInRoom();
		}
	}

	void CheckPlayerInRoom(){
		float xDistance = hero.transform.position.x - transform.position.x;
		float zDistance = hero.transform.position.z - transform.position.z;
		if (Mathf.Abs(zDistance) < 15 || Mathf.Abs(xDistance) < 15){
			CreateEnemies();
		}
	}
}