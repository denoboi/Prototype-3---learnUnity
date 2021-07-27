using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenMovement : MonoBehaviour
{
     public float speed = 20;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
         if (playerControllerScript.gameOver == false) //gameOver diger scriptte public yaptigimiz icin erisebiliyoruz.
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }
}
