using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private Vector3 spawnPos = new Vector3(32, 1, 0);
            
    private float startTime =1.5f;
    private float repeatTimemin = 1.5f;
    private float repeatTimeMax = 3.0f;
    private PlayerController playerControllerScript;
    private int randomObstacle;
   
    void Start()
    {
        
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("ObstacleSpawn", startTime, Random.Range(repeatTimemin, repeatTimeMax));
    }

   
    void Update()
    {
        if (playerControllerScript.gameOver)
        {
            CancelInvoke("SpawnObstacle");
        }
    }
    public void ObstacleSpawn()
        
    {
       

            randomObstacle = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[randomObstacle], spawnPos, obstaclePrefabs[randomObstacle].transform.rotation);
    
        
            
    }

}
