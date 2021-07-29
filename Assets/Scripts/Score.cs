using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Score : MonoBehaviour
{
    public TextMeshProUGUI textScore;
    float score; 
    float pointIncreasePerSecond;
    float decimalScore;

    PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        pointIncreasePerSecond = 00012;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.gameOver == false)
    {
        decimalScore += (pointIncreasePerSecond)  * Time.deltaTime;
        score = Mathf.RoundToInt(decimalScore);
        if(score < 9)
        {
            textScore.text = "0000" + score;
        }
        else if(score >9 && score <= 99)
        {
            textScore.text = "000" + score;
        
        }
        else if(score > 99 && score<=999)
        {
            textScore.text = "00" + score;
        }
        else if(score > 999)
        {
            textScore.text = "0" + score;
        }

    }
        


        
        
        Debug.Log("Score: " + score);
    }
}
