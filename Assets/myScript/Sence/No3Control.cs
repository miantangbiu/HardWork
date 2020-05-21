using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class No3Control : MonoBehaviour {
    GameObject p9, p10, p11, p12, p13, p14, p15,p16;
    GameObject ob ,ob1, ob2, ob3, ob4, ob5, ob6;
    GameObject ear;
    GameObject dark;
    GameObject dino;
	// Use this for initialization
	void Start () {
        p9 = transform.Find("plotPoint9").gameObject;
        p10 = transform.Find("plotPoint10").gameObject;
        p11 = transform.Find("plotPoint11").gameObject;
        p12 = transform.Find("plotPoint12").gameObject;
        p13 = transform.Find("plotPoint13").gameObject;
        p14 = transform.Find("plotPoint14").gameObject;
        p15 = transform.Find("plotPoint15").gameObject;
        p16 = transform.Find("plotPoint16").gameObject;

        ob = GameObject.Find("Object");

        ob1 = ob.transform.Find("computer").gameObject;
        ob2 = ob.transform.Find("cloth").gameObject;
        ob3 = ob.transform.Find("pen").gameObject;
        ob4 = ob.transform.Find("picture").gameObject;
        ob5 = ob.transform.Find("handle").gameObject;
        ob6 = ob.transform.Find("toy").gameObject;

        dino = (GameObject)Resources.Load("dinosaur");

        ear = GameObject.Find("up");
        dark = GameObject.Find("dark");

        p10.SetActive(false);
        p11.SetActive(false);
        p12.SetActive(false);
        p13.SetActive(false);
        p14.SetActive(false);
        p15.SetActive(false);
        p16.SetActive(false);

        ob1.SetActive(false);
        ob2.SetActive(false);
        ob3.SetActive(false);
        ob4.SetActive(false);
        ob5.SetActive(false);
        ob6.SetActive(false);

        StartCoroutine(No2Start());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator No2Start()
    {
        yield return StartCoroutine(No2Point9());
        yield return StartCoroutine(No2Point10());
        yield return StartCoroutine(No2Point11());
        yield return StartCoroutine(No2Point12());
        yield return StartCoroutine(No2Point13());
        yield return StartCoroutine(No2Point14());
        yield return StartCoroutine(No2Point15());
    }
    //初始
    IEnumerator No2Point9()
    {
        while (p9 != null)
        {
            Debug.Log("1");
            yield return null;
        }
       
        
    }
    //找电脑
    IEnumerator No2Point10()
    {
        ob1.SetActive(true);
        p10.SetActive(true);
        while (p10 != null)
        {
            yield return null;
        }
        ear.transform.position = new Vector3(39.72f,7,-1);
        dark.transform.localScale = new Vector3(1.5f,1.5f,1);
        ob1.SetActive(false);
    }
    //找校服
    IEnumerator No2Point11()
    {
        ob2.SetActive(true);
        p11.SetActive(true);
        while (p11 != null)
        {
            yield return null;
        }
        ear.transform.position = new Vector3(39.72f, 6, -1);
        dark.transform.localScale = new Vector3(2f,2f, 1);
        ob2.SetActive(false);
    }
    //找彩笔
    IEnumerator No2Point12()
    {
        ob3.SetActive(true);
        p12.SetActive(true);
        while (p12 != null)
        {
            yield return null;
        }
        ear.transform.position = new Vector3(39.72f, 5, -1);
        dark.transform.localScale = new Vector3(2.5f, 2.5f, 1);
        ob3.SetActive(false);
    }
    //找全家福
    IEnumerator No2Point13()
    {
        ob4.SetActive(true);
        p13.SetActive(true);
        while (p13!= null)
        {
            yield return null;
        }
        ear.transform.position = new Vector3(39.72f, 2, -1);
        dark.transform.localScale = new Vector3(3f, 3f, 1);
        ob4.SetActive(false);
    }

    //找手柄
    IEnumerator No2Point14()
    {
        ob5.SetActive(true);
        p14.SetActive(true);
        while (p14!= null)
        {
            yield return null;
        }
        ear.transform.position = new Vector3(39.72f, 0, -1);
        dark.transform.localScale = new Vector3(3.5f, 3.5f, 1);
        ob5.SetActive(false);
    }
    //击败boss

    IEnumerator No2Point15()
    {
        p15.SetActive(true);
        GameObject a=  Instantiate(dino, new Vector3(59.92f, 10.5f, -1), Quaternion.identity);
        a.name = "dinosaur";
        while (p15 != null)
        {
            yield return null;
        }
    }
    //获得玩具
    IEnumerator No2Point16()
    {
        ob6.SetActive(true);
        p16.SetActive(true);
        ob6.SetActive(true);
        while (p16 != null)
        {
            yield return null;
        }
        
    }
}
