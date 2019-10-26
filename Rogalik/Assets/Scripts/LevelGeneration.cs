using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject startRoom = null;
    bool checkFirstly = false;

    float positiony;

    public GameObject[] intersectionRooms;
    public int n = 10; // size of massive. world size (in rooms)
    public int RoomsInLevel = 7;
    
    
    public  float sizex  ;
    public float sizez ;

    private int amount = 0;

    /// Todo: change int to bool or some enum. If need
    int[,] used;
    int ci, cj;//current i,curren j

    void Awake()
    {
       
        positiony = transform.position.y;
        
        sizex = RoomScript.GetRoomX();
        sizez = RoomScript.GetRoomZ();

        used = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                used[i, j] = 0;
            }
        }

       
        ci = n / 2;
        cj = n / 2;
        Camera.main.transform.position.Set(ci, positiony + 2, cj);
        while (amount < RoomsInLevel)
        {
            fun(ci, cj);
        }
    }
    public void fun(int starti, int startj)//something with last block
    {
        int iplus = 0;
        int jplus = 0;

        do
        {
            int side = Random.Range(1, 4);

            switch (side)
            {
                case 1: iplus = 1; jplus = 0; break;
                case 2: iplus = 0; jplus = 1; break;
                case 3: iplus = -1; jplus = 0; break;
                case 4: iplus = 0; jplus = -1; break;
            }

            starti += iplus;
            startj += jplus;

            if (starti >= n || starti < 0 || startj >= n || startj < 0)
            {
                starti = n / 2;
                startj = n / 2;
            }

        } while (used[starti, startj] != 0);

        int roomIndex = Random.Range(0, intersectionRooms.Length);
        //print(roomIndex + " " + intersectionRooms.Length);
        GameObject roomToCreate = intersectionRooms[roomIndex];
        GameObject nextcube = Instantiate(roomToCreate);

        nextcube.transform.position = new Vector3(starti * sizex, positiony, startj * sizez);
        if (!checkFirstly)
        {
            startRoom = nextcube;
            checkFirstly = true;
        }
        amount++;
        used[starti, startj] = 1;
        ci = starti;
        cj = startj;
    }

    public Vector3 GetSpawnPosition()
    {
        return startRoom.transform.position + new Vector3(RoomScript.GetRoomX() / 2f, 5, RoomScript.GetRoomZ() / 2f);

    }
}