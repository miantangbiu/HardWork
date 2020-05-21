using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class No2Control : MonoBehaviour {
    GameObject p0;
    float mytime;
	// Use this for initialization
	void Start () {
        p0 = GameObject.Find("point0");
        StartCoroutine(No2Start());
        mytime = 0;
	}
	
	// Update is called once per frame
	void Update () {
        mytime = Camera.main.GetComponent<timeCount>().t;
	}

    IEnumerator No2Start()
    {
        yield return StartCoroutine(No2Point6());
        yield return StartCoroutine(No2Point7());
        yield return StartCoroutine(No2Point8());
    }
    IEnumerator No2Point6()
    {
        p0.SetActive(false);
        while (transform.Find("plotPoint7") != null)
        {
            if (mytime > 10)
            {
                GameObject.Find("xia").GetComponent<createAttri>().xia.Hp = 0;
            }
            yield return null;
        }
        
    }
    IEnumerator No2Point7()
    {
        mytime = 0;
        Debug.Log("开始");
        //上午班
        while (mytime <  150)
        {
            Debug.Log("上班");
            yield return null;
        }
        //午饭时间
        
        while (150< mytime&& mytime <  270)
        {
            Debug.Log("午饭");
            yield return null;
        }
        Debug.Log("11");
        //下午班
        while (270 < mytime && mytime < 510)
        {
            Debug.Log("下午班");
            yield return null;
        }
        //晚饭时间
        while ( 270 < mytime && mytime < 510)
        {
            Debug.Log("晚饭");
            yield return null;
        }
        //加班
        while (510 < mytime && mytime <  720)
        {
            Debug.Log("加班");
            yield return null;
        }
    }
    IEnumerator No2Point8()
    {
        p0.SetActive(true);
        yield return null;
    }
  
}
