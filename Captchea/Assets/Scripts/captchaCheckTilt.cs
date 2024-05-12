using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class captchaCheckTilt : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject nextLevel;
    public GameObject currentLevel;
    public GameObject loading;


    public void OnMouseDown()
    {
        StartCoroutine(next());
    }

    void OnMouseEnter()
    {
        Color tmp = GetComponent<SpriteRenderer>().color;
        tmp.a = 0.5f;
        GetComponent<SpriteRenderer>().color = tmp;
    }

    void OnMouseExit()
    {
        Color tmp = GetComponent<SpriteRenderer>().color;
        tmp.a = 0f;
        GetComponent<SpriteRenderer>().color = tmp;
    }

    IEnumerator next()
    {
        yield return new WaitForSeconds(1);
        currentLevel.SetActive(false);
        loading.GetComponent<loadingText>().level = nextLevel;
        loading.SetActive(true);
    }
}
