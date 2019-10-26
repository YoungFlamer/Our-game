using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrightPosition : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject startpref = GameObject.Find("AbstractLevelGeneration");
    LevelGeneration level;
    void Start()
    {
        level = startpref.GetComponent<LevelGeneration>();
        transform.position = level.intersectionRooms[1].transform.position + new Vector3(10,0,10);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
