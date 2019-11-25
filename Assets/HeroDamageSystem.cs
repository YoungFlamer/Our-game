using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroDamageSystem : MonoBehaviour
{
    public float HeroHp = 100f;
    
    

    // Update is called once per frame
    void Update()
    {
        OnDeath();
        
    }

    public void TakeDamage(DamageData dd)
    {
        HeroHp -= dd.Damage;
    }

    [System.Obsolete]
    public void OnDeath()
    {

        if (HeroHp <= 0) Application.LoadLevel(Application.loadedLevel);
    }
}
