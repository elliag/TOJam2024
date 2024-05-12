using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;

public class FinalChallenge : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;

    public GameObject barrier;
    public GameObject goat;

    public GameObject tempCage;
    public GameObject cage;

    public TMP_Text timer;
    public TMP_Text countdown;


    public float targetTime = 15.0f;
    public float count = 4.0f;

    public bool startGame = false;
 
    // Use this for initialization
    void Start () {

        cage.SetActive(true);
        tempCage.SetActive(true);
        startGame = false;

        Invoke("StartGame", 4.0f);
   
    }
   
    // Update is called once per frame
    void Update () {

            targetTime -= Time.deltaTime;
            count -= Time.deltaTime;

            if(startGame == true){
                timer.text = "Time Remaining: " + (int)targetTime;
                countdown.text = " ";
            }
            else{
                countdown.text = (int)count + "!";
                timer.text = "";
            }

            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);

            if(goat.GetComponent<PolygonCollider2D>().bounds.Intersects(barrier.GetComponent<BoxCollider2D>().bounds)){
                reset();
            }

            if(targetTime <= 0){
                //winner
            }
 
    }

    public void StartGame(){
        startGame = true;
        cage.SetActive(false);
        tempCage.SetActive(false);
        targetTime = 15.0f;

    }

    public void reset(){
        targetTime = 15.0f;
        cage.SetActive(true);
        goat.transform.position = new Vector3(0.63f, 7.2f, 0f);
        //goat.transform.eulerAngles = new Vector3 (0, 0, 0);

        count = 4.0f;
        startGame = false;

        Invoke("StartGame", 4.0f);
    }
}
