using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public static class loadData {

    public static int getMaxScene(int index)
    {
        myData mydata;
        string dirpath = Application.persistentDataPath + "/Save";
        string filename;
        filename = dirpath + "/GameData" + index + ".sav";
        myData.user = index;
        mydata = (myData)controlData.GetData(filename, typeof(myData));
        int max = mydata.passNum;
        return max;
    }

    public static void loadGame(int index)
    {
        myData mydata;
        string dirpath = Application.persistentDataPath + "/Save";
        string filename;
        filename = dirpath + "/GameData" + index + ".sav";
        myData.user = index;

        mydata = (myData)controlData.GetData(filename, typeof(myData));
        SceneManager.LoadScene(mydata.sceneNum);
        
    }

    public static myData loadPlayer(int index)
    {
        myData mydata;
        string dirpath = Application.persistentDataPath + "/Save";
        string filename;
        filename = dirpath + "/GameData" + index + ".sav";

        mydata = (myData)controlData.GetData(filename, typeof(myData));
        return mydata;
    }

    public static float loadTime(int index)
    {
        myData mydata;
        string dirpath = Application.persistentDataPath + "/Save";
        string filename;
        filename = dirpath + "/GameData" + index + ".sav";

        mydata = (myData)controlData.GetData(filename, typeof(myData));
        return mydata.playTime;
    }
}
