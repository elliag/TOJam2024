using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Progression : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Pause;
    public GameObject LevelUI;
    public GameObject L1;
    public GameObject loading;
    public TMP_Text LevelNum;
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
        open_Menu();
        
    }

    // Update is called once per frame
    void Update()
    {
        //LevelNum.text = "Level " + num;
        
    }

    public void open_Menu(){
        clear();
        LevelUI.SetActive(false);
        Menu.SetActive(true);

    }

    public void open_Pause(){
        Pause.SetActive(true);
        
    }

    public void close_Pause(){
        Pause.SetActive(false);
        
    }

    public void open_L1(){
        Invoke("Level1", 0.3f);
    }

    public void Level1(){
        clear();
        LevelUI.SetActive(true);
        loading.GetComponent<loadingText>().level = L1;
        loading.SetActive(true);
    }

    public void clear(){
        Menu.SetActive(false);
        Pause.SetActive(false);
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

    public void open_L2(){
        Invoke("Level2", 1.0f);
    }

    public void Level2(){
        clear();
        L2.SetActive(true);
    }

    public void open_L3(){
        Invoke("Level3", 1.0f);
    }

    public void Level3(){
        clear();
        L3.SetActive(true);
    }

    public void open_L4(){
        Invoke("Level4", 1.0f);
    }

    public void Level4(){
        clear();
        L4.SetActive(true);
    }

    public void open_L5(){
        Invoke("Level5", 1.0f);
    }

    public void Level5(){
        clear();
        L5.SetActive(true);
    }

    public void open_L6(){
        Invoke("Level6", 1.0f);
    }

    public void Level6(){
        clear();
        L6.SetActive(true);
    }

}
