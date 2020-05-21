using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myData {

    public attribute playAttri;
    public int sceneNum;
    public string point;
    public float playTime;
    public static int user;
    public int passNum;

    public myData(attribute playAttri, int sceneNum, string point, float playTime,int passNum)
    {
        this.playAttri = playAttri;
        this.sceneNum = sceneNum;
        this.point = point;
        this.playTime = playTime;
        this.passNum = passNum;
    }

    public static myData newDate()
    {
        myData mydate;
        attribute player;
        attriControl attriCon = new attriControl();
        attriBuild attriBu = new xiaAttri();
        player = attriCon.construct(attriBu);
        int sceneNum = 2;
        string point = "point1";
        float myTime = 0;
        int pNum = 1;
        mydate = new myData(player,sceneNum, point, myTime,pNum);
        return mydate;
    }

}
