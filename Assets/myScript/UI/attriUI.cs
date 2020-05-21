using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attriUI : MonoBehaviour {

    GameObject attUI;
    attribute att;
    bool isClose;

    // Use this for initialization
    void Start()
    {
        isClose = false;
        att = GameObject.Find("player").GetComponent<createAttri>().xia;
    }

    // Update is called once per frame
    void Update()
    {

        if (isClose)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(200, -50);
                isClose = false;
            }
           
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-200, -50);
                isClose = true;
            }
            GameObject.Find("hpnum").GetComponent<Text>().text = "" + att.Hp;
            GameObject.Find("atknum").GetComponent<Text>().text = "" + att.Atk;
            GameObject.Find("atkspdnum").GetComponent<Text>().text = "" + att.AtkSpd;
            GameObject.Find("atkrannum").GetComponent<Text>().text = "" + att.AtkRange;
            GameObject.Find("movspdnum").GetComponent<Text>().text = "" + att.MoveSpd;
        }
    }
}
