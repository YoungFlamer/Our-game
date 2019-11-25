using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController :MonoBehaviour//,characterInterface
{
    // public float speed;
    //public string TypeOfShoting;
   
    // Update is called once per frame
    void Update()
    {
       Rotate();
        //Move();
        
    }
    void Move()
    {
/*        float h = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        float v = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        Vector3 move = new Vector3(v, 0, -h);
        rb.MovePosition(transform.position + move);*/
    }
    void Rotate()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }

  //  public DamageData DealDamage()
 //{

//}    
}