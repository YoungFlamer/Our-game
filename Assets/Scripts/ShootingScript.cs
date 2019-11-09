using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    float currentReloadTime;
    public GameObject bulletPrefab;
    public float reloadTime;
    // public Transform gunPoint;


    private void Update()
    {
        Shoot();
    }
    void Shoot()
    {
        if (currentReloadTime > reloadTime)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(bulletPrefab, transform.position, transform.rotation);
                currentReloadTime = 0;
                //Rotate();
            }


        }
        else
        {
            currentReloadTime += Time.deltaTime;
        }
    }
}
