using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class plotStart : plotCommand
{
    private RectTransform rect;
    public override void Execute()
    {
        rect = GameObject.Find("dialogBack").GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(0,50);
        Time.timeScale = 0;
    }
}


public class plotEnd : plotCommand
{
    private RectTransform rect;
    public override void Execute()
    {
        rect = GameObject.Find("dialogBack").GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(-1000, 0);
        Time.timeScale = 1;
    }
}