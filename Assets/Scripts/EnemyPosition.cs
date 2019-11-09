using UnityEngine;

public class EnemyPosition : MonoBehaviour
{

    void Start()
    {
        GameObject startpref = GameObject.Find("AbstractLevelGeneration");
        LevelGeneration level = startpref.GetComponent<LevelGeneration>();
        transform.position = level.GetSpawnPosition() + new Vector3(10, 0, 10);//level.intersectionRooms[1].transform.position + new Vector3(10,0,10);    
    }

    void Update()
    {

    }

    public Vector3 GetCharacterPosition()
    {
        return transform.position;
    }
}