using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioClip submitSound;
    public AudioClip openFileSound;
    public AudioClip clickSound;

    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playClip(string clip){
        switch(clip){
            case "win":
                audioSrc.clip = winSound;
                audioSrc.Play();
                break;
            case "lose":
                audioSrc.clip = loseSound;
                audioSrc.Play();
                break;
            case "submit":
                audioSrc.clip = submitSound;
                audioSrc.Play();
                break;
            case "file":
                audioSrc.clip = openFileSound;
                audioSrc.Play();
                break;
            case "click":
                audioSrc.clip = clickSound;
                audioSrc.Play();
                break;
        }
    }

    public int clipLength(){
        return (int)audioSrc.clip.length;
    }

    public AudioSource getSRC(){
        return audioSrc;
    }
}
