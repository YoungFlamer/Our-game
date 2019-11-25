using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    float currentReloadTime;
    Element TypeofShotting = Element.Fire;
    public GameObject FireBullet;
    public GameObject IceBullet;
    public GameObject GroundBullet;
    public GameObject WindBullet;


    public float reloadTime;
    Dictionary<Element, GameObject> bullets = new Dictionary<Element,GameObject>(4);
    // public Transform gunPoint;
    private void Start()
    {
        bullets.Add(Element.Fire, FireBullet);
        bullets.Add(Element.Ice, IceBullet);
        bullets.Add(Element.Ground, GroundBullet);
        bullets.Add(Element.Wind, WindBullet);
    }

    private void Update()
    {
        Shoot();
        ChangeShotting();
    }
    void Shoot()
    {
        if (currentReloadTime > reloadTime)
        {
            if (Input.GetMouseButton(0))
            {
                GameObject go = Instantiate(bullets[TypeofShotting], transform.position, transform.rotation);
                currentReloadTime = 0;
                //Rotate();

                Bullet bullet = go.GetComponent<Bullet>();
                if(bullet!=null)
                {
                    DamageData damage = new DamageData(100, TypeofShotting);
                    bullet.damage = damage;
                }
                else
                {
                    Debug.LogError(this.GetType() + "::Shoot() : wrong bullet prefab");
                }
            }


        }
        else
        {
            currentReloadTime += Time.deltaTime;
        }
    }

    public void ChangeShotting()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            TypeofShotting = Element.Fire;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TypeofShotting = Element.Ice;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            TypeofShotting = Element.Wind;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            TypeofShotting = Element.Ground;
        }
    }

    

}
