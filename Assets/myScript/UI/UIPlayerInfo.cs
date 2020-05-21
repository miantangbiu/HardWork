using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerInfo:MonoBehaviour
{

    private Image image;
    private attribute playerAtt;

    void Start()
    {

        image = GameObject.Find("hp").GetComponent<Image>();
        playerAtt = GameObject.Find("player").GetComponent<createAttri>().xia;
        //StartCoroutine(fx());

    }

    private void Update()
    {
        
        if (image != null && playerAtt != null)
        {
            image.fillAmount = (float)playerAtt.Hp/playerAtt.MaxHp;

        }
           
    }
  
}
