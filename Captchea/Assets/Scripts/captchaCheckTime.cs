using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class captchaCheckTime : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject nextLevel;
    public GameObject currentLevel;
    public GameObject gameOver;
    public GameObject textBoxObject;


    public void OnMouseDown()
    {
        string text = textBoxObject.GetComponent<TMP_InputField>().text;
        Debug.Log(System.DateTime.Now.ToString("hh:mm"));
        if(text == System.DateTime.Now.ToString("hh:mm"))
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
        nextLevel.SetActive(true);
    }
    IEnumerator loss()
    {
        yield return new WaitForSeconds(1);
        currentLevel.SetActive(false);
        gameOver.SetActive(true);
    }
}
