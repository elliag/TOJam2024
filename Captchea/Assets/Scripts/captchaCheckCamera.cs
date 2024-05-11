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
    public GameObject check;


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
        check.SetActive(true);
        yield return new WaitForSeconds(1);
        currentLevel.SetActive(false);
        nextLevel.SetActive(true);
    }
}
