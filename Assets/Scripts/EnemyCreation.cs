using UnityEngine;

public class EnemyCreation : MonoBehaviour
{
    public GameObject[] Enemies = new GameObject[4];
    
    void Start()
    {
        Random rand = new Random();
        int a = Random.Range(0, 4);
        GameObject Enemy = Instantiate(Enemies[a]);
       
        GameObject startpref = GameObject.Find("AbstractLevelGeneration");
        LevelGeneration level = startpref.GetComponent<LevelGeneration>();
        Enemy.transform.position = level.GetSpawnPosition() + new Vector3(-10, 10, -10);//level.intersectionRooms[1].transform.position + new Vector3(10,0,10);    
    }
}