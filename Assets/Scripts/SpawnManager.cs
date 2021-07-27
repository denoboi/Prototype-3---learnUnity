using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private Vector3 spawnPos = new Vector3(32, 1, 0);
            
    private float startTime =1f;
    private float repeatTimemin = 0.8f;
    private float repeatTimeMax = 3.0f;
    private float spawnInterval;
    private PlayerController playerControllerScript;
    private int randomObstacle;
   
    void Start()
    {
        
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        Invoke("ObstacleSpawn", spawnInterval);
    }

   
    void Update()
    {
        

        if (playerControllerScript.gameOver)
        {
            CancelInvoke("ObstacleSpawn");

        }
    }
    public void ObstacleSpawn()
        
    {

        spawnInterval = Random.Range(0.8f, 4f);
        randomObstacle = Random.Range(0, obstaclePrefabs.Length);
        Instantiate(obstaclePrefabs[randomObstacle], spawnPos, obstaclePrefabs[randomObstacle].transform.rotation);
        Invoke("ObstacleSpawn", spawnInterval);


    }

}
