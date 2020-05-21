using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class clickButton : MonoBehaviour {
    private GameObject Buttons;
    private bool isLoad;
    //private GameObject myButton;
	// Use this for initialization
	void Start () {
        Buttons = GameObject.Find("Buttons");
        if (SceneManager.GetActiveScene().buildIndex == 0) {
            checkFile();
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        
    }
    /// <summary>
    /// 开始游戏
    /// </summary>
    public void choiceStart()
    {
        Buttons.transform.localScale = new Vector3(1, 1, 1);
        string fileName = Application.persistentDataPath + "/Save";
        if (!controlData.IsFileExists(fileName+ "/GameData1.sav")&& !controlData.IsFileExists(fileName + "/GameData2.sav")&& !controlData.IsFileExists(fileName + "/GameData3.sav"))
        {
        
            GameObject.Find("Load").GetComponent<Button>().interactable = false;
        }
        if (GameObject.Find("Start")!= null)
        {
            Destroy(GameObject.Find("Start"));
        }
 
    }
    /// <summary>
    /// 新游戏
    /// </summary>
    public void choiceNew()
    {
        GameObject.Find("NewFile").GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        Buttons.transform.localScale = new Vector3(1, 0, 1); 
        //SceneManager.LoadScene(1);
    }
    /// <summary>
    /// 加载存档
    /// </summary>
    public void choiceLoad()
    {
        GameObject.Find("LoadFile").GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        Buttons.transform.localScale = new Vector3(1, 0, 1);
        //SceneManager.LoadScene(2);
       
    }
    /// <summary>
    /// 退出游戏
    /// </summary>
    public void choiceExit()
    {
        Buttons.transform.localScale = new Vector3(1, 0, 1);
        GameObject.Find("ExitImage").GetComponent<RectTransform>().localScale =new Vector3(1,1,1);
 ;
    }
    /// <summary>
    /// 游戏退出
    /// </summary>
    public void checkExit(bool my)
    {
        if (my)
        {
            //UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
        else
        {
            GameObject.Find("ExitImage").GetComponent<RectTransform>().localScale = new Vector3(1, 0, 1);
            choiceStart();
        }
       
    }
    /// <summary>
    /// 存档加载
    /// </summary>
    public void checkFile()
    {
        string fileName = Application.persistentDataPath + "/Save";
        if (controlData.IsFileExists(fileName + "/GameData1.sav"))
        {
            GameObject.Find("fileOne").GetComponentInChildren<Text>().text = "存档1";
            GameObject.Find("fileOne1").GetComponentInChildren<Text>().text = "存档1";
        }
        else
        {
            GameObject.Find("fileOne").GetComponent<Button>().interactable = false;
        }
        if(controlData.IsFileExists(fileName + "/GameData2.sav"))
        {
            GameObject.Find("fileTwo").GetComponentInChildren<Text>().text = "存档2";
            GameObject.Find("fileTwo1").GetComponentInChildren<Text>().text = "存档2";
        }
        else
        {
            GameObject.Find("fileTwo").GetComponent<Button>().interactable = false;
        }
        if (controlData.IsFileExists(fileName + "/GameData3.sav"))
        {
            GameObject.Find("fileThree").GetComponentInChildren<Text>().text = "存档3";
            GameObject.Find("fileThree1").GetComponentInChildren<Text>().text = "存档3";
        }
        else
        {
            GameObject.Find("fileThree").GetComponent<Button>().interactable = false;
        }
    }
    /// <summary>
    /// 存档覆盖确认
    /// </summary>
    public void checkNewFile(bool my)
    {
        if (my)
        {
            
            saveData.saveGame(myData.newDate(), myData.user);
            loadData.loadGame(myData.user);
        }
        else
        {
            choiceNew();
            GameObject.Find("CheckFile").GetComponent<RectTransform>().localScale = new Vector3(1, 0, 1);
        }
    }
    /// <summary>
    /// 覆盖存档
    /// </summary>
    /// <param name="index"></param>
    public void choiceFile(int index)
    {
        if ( index != 4 )
        {
            GameObject.Find("CheckFile").GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
     
        switch (index)
        {

            case 1:
                GameObject.Find("fileText").GetComponent<Text>().text = GameObject.Find("fileOne").GetComponentInChildren<Text>().text + "吗？";
                myData.user = 1;
                break;
            case 2:
                GameObject.Find("fileText").GetComponent<Text>().text = GameObject.Find("fileTwo").GetComponentInChildren<Text>().text + "吗？";
                myData.user = 2;
                break;
            case 3:
                GameObject.Find("fileText").GetComponent<Text>().text = GameObject.Find("fileThree").GetComponentInChildren<Text>().text + "吗？";
                myData.user = 3;
                break;
            case 4:
                choiceStart();
                break;
        }
        GameObject.Find("NewFile").GetComponent<RectTransform>().localScale = new Vector3(1, 0, 1);
    }
    /// <summary>
    /// 加载存档
    /// </summary>
    /// <param name="index"></param>
    public void loadFile(int index)
    {
        switch (index)
        {
            case 1:
                Debug.Log("加载存档1");            
                break;
            case 2:
                Debug.Log("加载存档2");
                break;
            case 3:
                Debug.Log("加载存档3");
                break;
            case 4:
                choiceStart();
                break;
        }
        if (index != 4)
        {
            loadData.loadGame(index);
           
        }
        GameObject.Find("LoadFile").GetComponent<RectTransform>().localScale = new Vector3(1, 0, 1);
    }

    /// <summary>
    /// 重新开始
    /// </summary>
    public void againGame()
    {
        Debug.Log("11");
        loadData.loadGame(myData.user);
    }

    /// <summary>
    /// 回到游戏
    /// </summary>
    public void backGame()
    {
        GameObject.Find("menu").GetComponent<menuUI>().cancelMenu();
    }
    /// <summary>
    /// 返回主界面
    /// </summary>
    public void begin()
    {
        SceneManager.LoadScene(0);
    }
}
