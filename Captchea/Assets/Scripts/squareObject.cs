//check if tile is clicked on, if clicked reveal underneath sprite and change clicked status to true, use Invoke() method to switch back to cover sprite after like 2 seconds


using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class squareObject : MonoBehaviour
{

    public bool clicked = false;

    public SpriteRenderer spriteRenderer;

    public Sprite normalSprite; //og sprite
    public Sprite flippedSprite;    //new sprite

    public challenge1 Tiles; //to get number of tiles flipped

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {  
    }

    void OnMouseDown()
    {
        if(Tiles.getFlipped() == true){
            Tiles.setFlipped(1, gameObject);
            clicked = true;

            spriteRenderer.sprite = flippedSprite;
            gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 1.0f);
            Invoke("FlipSprite", 1.2f);
        }
    }

    public void FlipSprite(){
        Tiles.setFlipped(-1, gameObject);
        clicked = false;
        spriteRenderer.sprite = normalSprite;
        gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

    public bool getClicked(){
        return clicked;
    }

    public Sprite getSprite(){
        return flippedSprite;
    }
}
