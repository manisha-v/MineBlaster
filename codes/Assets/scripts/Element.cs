using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//To add highscore functaionality just uncomment highscore related code

public class Element: MonoBehaviour
{
    public GameEndScript gameEnd;
    //public static int highScore =0;

    public AudioSource GameOverSound;
    public AudioSource VictorySound;
    public AudioSource clickSound;
 
    public bool mine;
    public static bool[,] visit = new bool[GridScript.w, GridScript.h];
    public static bool isGameOver;
   
    // Different Textures
    public Sprite[] emptyTextures;
    public Sprite mineTexture;


    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;

        // Randomly decide if it's a mine or not
        if (LevelScript.value == 1)
            mine = Random.value < 0.10;
        else if (LevelScript.value == 2)
            mine = Random.value < 0.22;         
        else
            mine = Random.value < 0.32;
   
        for (int i = 0; i < 10; i++)
            for (int j = 0; j < 13; j++)
                Element.visit[i, j] = false;

        // Register in Grid
        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        GridScript.elements[x, y] = this;

        InvokeRepeating("checkTime", 0.5f, 0.5f);
    }
    
    public void checkTime()
    {
        if (CountdownScript.timeValue == 0)
        {
            CancelInvoke("checkTime");
            StartCoroutine(Wait(3));
        }
    }

    // Load another texture
    public void loadTexture(int adjacentCount)
    {
        if (mine)
            GetComponent<SpriteRenderer>().sprite = mineTexture;
        else
        {
            GetComponent<SpriteRenderer>().sprite = emptyTextures[adjacentCount];
        }
    }

    // Is it still covered?
    public bool isCovered()
    {
        return GetComponent<SpriteRenderer>().sprite.texture.name == "default";
    }

    void OnMouseUpAsButton()
    {
        if (!isGameOver)
        {
            
            // It's a mine
            if (mine)
            {
                isGameOver = true;
                // Uncover all mines
                GridScript.uncoverMines();

                // game over
                /*
                if (highScore <= ScoreScript.getScore())
                {
                    highScore = ScoreScript.getScore();
                    print("High Score: " + highScore);
                }
                */
                print("you lose");
                StartCoroutine(Wait(1));

            }
            // It's not a mine
            else
            {
                
                // show adjacent mine number
                int x = (int)transform.position.x;
                int y = (int)transform.position.y;
                Debug.Log("Clicked on :" + x + "," + y);
                //reset time
                if (visit[x, y] == false)
                {
                    clickSound.Play();
                    resetTime();
                }
                    
                loadTexture(GridScript.adjacentMines(x, y));
                
                // uncover area without mines
                GridScript.FFuncover(x, y);
                

                // find out if the game was won now
                if (GridScript.isFinished())
                {
                    print("you win");
                    isGameOver = true;
                    StartCoroutine(Wait(2));
                }
            }
        }
    }

    private IEnumerator Wait(int status)
    {
        if (status == 2)
            VictorySound.Play();
        else 
            GameOverSound.Play();

        yield return new WaitForSeconds(1.5f);

            gameEnd.setup(status);
    }

    void resetTime()
    {
        if (LevelScript.value == 1)
            CountdownScript.timeValue = 181;
        else if (LevelScript.value == 2)
            CountdownScript.timeValue = 121;
        else
            CountdownScript.timeValue = 61;
    }

}
