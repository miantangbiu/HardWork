using UnityEngine;
using System.Collections;

public static class saveData
{
    public static bool saveGame(myData mydate,int index)
    {
        if (mydate == null )
            return false;
        string directoryName = Application.persistentDataPath + "/Save";
        string filename =  "/GameData"+index + ".sav";
        Debug.Log(Application.persistentDataPath);
        controlData.SetData(directoryName,filename, mydate);
        Debug.Log("保存成功");
        return true;
    }
}