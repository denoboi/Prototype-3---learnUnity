using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    List<GameObject> prefabList = new List<GameObject>();
    public GameObject Prefab1;
    public GameObject Prefab2;
    public GameObject Prefab3;
    public GameObject obstaclePrefab;
    public GameObject obstaclePrefab2;
    
    private Vector3 spawnPos = new Vector3(25, 0, 0); 
    private float startTime =1.5f;
    private float repeatTime = 1.5f;
    private PlayerController playerControllerScript;

   
    void Start()
    {
        


        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("ObstacleSpawn", startTime, repeatTime);
    }

   
    void Update()
    {
        
    }
    public void ObstacleSpawn()
        
    {
        if (playerControllerScript.gameOver == false)
        {
            prefabList.Add(Prefab1);
            prefabList.Add(Prefab2);
            prefabList.Add(Prefab3);

            int prefabIndex = Random.Range(0, 3);
            Instantiate(prefabList[prefabIndex], spawnPos, obstaclePrefab.transform.rotation);
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
            Instantiate(obstaclePrefab2, spawnPos, obstaclePrefab.transform.rotation);
        }
        
            
    }

}
