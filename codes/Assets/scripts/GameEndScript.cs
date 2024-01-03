using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameEndScript : MonoBehaviour
{
    public TextMeshProUGUI GOscore;
    public TextMeshProUGUI GameStatus;
    public GameObject helpScreen;
    public void setup(int status)
    {
        if (status == 1)
            GameStatus.text = "GAME OVER";
        else if (status == 2)
            GameStatus.text = "VICTORY";
        else
            GameStatus.text = "Time's Up";
        GOscore.text = "Score: "+ ScoreScript.scoreValue.ToString();
        gameObject.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void exitgame()
    {
        Application.Quit();
    }

    public void help()
    {
        helpScreen.SetActive(true);
    }

    public void setMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
