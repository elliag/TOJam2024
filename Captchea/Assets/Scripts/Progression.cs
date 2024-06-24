using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Progression : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Pause;
    public GameObject LevelUI;
    public GameObject L1;
    public GameObject loading;
    public GameObject Intro;
    
    //public TMP_Text LevelNum;
    public int num = 1;

    //unused vvv
    public GameObject L2;
    public GameObject L3;
    public GameObject L4;
    public GameObject L5;
    public GameObject L6;

    // Start is called before the first frame update
    void Start()
    {
        open_Start();
        
    }

    // Update is called once per frame
    void Update()
    {
        //LevelNum.text = "Level " + num;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            open_Pause();
        }
        
    }

    public void open_Start(){
        clear();
        LevelUI.SetActive(false);
        Menu.SetActive(true);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void open_Menu()
    {
        clear();
        LevelUI.SetActive(false);
        Menu.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void open_Intro(){
        clear();
        Intro.SetActive(true);
    }

    public void open_Pause(){
        Pause.SetActive(true);
        
    }

    public void close_Pause(){
        Pause.SetActive(false);
        
    }

    public void open_L1(){
        clear();
        LevelUI.SetActive(true);
        loading.GetComponent<loadingText>().level = L1;
        loading.SetActive(true);
    }



    public void clear(){
        Menu.SetActive(false);
        Pause.SetActive(false);
        Intro.SetActive(false);
        L1.SetActive(false);
        L2.SetActive(false);
        L3.SetActive(false);
        L4.SetActive(false);
        L5.SetActive(false);
        L6.SetActive(false);
    }

    public void setLevelNum(int x){
        num = x;
    }


    //unused vvv



}
