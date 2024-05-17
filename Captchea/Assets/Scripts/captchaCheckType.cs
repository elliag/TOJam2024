using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class captchaCheckType : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject nextLevel;
    public GameObject currentLevel;
    public GameObject gameOver;
    public GameObject check;
    public GameObject textBoxObject;
    public GameObject loading;
    public SoundManager playSound;


    public void OnMouseDown()
    {
        playSound.playClip("click");
        string text = textBoxObject.GetComponent<TMP_InputField>().text;
        
        if(text == "I'm not a robot" || text == "I am not a robot" || text == "I am a human" || text == "I'm a human")
        {
            StartCoroutine(next());
        }
        else
        {
            StartCoroutine(loss());
        }
    }

    IEnumerator next()
    {
        playSound.playClip("win");
        check.SetActive(true);
        yield return new WaitForSeconds(1);
        currentLevel.SetActive(false);
        loading.GetComponent<loadingText>().level = nextLevel;
        loading.SetActive(true);
    }
    IEnumerator loss()
    {
        playSound.playClip("lose");
        check.SetActive(false);
        yield return new WaitForSeconds(1);
        currentLevel.SetActive(false);
        gameOver.SetActive(true);
    }
}
