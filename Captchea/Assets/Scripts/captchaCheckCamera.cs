using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class captchaCheckCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject nextLevel;
    public GameObject currentLevel;
    public GameObject photo;
    public Sprite winPhoto;
    public GameObject loading;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Print))
        {
            StartCoroutine(next());
        }
    }

    void OnGUI()
    {
        if (Event.current.type == EventType.KeyUp && Event.current.keyCode == KeyCode.SysReq)
        {
            StartCoroutine(next());
        }
    }

    IEnumerator next()
    {
        photo.GetComponent<SpriteRenderer>().sprite = winPhoto;
        yield return new WaitForSeconds(1);
        currentLevel.SetActive(false);
        loading.GetComponent<loadingText>().level = nextLevel;
        loading.GetComponent<loadingText>().game = true;
        loading.SetActive(true);
    }
}
