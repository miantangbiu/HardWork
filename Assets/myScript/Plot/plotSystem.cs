using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class plotSystem:MonoBehaviour
{
    private Text mytext;

    //  public Dictionary<Dialog , int> flotTable = new Dictionary<Dialog, int>();
    private static plotSystem instance;
    public static plotSystem Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<plotSystem>();
            return instance;
        }
    }
    private void Awake()
    {
   
    }
    private void Start()
    {
       
    }
    public void SetDialog(Dialog dialog, int index)
    {
        GameObject dialogBack;
        dialogBack = GameObject.Find("dialogBack");
        mytext = dialogBack.GetComponentInChildren<Text>();

        if (index == 0)
        {
            mytext.text = dialog.Content;
       
        }
        if (index == 1)
        {
            mytext.text = dialog.Content;
        }
    }
    
}