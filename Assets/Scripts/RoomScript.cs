using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    // Start is called before the first frame update
  
    // Update is called once per frame
    public GameObject[] spawnPoints = new GameObject[4];

    private int EnemiesAlive = 0;

    public void OnTriggerEnter(Collider incomingObject)
    {
        if(incomingObject.gameObject.tag == "MainCharacter")
        {
            
            EnemyCreation.instance.CreateEnemies(spawnPoints, out EnemiesAlive);

            var pc = incomingObject.gameObject.GetComponent<PlayerController>();
            if(pc!=null)
                pc.EnterRoom(this);
        }
    }
    public static float GetRoomX() => 30;
    public static float GetRoomZ() => 30;
    public GameObject[] getSpawnPoints() => spawnPoints;

    public bool IsRoomCleared() => EnemiesAlive == 0; 
}
