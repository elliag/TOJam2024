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
    public SoundManager playSound;


    public void clickButton()
    {
        StartCoroutine(next());
    }

    IEnumerator next()
    {
        playSound.playClip("win");
        yield return new WaitForSeconds(1);
        currentLevel.SetActive(false);
        loading.GetComponent<loadingText>().level = nextLevel;
        loading.SetActive(true);
    }
}
