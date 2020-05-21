using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class plotUI : MonoBehaviour {

    // Use this for initialization
    void Start () {
        plotManager.Instance.AddCommand(new plotStart());
        plotManager.Instance.AddCommand(new plotDialog("Textues/GUITxetures/Header/portrait00_02", "云天河", "大家好，我就云天河！", 0));
        plotManager.Instance.AddCommand(new plotDialog("Textues/GUITxetures/Header/portrait20_02", "慕容紫英", "云天河！立刻滚到思返谷思过！立刻！", 1));
        plotManager.Instance.AddCommand(new plotDialog("Textues/GUITxetures/Header/portrait20_02", "慕容1", "12345678", 0));
        plotManager.Instance.AddCommand(new plotEnd());
     }
	
	// Update is called once per frame
	void Update () {



    }
}
