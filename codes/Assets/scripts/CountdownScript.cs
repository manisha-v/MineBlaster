using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CountdownScript : MonoBehaviour
{
    public static float timeValue;
    TextMeshProUGUI timeText;

    private void Start()
    {
        
        if (LevelScript.value == 1)
            timeValue = 181;
        else if (LevelScript.value == 2)
            timeValue = 121;
        else
            timeValue = 61;

        timeText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Element.isGameOver)
        {
            if (timeValue > 0)
            {
                timeValue -= Time.deltaTime;
                Display(timeValue);
            }
                
            else
            {
                Element.isGameOver = true;
                timeValue = 0;
            }          
        }
    }

    void Display(float time)
    {
        if (time < 0)
            time = 0;
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        timeText.text = "Time Left\n" + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    /*
    public static void resetTime()
    {
        if (LevelScript.value == 1)
            timeValue = 301;
        else if (LevelScript.value == 2)
            timeValue = 181;
        else
            timeValue = 121;
    }*/
}
