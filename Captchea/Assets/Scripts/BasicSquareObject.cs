using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BasicSquareObject : MonoBehaviour
{
    public bool clicked = false;
    public bool locked = false;
    public TMP_Text text;
    public SoundManager playSound;
    void OnMouseDown()
    {
        if (!locked)
        {
            playSound.playClip("click");
            clicked = !clicked;
            if (clicked)
            {
                if(GetComponent<SpriteRenderer>() != null)
                    GetComponent<SpriteRenderer>().color = Color.green;
                if (text != null)
                    text.color = Color.green;
            }
            else
            {
                if (GetComponent<SpriteRenderer>() != null)
                    GetComponent<SpriteRenderer>().color = Color.white;
                if (text != null)
                    text.color = Color.white;
            }
        }
        
    }
}
