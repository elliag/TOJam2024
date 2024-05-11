//check if tile is clicked on, if clicked reveal underneath sprite and change clicked status to true, use Invoke() method to switch back to cover sprite after like 2 seconds






using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class squareObject : MonoBehaviour
{

    public bool clicked = false;
    public bool correct = false;
    public int num = 0;

    public SpriteRenderer spriteRenderer;
    public Sprite copy; //og sprite

    public Sprite newSprite;    //new sprite

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {  
    }

    void OnMouseDown()
    {
        if (!correct)
        {
            clicked = true;
            spriteRenderer.sprite = newSprite; 
            //spriteRenderer.sprite = copy;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
        }   
    }
}
