using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class numberShow :MonoBehaviour{

    //private static Text text;
    public static void hurtShow(int hurtNum,Vector2 pos)
    {
        GameObject text = (GameObject)Resources.Load("hurt");
        Text mytext=Instantiate(text).GetComponent<Text>();
        mytext.color = Color.red;
        mytext.transform.SetParent(GameObject.Find("tips").transform);
        mytext.rectTransform.position = Camera.main.WorldToScreenPoint(pos);
        mytext.text = "-" + hurtNum;

    }

    public static void healShow(int hurtNum, Vector2 pos)
    {
        GameObject text = (GameObject)Resources.Load("hurt");
        Text mytext = Instantiate(text).GetComponent<Text>();
        mytext.color = Color.green;
        mytext.transform.SetParent(GameObject.Find("tips").transform);
        mytext.rectTransform.position = Camera.main.WorldToScreenPoint(pos);
        mytext.text = "+" + hurtNum;

    }
}
