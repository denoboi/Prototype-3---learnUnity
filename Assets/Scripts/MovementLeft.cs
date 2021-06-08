using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementLeft : MonoBehaviour
{
    public float speed = 30;
    private PlayerController playerControllerScript;
    private float leftBound = -15;

    
    void Start()
        //Bu hierarchy'de yer alan Player'i buluyor ve ona bu scriptte de PlayerController ekliyor. 
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

   
    void Update()
    {
        if (playerControllerScript.gameOver == false) //gameOver diger scriptte public yaptigimiz icin erisebiliyoruz.
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (transform.position.x < leftBound && CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }    
     
    }
}
