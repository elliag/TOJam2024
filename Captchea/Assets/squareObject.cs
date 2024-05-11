using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class squareObject : MonoBehaviour
{

    public bool clicked = false;
    public int num = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
    }

    void OnMouseDown()
    {
        clicked = true;
        GetComponent<SpriteRenderer>().color = Color.blue;
    }

}
