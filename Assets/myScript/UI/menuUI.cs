using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuUI : MonoBehaviour {

    GameObject menu;
    GameObject button;
    
    bool isClose;
    Text mytext;
 
    attribute playerAtt;

	// Use this for initialization
	void Start () {
        isClose = false;
        mytext = GameObject.Find("message").GetComponent<Text>();
        playerAtt = GameObject.Find("player").GetComponent<createAttri>().xia;
        button = GameObject.Find("back");


    }
	
	// Update is called once per frame
	void Update () {

        if (isClose)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                cancelMenu();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                mytext.text = "暂停";
                gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
                isClose = true;
            }
        }

        if (playerAtt!=null &&playerAtt.Hp <= 0)
        {
            button.SetActive(false);
            Time.timeScale = 0;
            mytext.text = "啊哦，没血了";
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            isClose = true;

        }
    }
    
    public void cancelMenu()
    {
        Time.timeScale = 1;
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 550);
        isClose = false;
    }
}
