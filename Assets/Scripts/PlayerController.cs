using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController :MonoBehaviour//,characterInterface
{
    // public float speed;
    //public sShoting;

    public Transform currentRoomTransform => currentRoom?.transform;

  

    public RoomScript currentRoom;
    // Update is called once per frame
    void Update()
    {
       Rotate();
        RoomCage();
        
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

    public void EnterRoom(RoomScript newRoom)
    {
        currentRoom = newRoom;
    }

    private void RoomCage()
    {
         if (currentRoom.IsRoomCleared())
            return;
        //print(currentRoom.transform.position.x + RoomScript.GetRoomX());
        if (transform.position.x > currentRoom.transform.position.x + RoomScript.GetRoomX() - 0.3f)
        {
            
            Vector3 newPosition = transform.position;
            newPosition.x -= 0.1f;
            transform.position = newPosition;
        }
        if (transform.position.x < currentRoom.transform.position.x + 0.3f)
        {
            Vector3 newPosition = transform.position;
            newPosition.x += 0.1f;
            transform.position = newPosition;
        }
        if (transform.position.z > currentRoom.transform.position.z + RoomScript.GetRoomZ() - 0.3f)
        {
            Vector3 newPosition = transform.position;
            newPosition.z -= 0.1f;
            transform.position = newPosition;
        }
        if (transform.position.z < currentRoom.transform.position.z + 0.3f)
        {
            Vector3 newPosition = transform.position;
            newPosition.z += 0.1f;
            transform.position = newPosition;
        }

    }

    public void EnemyIsDestroyed()
    {
        currentRoom.MinusEnemiesAlive();
    }
    
}