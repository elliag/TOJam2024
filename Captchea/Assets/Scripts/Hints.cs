using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;

public class Hints : MonoBehaviour
{

    public TMP_Text hint;

    void Start(){
        hint.text = "";
    }

    public void hintL1(){
        hint.text = "Find all the matching tiles!";
    }

    public void hintL2(){
        hint.text = "You're *not* a robot, aren't you? Correct them!";
    }

    public void hintL3(){
        hint.text = "Well, what time is it right now?";
    }

    public void hintL4(){
        hint.text = "Taking a screenshot counts as a photo";
    }

    public void hintL5(){
        hint.text = "The text bar needs to be full, but empty...";
    }

    public void hintL6(){
        hint.text = "The text bar needs to be full, but empty...";
    }

    public void hintL7(){
        hint.text = "That text might be easier to read if you tilt your screen to read it";
    }

    public void hintL8(){
        hint.text = "Not just keys to unlock something!";
    }

    public void hintL9(){
        hint.text = "Maybe there are no cats in these pictures?";
    }
}
