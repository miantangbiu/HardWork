using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fireScript : MonoBehaviour
{
    //预设体
    private GameObject bullet;
    private GameObject ray;
    private GameObject fire;
    private GameObject arrow;
    //组件
    Animator anima;
    CapsuleCollider2D myCollider;
    Image imaOne,imaTwo;

    attribute myAttri;

    //标记
    bool isfire;
    bool skillO;
    bool skillT;

    //CD
    float skillOneCD;
    float skillTwoCD;

    float t;//倒计时


   
    // Use this for initialization

    void Start()
    {
        bullet = (GameObject)Resources.Load("bull");
        ray = (GameObject)Resources.Load("ray");
        fire = (GameObject)Resources.Load("fire");
        arrow = (GameObject)Resources.Load("arrow");

        imaOne = GameObject.Find("skillOne").GetComponent<Image>();
        imaTwo = GameObject.Find("skillTwo").GetComponent<Image>();
        anima = GetComponent<Animator>();
        myCollider = GetComponent<CapsuleCollider2D>();

        myAttri = GameObject.Find("player").GetComponent<createAttri>().xia;
     
        isfire = false;
        skillO = true;
        skillT = true;

        skillOneCD = 3f;
        skillTwoCD = 5f;

        t = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if(imaOne.fillAmount != 0)
        {
            imaOne.fillAmount -= Time.deltaTime / skillOneCD;
        }

        if (imaTwo.fillAmount != 0)
        {
            imaTwo.fillAmount -= Time.deltaTime / skillTwoCD;
        }

        if (Input.GetKeyDown(KeyCode.U)&skillO)
        {
            skillOne();
        }

        if (Input.GetKeyDown(KeyCode.I) &skillT)
        {
            skillTwo();
        }

        if (isfire)
        {
            timeDown();
        }
        else if (Input.GetKeyDown(KeyCode.J) || Input.GetKey(KeyCode.J))
        {
            attack();
        }
        
    }

    private void attack()
    {
        //加载预设体资源           
        GameObject bulletObject = Instantiate(bullet, transform.position, transform.rotation);
        Rigidbody2D rig2 = bulletObject.GetComponent<Rigidbody2D>();
        rig2.AddForce(new Vector2(transform.localScale.x * 500f, 0));
        bulletObject.transform.localScale = transform.localScale;
        
        isfire = true;
        Destroy(bulletObject, 10f);
    }
    private void skillOne()
    {
        Vector3 ve;
        Quaternion qua;
        RaycastHit2D myhit = Physics2D.Raycast(transform.position, Vector2.right, 30f);
        qua = transform.rotation;
        ve = new Vector3(transform.position.x + myCollider.size.x,
              transform.position.y - 0.1f,
              transform.position.z
              );
        if (transform.localScale.x == -1)
        {
            qua = new Quaternion(
                transform.rotation.x,
                180,
                transform.rotation.z,
                transform.rotation.w
                );
            ve = new Vector3(
                transform.position.x - myCollider.size.x,
                transform.position.y - 0.1f,
                transform.position.z
                  );
        }
      
        Instantiate(fire, ve, qua, this.gameObject.transform);
        Instantiate(ray, ve, qua, this.gameObject.transform);
        skillO = false;
        CDTime(skillOneCD);
        
    }

    private void skillTwo()
    {
        Quaternion quaUp = Quaternion.Euler(0, 0, 90);
        Quaternion quaDown = Quaternion.Euler(0, 0, 270);
        Quaternion quaLeft = Quaternion.Euler(0, 0, 180);
        Quaternion quaRight = Quaternion.Euler(0, 0, 0);

        GameObject ar1 = Instantiate(arrow, transform.position, quaUp);
        GameObject ar2 = Instantiate(arrow, transform.position, quaDown);
        GameObject ar3 = Instantiate(arrow, transform.position, quaLeft);
        GameObject ar4 = Instantiate(arrow, transform.position, quaRight);

        ar1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10);
        ar2.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-10);
        ar3.GetComponent<Rigidbody2D>().velocity = new Vector2(-10,0);
        ar4.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);

        skillT = false;
        CDTime(skillTwoCD);
    }
    bool timeDown()
    {
        
        t += Time.deltaTime;
        if (t >= 1f / myAttri.AtkSpd)
        {
         
            isfire = false;
            t = 0;
           
        }
        return false;
    }

    void CDTime(float a)
    {
        
        StartCoroutine(skill(a));
     }

    IEnumerator skill(float a)
    {
        if (a == skillOneCD)
        {
            imaOne.fillAmount = 1;
        }
        else if (a == skillTwoCD)
        {
            imaTwo.fillAmount = 1;
        }
     
        yield return new WaitForSeconds(a);
        if (a == skillOneCD)
        {
            skillO = true;
        }
        else if(a == skillTwoCD){
            skillT = true;
        }
        
    }
}
