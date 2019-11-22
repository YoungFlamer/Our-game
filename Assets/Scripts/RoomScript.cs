using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{

    public Vector3 offset;
    GameObject startpref;
    private void Start()
    {
        startpref = GameObject.Find("ThirdPersonController");
         
        WrightPosition character = startpref.GetComponent<WrightPosition>();
        transform.position = character.GetCharacterPosition() + offset;
    }
    public static float GetRoomX()
    {
        return 30;
    }

    public static float GetRoomZ()
    {
        return 30;
    }

    private void Update()
    {
		if (startpref != null){
            transform.position = startpref.transform.position + offset;
		}
    }

}