using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnemyInfo : MonoBehaviour {
   
    private float amount;
    private Image image;
    private RectTransform rect;
    private float y;
    Coroutine a;
    


    public void Awake()
    {
        amount = 1f;
        rect = GameObject.Find("enemyCanvas").GetComponent<RectTransform>();
        image = GameObject.Find("EHP").GetComponent<Image>();
        y = rect.anchoredPosition.y;
    
    }

    public void Update()
    {

        if (amount == 0)
        {
         
            rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, y);
        }
    }

    public void showAtt(attribute att)
    {
        if(a != null)
        {
            StopCoroutine(a);
        }
        rect.anchoredPosition = new Vector2(rect.anchoredPosition.x,220);
        
        image.fillAmount = (float)att.Hp / att.MaxHp;
        this.amount = image.fillAmount;
        a = StartCoroutine(timeDown());
    }
    IEnumerator timeDown()
    {
        yield return new WaitForSeconds(3f);
        rect.anchoredPosition = new Vector2(rect.anchoredPosition.x,y);
    }
}
