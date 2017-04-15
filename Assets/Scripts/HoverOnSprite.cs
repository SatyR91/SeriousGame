using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverOnSprite : MonoBehaviour {

    public Sprite emptySprite;
    public Sprite fullSprite;
    bool clicked;
    

    void Start() {
        clicked = false;
        GetComponent<SpriteRenderer>().sprite = emptySprite;
    }

    void OnMouseEnter() {
        if (!clicked)
            GetComponent<SpriteRenderer>().sprite = fullSprite;
    }

    void OnMouseExit()
    {
        if (!clicked)
            GetComponent<SpriteRenderer>().sprite = emptySprite;
    }

    void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().sprite = fullSprite;
        if (!clicked)
            clicked = true;
        
    }

}
