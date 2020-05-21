using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class No1Control : MonoBehaviour {
    GameObject fly;
    GameObject mite;
    GameObject spider;
    GameObject flymom;
    GameObject monster;

    private void Start()
    {
        fly = (GameObject)Resources.Load("fly");
        mite = (GameObject)Resources.Load("mite");
        spider = (GameObject)Resources.Load("spider");
        flymom = (GameObject)Resources.Load("flymom");

        StartCoroutine(No1Start());
    }
    IEnumerator No1Start()
    {
        yield return StartCoroutine(No1Point1());
        yield return StartCoroutine(No1Point2());
        yield return StartCoroutine(No1Point3());
        yield return StartCoroutine(No1Point4());
        yield return StartCoroutine(No1Point5());
    }

    //开始
    IEnumerator No1Point1()
    {
 
        yield return null;
    }

    //被子
    IEnumerator No1Point2()
    {
        monster = GameObject.Find("monster");
        while (transform.Find("plotPoint2")!=null)
        {
            if (GameObject.Find("fly") == null)
            {
                flyCreate(new Vector3(0, -1.82f, -3));
                flyCreate(new Vector3(2.81f, -2.9f, -3));
                flyCreate(new Vector3(5.02f, -1.82f, -3));
                flyCreate(new Vector3(6.84f, -2.9f, -3));
                }
            if(GameObject.Find("mite") == null)
            {
                miteCreate(new Vector3(20, -4, -3));
                miteCreate(new Vector3(12, -2.2f, -3));
                miteCreate(new Vector3(20, -0.12f, -3));
                miteCreate(new Vector3(12, 1.8f, -3));
            }

            yield return new WaitForSeconds(2f);
        }
            
    }

    //窗户
    IEnumerator No1Point3()
    {
        Destroy(monster);
        GameObject mons = new GameObject();
        mons.name = "monster";
        yield return null;
        monster = GameObject.Find("monster");
        //开窗放火球
        //烧窗帘s
        GameObject.Find("right").SetActive(false);
        
        while (transform.Find("plotPoint3")!=null)
        {
            if (GameObject.Find("fly") == null)
            {
                flyCreate(new Vector3(10, 12f, -3));
                flyCreate(new Vector3(12.75f, 14f, -3));
                flyCreate(new Vector3(15, 16f, -3));
                flyCreate(new Vector3(6.72f, 9.6f, -3));
            }
            yield return new WaitForSeconds(5f);
        }
    }
    
    //蜘蛛
    IEnumerator No1Point4()
    {
        GameObject a = Instantiate(spider, new Vector3(36.49f,18.73f,-3), Quaternion.identity, monster.transform);
        a.name = "spider";

        while (transform.Find("plotPoint4") != null)
        {
            yield return null;
        }
          
    }

    //坟墓
    IEnumerator No1Point5()
    {
        Debug.Log("5");
        while (transform.Find("plotPoint5") != null)
        {
            yield return null;
        }
    }

    //苍蝇
    IEnumerator No1Point6()
    {
        GameObject a = Instantiate(flymom, new Vector3(63.21f, 10.05f, -3), Quaternion.identity, monster.transform);
        a.name = "flymom";
        while (transform.Find("flymom") != null)
        {
            yield return null;
        }
    }
    void flyCreate(Vector3 ve)
    {
        GameObject a = Instantiate(fly, ve, Quaternion.identity, monster.transform);
        a.name = "fly";
    }
    void miteCreate(Vector3 ve)
    {
        GameObject a = Instantiate(mite, ve, Quaternion.identity, monster.transform);
        a.name = "mite";
       
    }
}
