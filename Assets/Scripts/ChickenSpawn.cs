using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenSpawn : MonoBehaviour
{
     public GameObject[] birdsPrefabs;
    
    
    private float spawnInterval;
    private PlayerController playerControllerScript;
    private int randomBirds;
    
    void Start()
    {
        //playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        //Invoke("BirdSpawn", spawnInterval);
        Invoke("BirdSpawn", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BirdSpawn()
        
    {
        float randomX = Random.Range(34,39);
        float randomY = Random.Range(0.5f ,6);
        Vector3 randomSpawnpos = new Vector3(randomX, randomY, 0);

        spawnInterval = Random.Range(8f, 10f);

        randomBirds = Random.Range(0,2);
        
        Instantiate(birdsPrefabs[0], randomSpawnpos, birdsPrefabs[0].transform.rotation);
        Invoke("BirdSpawn", spawnInterval);


    }
}
