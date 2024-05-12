using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class captchaCheckTime : MonoBehaviour
{
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
        string text = textBoxObject.GetComponent<TMP_InputField>().text.Trim();
        Debug.Log(System.DateTime.Now.ToString("hh:mm"));
        
        // Preprocess input time
        string formattedInput = FormatInputTime(text);

        if (formattedInput == System.DateTime.Now.ToString("hh:mm"))
        {
            StartCoroutine(next());
        }
        else if (text != "")
        {
            StartCoroutine(loss());
        }
    }

    private string FormatInputTime(string input)
    {
        string[] parts = input.Split(':');
        if (parts.Length != 2)
        {
            Debug.LogError("Invalid time format");
            return "";
        }

        int hours, minutes;
        if (!int.TryParse(parts[0], out hours) || !int.TryParse(parts[1], out minutes))
        {
            Debug.LogError("Invalid time format");
            return "";
        }

        // Adjust hours and minutes
        if (hours < 0 || hours > 23 || minutes < 0 || minutes > 59)
        {
            Debug.LogError("Invalid time format");
            return "";
        }

        // Convert hours to 12-hour format
        if (hours > 12)
        {
            hours -= 12;
        }

        return hours.ToString("00") + ":" + minutes.ToString("00");
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
