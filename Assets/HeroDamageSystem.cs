using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void OnDeath()
    {

        if (HeroHp <= 0) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
