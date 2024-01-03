using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainMenuScript : MonoBehaviour
{
    public LevelScript levels;
    public GameObject helpscreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void play()
    {
        levels.setup();
    }

    public void help()
    {
        helpscreen.SetActive(true);
    }

    public void exit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
