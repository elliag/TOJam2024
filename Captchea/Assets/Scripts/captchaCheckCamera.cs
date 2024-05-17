using System.Collections;
using UnityEngine;

public class captchaCheckCamera : MonoBehaviour
{
    public GameObject nextLevel;
    public GameObject currentLevel;
    public GameObject photo;
    public Sprite winPhoto;
    public GameObject loading;
    public SoundManager playSound;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Print) || Input.GetKeyDown(KeyCode.SysReq))
        {
            StartCoroutine(next());
        }
    }

    void OnGUI()
    {
        if (Event.current.type == EventType.KeyUp && (Event.current.keyCode == KeyCode.Print || Event.current.keyCode == KeyCode.SysReq))
        {
            StartCoroutine(next());
        }
    }

    IEnumerator next()
    {
        playSound.playClip("win");
        photo.GetComponent<SpriteRenderer>().sprite = winPhoto;
        yield return new WaitForSeconds(1);
        currentLevel.SetActive(false);
        loading.GetComponent<loadingText>().level = nextLevel;
        loading.GetComponent<loadingText>().game = true;
        loading.SetActive(true);
    }
}
