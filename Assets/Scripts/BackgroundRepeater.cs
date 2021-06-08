using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeater : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;

    void Start()
    {
        startPos = transform.position; /*her oyun basladiginda start pozisyonumuzu aliyor bu.
                                         yani start pos'u bilmemize yariyor */
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }


    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - repeatWidth) //bunu tam anlamadim :D
        {
            transform.position = startPos;
        }
    }
}
