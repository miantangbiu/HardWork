using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeCount : MonoBehaviour {
    public float t;
    Text mytext;
    bool  i;
    // Use this for initialization
    private void Awake()
    {
        t = 0;
    }
    void Start () {
        mytext = GameObject.Find("timeText").GetComponent<Text>();
        t = loadData.loadTime(myData.user);
    }
   
    // Update is called once per frame
    void Update (){

        t += Time.deltaTime;
        mytext.text = "<size=24><b>Time</b></size> "+(int)t/60+":"+(int)t%60;
     
    }
 
}


