using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue = 0;
    TextMeshProUGUI score;

    // Start is called before the first frame update
    void Start()
    {
        scoreValue = 0;
        score = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score\n" + string.Format("{0:000}", scoreValue);
    } 
    /*
    public static int getScore()
    {
        return scoreValue;
    }*/
}
