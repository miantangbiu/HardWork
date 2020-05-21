using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createAttri : MonoBehaviour {

    //创建角色属性
    attriControl at = new attriControl();
    attriBuild ab = new xiaAttri();
    GameObject point;

    public attribute xia;
    int hp;
    float t;

    void Awake()
    {
        //构造
        xia = at.construct(ab);
        myData mydata;
        mydata = loadData.loadPlayer(myData.user);
        xia = mydata.playAttri;
        point = GameObject.Find(mydata.point);

    }
    void Start()
    {
       
       
        
        //Debug.Log(point);
        if(point == null)
        {
            transform.position = new Vector3(0,0,-3);
        }
        else
        {
            transform.position = new Vector3 (point.transform.position.x, point.transform.position.y,-3);
            
        }
        hp = xia.Hp;
        t = 0;
    }

    void Update()
    {

       
            hp = xia.Hp;
         
      
      
    }

}
