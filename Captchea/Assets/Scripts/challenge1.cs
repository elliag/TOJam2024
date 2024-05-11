using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class challenge1 : MonoBehaviour
{
    private GameObject[] squares;

    // Start is called before the first frame update
    void Start()
    {
        squares = GameObject.FindGameObjectsWithTag("Square");
        int i = 0;
        int j = 0;
        foreach (GameObject square in squares)
        {
            j++;
            if (j==2)
            {
                i++;
                j = 0;
            }
            square.GetComponent<squareObject>().num = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject saved = null;
        foreach (GameObject square in squares)
        {
            squareObject currentData = square.GetComponent<squareObject>();
            if (currentData.correct)
            {
                continue;
            }

            if (saved != null && currentData.clicked)
            {
                squareObject saveData = saved.GetComponent<squareObject>();
                if (saveData.num == currentData.num)
                {
                    square.GetComponent<SpriteRenderer>().color = Color.red;
                    saved.GetComponent<SpriteRenderer>().color = Color.red;
                    Reset();
                }
                else
                {
                    Reset();
                }
                break;
            }
            else if (currentData.clicked)
            {
                saved = square;
            }
        }
        saved = null;
    }

    private void Reset()
    {
        foreach (GameObject square in squares)
        { 
            if(square.GetComponent<SpriteRenderer>().color != Color.red)
            {
                square.GetComponent<SpriteRenderer>().color = Color.white;
            }
            square.GetComponent<squareObject>().clicked = false;
        }
    }
}
