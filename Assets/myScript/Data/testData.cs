using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class testData : MonoBehaviour
{
    private attribute player;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if(collision.gameObject.tag == "Player")
        {
           
            player = GameObject.Find("xia").GetComponent<createAttri>().xia;
            myData mydate = new myData(player, 1, "point1", Time.time,1);

            Debug.Log(Application.persistentDataPath);
            //定义存档路径
            string dirpath = Application.persistentDataPath + "/Save";
            //创建存档文件夹
            controlData.CreateDirectory(dirpath);
            //定义存档文件路径
            string filename = "/GameData1.sav";
            //保存数据
            controlData.SetData(dirpath,filename, mydate);
            //读取数据
            myData t1 = (myData)controlData.GetData(filename, typeof(myData));

      
           
        }
    }
}
