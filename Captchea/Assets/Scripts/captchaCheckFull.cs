using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class captchaCheckFull: MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject nextLevel;
    public GameObject currentLevel;
    public GameObject gameOver;
    public GameObject textBoxObject;
    public GameObject loading;
    public SoundManager playSound;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            clickButton();
        }
    }


    public void clickButton()
    {
        string text = textBoxObject.GetComponent<TMP_InputField>().text;
        if(text.Length > 15)
        {
            StartCoroutine(next());
            
        }
        else if(text != "")
        {
            StartCoroutine(loss());
        }
    }

    IEnumerator next()
    {
        playSound.playClip("win");
        yield return new WaitForSeconds(1);
        currentLevel.SetActive(false);
        loading.GetComponent<loadingText>().level = nextLevel;
        loading.SetActive(true);
    }
    IEnumerator loss()
    {
        playSound.playClip("loss");
        yield return new WaitForSeconds(1);
        currentLevel.SetActive(false);
        gameOver.SetActive(true);
    }
}
