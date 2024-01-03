using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    public static int value;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setup()
    {
        gameObject.SetActive(true);
    }

    public void easyMode()
    {
        value = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void moderateMode()
    {
        value = 2;
        SceneManager.LoadScene("GameScene");
    }

    public void toughMode()
    {
        value = 3;
        SceneManager.LoadScene("GameScene");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
