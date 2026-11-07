using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject platformPrefab;
    public int platformCount = 300;
    public float platformPadding = 0.5f;

    void Start()
    {
        float screenHalfWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        float minX = -screenHalfWidth + platformPadding;
        float maxX = screenHalfWidth - platformPadding;

        Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < platformCount; i++)
        {
            spawnPosition.y += Random.Range(2.5f, 4f);
            spawnPosition.x = Random.Range(minX, maxX);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }
    }

    //Spawns can be done in Update
}


//https://www.youtube.com/watch?v=IUzI95mmbwA - This youtube video helped with procedural algorithm