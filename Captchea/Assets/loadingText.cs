using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class loadingText : MonoBehaviour
{
    public GameObject sliderObject;
    public GameObject level;
    public GameObject text;
    public float speed;
    private float current;
    // Start is called before the first frame update
    void Start()
    {
        current = sliderObject.GetComponent<Slider>().value;
    }

    // Update is called once per frame
    void Update()
    {
        text.GetComponent<TMP_Text>().SetText("Loading: " + sliderObject.GetComponent<Slider>().value + "%");
        current += speed*Time.deltaTime;
        sliderObject.GetComponent<Slider>().value = current;
        if(sliderObject.GetComponent<Slider>().value >= 100)
        {
            current = 10;
            sliderObject.GetComponent<Slider>().value = current;
            gameObject.SetActive(false);
            level.SetActive(true);
        }
    }
}
