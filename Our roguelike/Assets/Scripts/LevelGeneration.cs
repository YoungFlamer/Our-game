using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject startRoom;

    //take this one from Vanya's script Room
    float sizex = 30;
    float sizez = 30;
    //

    float positiony;

    public GameObject[] intersectionRooms;
    public int n = 10; // size of massive. world size (in rooms)
    public int RoomsInLevel = 7;
    private int amount = 0;

    /// Todo: change int to bool or some enum. If need
    int[,] used;
    int ci, cj;//current i,curren j

    void Start()
    {
        //GameObject cube = Instantiate(gameMas[1]) as GameObject;
        positiony = transform.position.y;
        used = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                used[i, j] = 0;
            }
        }

        // foreach(GameObject obj in gameMas)
        //{
        //   obj = cube;
        // }
        ci = n / 2;
        cj = n / 2;

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

        GameObject nextcube = Instantiate(intersectionRooms[Random.Range(0, intersectionRooms.Length-1)]) as GameObject;

        nextcube.transform.position = new Vector3(starti * sizex, positiony, startj * sizez);
        amount++;
        used[starti, startj] = 1;
        ci = starti;
        cj = startj;
    }
}


