using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

/*public struct DamageData
{
    public float Damage;
    //public bool AntiArmored;
  //  public float AntiArmoredModifier;

   /* public static DamageData GetUsualDamage(float damage)
    {
        DamageData dd = new DamageData();
        dd.Damage = damage;
        return dd;
    }
    }
    */


public class DamageSystem : MonoBehaviour//,characterInterface
{
	public float MaxHp  = 100f;
    public Action DeathEnemy;
    [HideInInspector]
    public float CurHp;
	//public float Armor  = 0f;
	
	public bool IsHero{ get; private set; }

	//void Awake()
	//{
	
		// check if player is hero


	//	var controller = GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter> ();
		//IsHero = controller != null;

//		IsRegenerating = false;
	//}

    public void Start()
    {
        CurHp = MaxHp;
        DeathEnemy += RoomScript.room_instance.MinusEnemiesAlive;

    }

    void DeathOfEnemy()
	{
        DeathEnemy();
		Destroy(gameObject);

	}
	

	public void TakeDamage(DamageData damageData)
	{
        float damage = damageData.Damage;
        Element type = damageData.damageType;
        if(gameObject.tag == "FireEnemy")
        {
            switch (type)
            {
                case Element.Fire:
                    damage *= 0;
                    break;
                case Element.Ground:
                    damage *= 0;
                    break;
                case Element.Wind:
                    damage *= 0.5f;
                    break;
                case Element.Ice:
                    damage *= 1f;
                    break;

            }

        }

        if (gameObject.tag == "IceEnemy")
        {
            switch (type)
            {
                case Element.Fire:
                    damage *= 0;
                    break;
                case Element.Ground:
                    damage *= 0.5f;
                    break;
                case Element.Wind:
                    damage *= 1f;
                    break;
                case Element.Ice:
                    damage *= 0f;
                    break;

            }

        }

        if (gameObject.tag == "GroundEnemy")
        {
            switch (type)
            {
                case Element.Fire:
                    damage *= 1f;
                    break;
                case Element.Ground:
                    damage *= 0f;
                    break;
                case Element.Wind:
                    damage *= 0f;
                    break;
                case Element.Ice:
                    damage *= 0.5f;
                    break;

            }

        }

        if (gameObject.tag == "WindEnemy")
        {
            switch (type)
            {
                case Element.Fire:
                    damage *= 0.5f;
                    break;
                case Element.Ground:
                    damage *= 1f;
                    break;
                case Element.Wind:
                    damage *= 0f;
                    break;
                case Element.Ice:
                    damage *= 0f;
                    break;

            }

        }


        //float damageToArmorMofifier = damageData.AntiArmored ? damageData.AntiArmoredModifier : 1;
        //float ConsumedDamageToArmor = Mathf.Min (Armor, damage*damageToArmorMofifier);

        //Armor   -= ConsumedDamageToArmor;
        //damage  -= ConsumedDamageToArmor / damageToArmorMofifier;

        CurHp -= damage;
		if (CurHp <= 0)
			OnDeath ();
	}

   

	void OnDeath()
	{
		//if (IsHero)
		//	DeathOfHero ();
		//else
			DeathOfEnemy ();
	}
	/*void DoDamage()
	{
		TakeDamage (10f);
	}
	*/
}

