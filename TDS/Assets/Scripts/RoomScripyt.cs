using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScripyt : MonoBehaviour
{
    
    public Vector3 offset;
    public GameObject player;

    void OnTriggerEnter(Collider other)
    {
        // todo: check the player

        player = GameObject.FindWithTag("MainCharacter");
        if(player == other.gameObject)
        {
            Camera.main.transform.position = transform.position + offset;
        }
    }

}
