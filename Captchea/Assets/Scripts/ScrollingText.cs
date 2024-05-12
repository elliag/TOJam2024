using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;

public class ScrollingText : MonoBehaviour
{

    
[Header("Text Settings")]
    [SerializeField] [TextArea] private string[] itemInfo;
    [SerializeField] private float textSpeed = 0.01f;

[Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI itemInfoText;
    private int currentDisplayingText = 0;

    public GameObject yesButton;
    public GameObject noButton;
    public GameObject enterButton;
    public GameObject startButton;

    public GameObject robot;
    public Animator anim;

    public string ending = "";

    void Start(){
        anim = robot.GetComponent<Animator>();
        yesButton.SetActive(false);
        noButton.SetActive(false);
        enterButton.SetActive(true);
        startButton.SetActive(false);
    }

    public void ActivateText(){
        yesButton.SetActive(false);
        noButton.SetActive(false);
        enterButton.SetActive(false);
        startButton.SetActive(false);
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText(){

        if(currentDisplayingText == 1){
            anim.Play("enter");
            for(int i = 0; i < itemInfo[currentDisplayingText].Length + 1; i++){
                itemInfoText.text = itemInfo[currentDisplayingText].Substring(0,i);
                yield return new WaitForSeconds(textSpeed);
            }

            enterButton.SetActive(true);
        }
        else if(currentDisplayingText == 5){
            for(int i = 0; i < itemInfo[currentDisplayingText].Length + 1; i++){
                itemInfoText.text = itemInfo[currentDisplayingText].Substring(0,i);
                yield return new WaitForSeconds(textSpeed);
            }

            yesButton.SetActive(true);
            noButton.SetActive(true);

        }
        else if(currentDisplayingText == 6){

            for(int i = 0; i < ending.Length + 1; i++){
                itemInfoText.text = ending.Substring(0,i);
                yield return new WaitForSeconds(textSpeed);
            }
            enterButton.SetActive(false);
            startButton.SetActive(true);
        }
        else{
            for(int i = 0; i < itemInfo[currentDisplayingText].Length + 1; i++){
                itemInfoText.text = itemInfo[currentDisplayingText].Substring(0,i);
                yield return new WaitForSeconds(textSpeed);
            }

            enterButton.SetActive(true);
            
        }  
        currentDisplayingText += 1;

    }

    public void pressEnter(){
        ActivateText();
    }

    public void endingYes(){
        ending = "Excellent, get to work! And don't forget to act human!";
        ActivateText();
    }

    public void endingNo(){
        ending = "Well.... thats too bad. Now get to it. And don't forget to act human!";
        ActivateText();
    }

}
