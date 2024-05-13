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
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            OnMouseDown();
        }
    }


    public void OnMouseDown()
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
        yield return new WaitForSeconds(1);
        currentLevel.SetActive(false);
        loading.GetComponent<loadingText>().level = nextLevel;
        loading.SetActive(true);
    }
    IEnumerator loss()
    {
        yield return new WaitForSeconds(1);
        currentLevel.SetActive(false);
        gameOver.SetActive(true);
    }
}
