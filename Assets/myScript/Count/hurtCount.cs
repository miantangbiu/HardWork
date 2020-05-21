using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtCount{

    public static void hurt(int hurt,GameObject hurtman)
    {
        attribute manAttri;
        if (hurtman.tag == "Enemy" || hurtman.tag == "Player")
        {
            switch (hurtman.name)
            {
                case "xia":
                    manAttri = hurtman.GetComponent<createAttri>().xia;
                    break;
                case "dinosaur":
                case "spider":
                case "notebook":
                    manAttri = hurtman.GetComponent<bossOne>().bossOneAt;
                    break;
                case "flymom":
                    manAttri = hurtman.GetComponent<bossTwo>().bossTwoAt;
                    break;
                case "boss":
                    manAttri = hurtman.GetComponent<bossThree>().bossThreeAt;
                    break;
                default:
                    manAttri = hurtman.GetComponent<LV1>().LV1Att;
                    break;
            }
            manAttri.Hp = manAttri.Hp - hurt;

            if (hurt > 0)
            {
                numberShow.hurtShow(hurt, hurtman.transform.position);
                if(hurtman.tag == "Player")
                {
                    hurtman.GetComponent<SpriteRenderer>().color = Color.red;
                }
            

            }
            if (hurt < 0)
            {
                if (manAttri.Hp > manAttri.MaxHp)
                {
                    manAttri.Hp = manAttri.MaxHp;
                }
                numberShow.healShow(hurt, hurtman.transform.position);
            }
            
            if(hurtman.tag == "Enemy")
            {
                GameObject.Find("enemyCanvas").SendMessage("showAtt",manAttri);
            }
            
        }
        
           
    }
}
