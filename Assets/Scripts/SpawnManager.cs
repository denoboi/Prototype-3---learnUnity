using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0); 
    private float startTime =1.5f;
    private float repeatTime = 1.5f;
    private PlayerController playerControllerScript;

   
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("obstacleSpawn", startTime, repeatTime);
    }

   
    void Update()
    {
        
    }
    void obstacleSpawn()
        
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
            
    }

}
