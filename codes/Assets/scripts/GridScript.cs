using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript
{
    // The Grid itself
    public static int w = 10; // this is the width
    public static int h = 13; // this is the height
    public static Element[,] elements = new Element[w, h];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Uncover all Mines
    public static void uncoverMines()
    {
        foreach (Element elem in elements)
            if (elem.mine) elem.loadTexture(0);
    }

    // Find out if a mine is at the coordinates
    public static bool mineAt(int x, int y)
    {
        // Coordinates in range? Then check for mine.
        if (x >= 0 && y >= 0 && x < w && y < h)
            return elements[x, y].mine;
        return false;
    }

    // Count adjacent mines for an element
    public static int adjacentMines(int x, int y)
    {
        int count = 0;

        if (mineAt(x, y + 1)) ++count; // top
        if (mineAt(x + 1, y + 1)) ++count; // top-right
        if (mineAt(x + 1, y)) ++count; // right
        if (mineAt(x + 1, y - 1)) ++count; // bottom-right
        if (mineAt(x, y - 1)) ++count; // bottom
        if (mineAt(x - 1, y - 1)) ++count; // bottom-left
        if (mineAt(x - 1, y)) ++count; // left
        if (mineAt(x - 1, y + 1)) ++count; // top-left

        return count;
    }

    // Flood Fill empty elements
    public static void FFuncover(int x, int y)
    {
        Debug.Log("In FFuncover" + x + "," + y);
        // Coordinates in Range?
        if (x >= 0 && y >= 0 && x < w && y < h)
        {
            // visited already?
            if (Element.visit[x, y])
            {
                Debug.Log("already visited" + x + "," + y);
                return;
            }

            // uncover element
            elements[x, y].loadTexture(adjacentMines(x, y));
            ScoreScript.scoreValue++;
            Debug.Log("Score: " + ScoreScript.scoreValue);

            // set visited flag
            Element.visit[x, y] = true;

            // close to a mine? then no more work needed here
            if (adjacentMines(x, y) > 0)
                return;


            // recursion
            FFuncover(x - 1, y);
            FFuncover(x + 1, y);
            FFuncover(x, y - 1);
            FFuncover(x, y + 1);
        }
    }

    public static bool isFinished()
    {
        // Try to find a covered element that is no mine
        foreach (Element elem in elements)
            if (elem.isCovered() && !elem.mine)
                return false;
        // There are none => all are mines => game won.
        return true;
    }

}
