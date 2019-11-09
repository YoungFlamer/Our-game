using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingScript : MonoBehaviour
{
   public Transform heroTrans;
    public float heroX;//кордината абстрактного кола по Х
    public float heroZ;//кордината абстрактного кола по Z
    public float Ypos;
    public float rad;//радиус
    public float dx = 1;
    public float add = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rad = Mathf.Abs(heroX - transform.position.x);
        
    }

    // Update is called once per frame
   public  float ZcordinatOfCircle(float x)//возвращает значение второй кординаты из уравнения окружности
    {
        float a = Mathf.Sqrt(rad * rad - (x - heroX) * (x - heroX)) + heroZ;
        return a;

    }
    void Update()
    {
        //setDx();
        Ypos = transform.position.y;
        heroX = heroTrans.position.x;
        heroZ = heroTrans.position.z;

        float currentXpos = transform.position.x + dx;
        transform.position = new Vector3(currentXpos, Ypos, ZcordinatOfCircle(currentXpos));

        
    }

    public void setDx()
    {
        dx = 0;
        if (Input.GetKeyDown(KeyCode.I))
        {
            dx = add;
            Console.WriteLine("Salom");

        }
        if (Input.GetKeyDown(KeyCode.Y)) dx = -add;
    }


}
