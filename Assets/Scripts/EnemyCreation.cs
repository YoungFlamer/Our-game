using UnityEngine;

public class EnemyCreation : MonoBehaviour
{
    public GameObject[] Enemies;
	//private GameObject[] spawnPoints = new GameObject[4];
	//public GameObject hero;
	//public bool acted = false;
    private PlayerController heroPL;

    public static EnemyCreation instance;

    void Start()
    {
        //	hero = GameObject.FindWithTag("MainCharacter");
        //       heroPL = hero.GetComponent<PlayerController>();
        //        spawnPoints = heroPL.currentRoomLocation.getSpawnPoints();
        instance = this;
    }

	public void CreateEnemies(GameObject[] spawnPoints){
		int n = spawnPoints.Length;
      
        for (int i = 0; i < n; i++){
			int c = Random.Range(0, Enemies.Length - 1);
			GameObject enemyToSpawn = Enemies[c];
			Vector3 pos = spawnPoints[i].transform.position;
			Instantiate(enemyToSpawn, pos, Quaternion.identity);
           
        }
		//acted = true;
	}

/*	void Update(){
        if(heroPL.changedTheRoom == true)
        {
            CreateEnemies();
            heroPL.changedTheRoom = false;
        }
    }
    
	void CheckPlayerInRoom(){
		float xDistance = hero.transform.position.x - transform.position.x;
		float zDistance = hero.transform.position.z - transform.position.z;
		if (Mathf.Abs(zDistance) < 15 || Mathf.Abs(xDistance) < 15){
			CreateEnemies();
		}
	}*/
}