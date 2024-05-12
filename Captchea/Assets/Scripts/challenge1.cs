//have integer value and add one every time player makes a pair (when int = 18 then player got all matches)
//check which tiles are currently clicked, if there are two tiles clicked compare if they have the same underneath sprite, if they do then +1 to integer value

//if player makes a pair, those tiles dissapear/turn white
//player CANNOT flip more than 2 tiles at once

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class challenge1 : MonoBehaviour
{
    private GameObject[] squares = new GameObject[16];
    private GameObject[] flippedTiles = new GameObject[2];

    public GameObject temp;

    private GameObject erase1;
    private GameObject erase2;

    private int pairs = 0;

    private bool canFlip = true; //if the player can flip a tile
    private int numFlipped = 0;  //number of tiles flipped

    public GameObject nextLevel;
    public GameObject currentLevel;
    public GameObject loading;

    // Start is called before the first frame update
    void Start()
    {
        squares = GameObject.FindGameObjectsWithTag("Square");  //add tiles to array
        flippedTiles[0] = temp;
        flippedTiles[1] = temp;

    }

    // Update is called once per frame
    void Update()
    {

        if(numFlipped >= 2){
            canFlip = false;
        }
        else{
            canFlip = true;
        }

        if((flippedTiles[0] != temp) && (flippedTiles[1] != temp)){
            if((flippedTiles[0].GetComponent<SpriteRenderer>().sprite.name == flippedTiles[1].GetComponent<SpriteRenderer>().sprite.name)){
                pairs += 1;
                flippedTiles[0].GetComponent<SpriteRenderer>().color = Color.green;
                flippedTiles[1].GetComponent<SpriteRenderer>().color = Color.green;

                erase1 = flippedTiles[0];
                erase2 = flippedTiles[1];
                Invoke("erase", 1.2f);

                flippedTiles[0] = temp;
                flippedTiles[1] = temp;
            }
        }

        if(pairs == 8){
            StartCoroutine(next());
        }
    }

    public void erase()
    {
        erase1.SetActive(false);
        erase2.SetActive(false);
    }

    public bool getFlipped(){
        return canFlip;
    }

    public void setFlipped(int x, GameObject s){

        if(x == 1){
            for(int i = 0; i < 2; i++){
                if (flippedTiles[i] == temp){
                    flippedTiles[i] = s;
                    i = 2;
                }
            }
        }
        else if (x == -1){
            for(int i = 0; i < 2; i++){
                if (flippedTiles[i] == s){
                    flippedTiles[i] = temp;
                    i = 2;
                }
            }
        }

        numFlipped += x;
    }

    IEnumerator next()
    {
        yield return new WaitForSeconds(1);
        currentLevel.SetActive(false);
        loading.GetComponent<loadingText>().level = nextLevel;
        loading.SetActive(true);
    }
}
