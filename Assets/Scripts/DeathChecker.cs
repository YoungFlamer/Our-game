using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathChecker : MonoBehaviour
{
	public GameObject character;
	public GameObject deathText;
	private bool isHeroDead;
    // Start is called before the first frame update
    void Start()
    {
		isHeroDead = false;
		deathText.SetActive(false);
		character = GameObject.FindWithTag("MainCharacter");
    }

    // Update is called once per frame
    void Update()
    {
		if (character == null && !isHeroDead){
			isHeroDead = true;
			deathText.SetActive(true);
		}
    }
}
