using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSquareObject : MonoBehaviour
{
    public bool clicked = false;
    public bool locked = false;
    void OnMouseDown()
    {
        if (!locked)
        {
            clicked = !clicked;
            if (clicked)
            {
                GetComponent<SpriteRenderer>().color = Color.green;
            }
            else
            {
                GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        
    }
}
