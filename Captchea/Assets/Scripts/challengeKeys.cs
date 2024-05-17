//have integer value and add one every time player makes a pair (when int = 18 then player got all matches)
//check which tiles are currently clicked, if there are two tiles clicked compare if they have the same underneath sprite, if they do then +1 to integer value

//if player makes a pair, those tiles dissapear/turn white
//player CANNOT flip more than 2 tiles at once

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class challengeKeys : MonoBehaviour
{
    private GameObject[] squares = new GameObject[16];

    public GameObject nextLevel;
    public GameObject currentLevel;
    public GameObject loading;
    public GameObject cat;
    public int correctAnswers;
    public SoundManager playSound;

    // Start is called before the first frame update
    void Start()
    {
        squares = GameObject.FindGameObjectsWithTag("Square");  //add tiles to array
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        foreach (GameObject s in squares)
        {
            if (s.name == "answer" && s.GetComponent<BasicSquareObject>().clicked)
            {
                i++;
            }

            if (s.name != "answer" && s.GetComponent<BasicSquareObject>().clicked)
            {
                i--;
            }
        }

        if(i == correctAnswers)
        {
            foreach (GameObject s in squares)
            {
                s.GetComponent<BasicSquareObject>().locked = true;
            }
            StartCoroutine(next());
        }
    }

    IEnumerator next()
    {
        if(cat!=null)
            cat.SetActive(true);
        playSound.playClip("win");

        yield return new WaitForSeconds(1f);
        currentLevel.SetActive(false);
        loading.GetComponent<loadingText>().level = nextLevel;
        loading.SetActive(true);
    }
}
