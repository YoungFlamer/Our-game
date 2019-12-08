using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Vector3 offset;
    GameObject startpref;
    private void Start()
    {
        startpref = GameObject.Find("ThirdPersonController");
         
        WrightPosition character = startpref.GetComponent<WrightPosition>();
        transform.position = character.GetCharacterPosition() + offset;
    }


    private void Update()
    {
        transform.position = startpref.transform.position + offset;
    }

}