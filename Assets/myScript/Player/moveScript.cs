using UnityEngine;
using System.Collections;
using DragonBones;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class moveScript : MonoBehaviour
{
    //预设体
    private GameObject bullet;
    private GameObject ray;
    private GameObject fire;
    private GameObject arrow;
    //组件
    CapsuleCollider2D myCollider;
    Image imaOne, imaTwo;

    private Rigidbody2D rig;   //刚体
    private attribute myAttri;//角色属性对象
    private UnityArmatureComponent _playerArmature = null;//龙骨动画对象

    //本地 数值
    private float jumpSpeed;  //跳跃的力
    private float horizontal;  //水平轴值
    private float moveSpeed; //水平移动速度绝对值
    public float bulletSpd;
    private float move; //水平移动速度
    public int jumpCount;//跳跃次数

    //标记
    private bool isWalk;//行走状态
    private bool isJump;//跳跃状态
    private bool isSquat;//蹲状态
    private bool isIgnore;//忽略层
    //public bool isHit;
    private bool isFire;//攻击状态
    private bool isSkillO;//技能1
    private bool isSkillT;//技能2

    //动画状态
    private DragonBones.AnimationState _walkState;
    private DragonBones.AnimationState _jumpState;
    private DragonBones.AnimationState _attackState;
    private DragonBones.AnimationState _hitState;

    //CD
    float fireCD;
    float skillOneCD;
    float skillTwoCD;

    float t;//倒计时
    private float t1;//计时器

    


    private void Awake()
    {
        isIgnore = false;
        isJump = false;
        isSquat = false;
        isWalk = false;
        isFire = false;
       // isHit = false;
        isSkillO = false;
        isSkillT = false;

        _walkState = null;
        _jumpState = null;
        _attackState = null;
        

        t = 0;

    }
    void Start()
    {
        //预设
        bullet = (GameObject)Resources.Load("bull");
        ray = (GameObject)Resources.Load("ray");
        fire = (GameObject)Resources.Load("fire");
        arrow = (GameObject)Resources.Load("arrow");

        imaOne = GameObject.Find("skillOne").GetComponent<Image>();
        imaTwo = GameObject.Find("skillTwo").GetComponent<Image>();

        myCollider = GetComponent<CapsuleCollider2D>();

        rig = GetComponent<Rigidbody2D>();   //获取主角刚体组件

        _playerArmature = GetComponent<UnityArmatureComponent>();

        _playerArmature.AddDBEventListener(EventObject.FRAME_EVENT, _OnAnimationEventHandler);

        _playerArmature.animation.Play("idle");

        myAttri = GetComponent<createAttri>().xia; //引用对象
        //设置角色数据
        jumpSpeed = myAttri.JumpSpd;
        moveSpeed = myAttri.MoveSpd;
        bulletSpd = 10;

        
        //设置技能限制
        jumpCount = 1;//初始化跳跃次数
        skillOneCD = 3f;
        skillTwoCD = 5f;

    }

   

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - 0.7f), Vector2.down * 0.2f, Color.red);
        
        //下蹲与下跳
        if (Input.GetKey(KeyCode.S) && !isJump)
        {
            isSquat = true;           
            if (Input.GetKeyDown(KeyCode.K))
            {
                isIgnore = true;
                Physics2D.IgnoreLayerCollision(9, 10, isIgnore);
            }
        }
        if (isIgnore)
        {
            timeDown(0.45f);
        }
        else
        {
            Physics2D.IgnoreLayerCollision(9, 10, !onWhere("Terrace")); //碰撞忽视
        }

        if (Input.GetKeyUp(KeyCode.S))
            isSquat = false;

        //水平行走
        if(Input.GetButton("Horizontal"))
        {
            isWalk = true;
        }
        else if(Input.GetButtonUp("Horizontal"))
        {
            isWalk = false;
        }

        //跳跃
        if (Input.GetButtonDown("Jump")&&(onWhere("Earth") || onWhere("Terrace")))
        {
            isJump = true;
        }


        //普通攻击
        if (isFire)
        {
            timeDown(fireCD);
        }
        else if (Input.GetKeyDown(KeyCode.J) || Input.GetKey(KeyCode.J))
        {
            isFire = true;
        }

        //技能1：激光
        if (Input.GetKeyDown(KeyCode.U) & imaOne.fillAmount == 0)
        {
            isSkillO = true;
        }

        //技能2：弹幕
        if (Input.GetKeyDown(KeyCode.I) & imaTwo.fillAmount == 0)
        {
            isSkillT = true;
        }

        //技能倒计时
        if (imaOne.fillAmount != 0)
        {
            imaOne.fillAmount -= Time.deltaTime / skillOneCD;
        }
        if (imaTwo.fillAmount != 0)
        {
            imaTwo.fillAmount -= Time.deltaTime / skillTwoCD;
        }

        _updateWalk();
        _updateJump();
        _updateAttack();
      //  _updateHit();

       
       
        //Debug.Log("walk:" + isWalk);
        //Debug.Log("jump:" + isJump);
        //Debug.Log("squat:"+ isSquat);
        //Debug.Log("sk1:" + isSkillO);
        //Debug.Log("sk2:" + isSkillT);
        //Debug.Log("fire:" + isFire);
       // Debug.Log("hit:" + isHit);
    }

    private void FixedUpdate()
    {
        playerMove();
      

    }

    //倒计时
    void timeDown(float i)
    {

        t += Time.deltaTime;
        if (t >= i)
        {
            isIgnore = false;
            isFire = false;
            t = 0;

        }
    }
    
    void playerMove()
    {
        if (isWalk)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            move = horizontal * moveSpeed;
            rig.velocity = new Vector2(move, rig.velocity.y);
            
            if (horizontal < 0)
            {
                this.transform.localScale = new Vector3(-1,1,0);
            
            }
            else if (horizontal >0)
            {
                this.transform.localScale = new Vector3(1, 1, 0);
             }
        }
        else
        {
            rig.velocity = new Vector2(0,rig.velocity.y);
        }
       

    }

    void _updateHit()
    {
        //if (_hitState != null && _hitState.name == "")
        //    _hitState = null;
        //if (isHit && (_hitState == null || _hitState.name != "hit"))
        //{
        //    Debug.Log("1");
        //    _hitState = _playerArmature.animation.Play("hit", 1);
        //    isHit = false;
        //}
       
    }
    
    void _updateJump()
    {
        if (_jumpState != null && _jumpState.name == "")
            _jumpState = null;

        if (isJump)
        {
            if ( _jumpState == null )
            {
                isSquat = false;
                _jumpState = _playerArmature.animation.Play("jump", 1);
                rig.velocity = new Vector2(rig.velocity.x, jumpSpeed);
            }
            if ( _jumpState != null)
            {
                switch (_jumpState.name)
                {
                    case "jump":
                        if (_jumpState.isCompleted == true)
                        {
                            _jumpState = _playerArmature.animation.FadeIn("jumpup",-1, -1,0);
                        }
                        break;
                    case "jumpup":
                        if(rig.velocity.y <= 0.5f)
                        {
                            _jumpState = _playerArmature.animation.FadeIn("jumpturn", -1,1,0);
                        }
                        break;

                    case "jumpturn":
                        if(_jumpState.isCompleted == true)
                        {
                            _jumpState = _playerArmature.animation.FadeIn("jumpdown", -1,-1,0);
                        }
                        break;
             
                    case "jumpdown":
                        if (onWhere("Earth") || onWhere("Terrace"))
                        {
                            isJump = false;                        
                            _jumpState = _playerArmature.animation.FadeIn("fall",-1,1,0);                        
                        }
                        break;
                    case "fall":
                        if(_jumpState.isCompleted == true)
                        {
                            _jumpState = null;
                        }
                        break;
             
                }
           
            }
        

        }

        if (isSquat && !isJump)
        {
            _jumpState = _playerArmature.animation.Play("squating");
        }
        
        
    }

    void _updateAttack()
    {
        if (_attackState != null && _attackState.name == "")
            _attackState = null;
        if(_attackState == null) { 
        
            if (isFire)
            {
                _attackState = _playerArmature.animation.FadeIn("attack", -1, 1, 2, "attack");
                _attackState.timeScale = myAttri.AtkSpd;
                //_fireState.resetToPose = false;

            }
            else if(isSkillO)
            {
                _attackState = _playerArmature.animation.FadeIn("skillOne", -1, 1, 2, "skill");
            }
            else if(isSkillT)
            {
                _attackState = _playerArmature.animation.FadeIn("skillTwo", -1, 1, 2, "skill");
            }
        }
        
        if(_attackState != null  && _attackState.isCompleted)
        {
            isSkillO = false;
            isSkillT = false;
            _attackState = null;
        }

    }

    void _updateWalk()
    {
        if (!(isWalk || isSquat || isJump) && _walkState != null && _walkState.name != "idle")
        {

            _walkState = _playerArmature.animation.Play("idle");
        }
        

     
        if (isWalk &&(_walkState == null || _walkState.name != "walk") && _jumpState == null)
        {
          
            _walkState = _playerArmature.animation.FadeIn("walk", -1, -1, 1);
        }

           
        
        
    }

    //fire
    private void attack()
    {
        //加载预设体资源           
        GameObject bulletObject = Instantiate(bullet, transform.position, transform.rotation);
        Rigidbody2D rig2 = bulletObject.GetComponent<Rigidbody2D>();
        rig2.velocity = new Vector2(transform.localScale.x * bulletSpd, 0);
        bulletObject.transform.localScale = transform.localScale;

        Destroy(bulletObject, myAttri.AtkRange/bulletSpd);
    }
    private void skillOne()
    {
        Vector3 ve;
        ve = new Vector3(transform.position.x + myCollider.size.x+0.2f,
              transform.position.y - 0.2f,
              transform.position.z
              );
        if (transform.localScale.x == -1)
        {
            ve = new Vector3(
                transform.position.x - (myCollider.size.x+0.2f),
                transform.position.y -0.2f,
                transform.position.z
                );
        }

        Instantiate(fire, ve,transform.rotation, gameObject.transform);
        Instantiate(ray, ve, transform.rotation, gameObject.transform);
        imaOne.fillAmount = 1;

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
        ar2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -10);
        ar3.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
        ar4.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
        imaTwo.fillAmount = 1;
    }

    private void _OnAnimationEventHandler(string type, EventObject eventObject)
    {
        switch (eventObject.name)
        {
            case "fire":
                attack();
                break;
            case "skillOne":
                skillOne();
                break;
            case "skillTwo":
                skillTwo();
                break;
        }
    }


    bool onWhere(string str)
    {
        Vector2 ve = new Vector2(transform.position.x, transform.position.y - 0.7f);
        //射线检测

        RaycastHit2D[] rays = Physics2D.RaycastAll(ve, Vector2.down, 0.2f);

        foreach (var re in rays)
        {
            if (re.collider.tag == str)
            {
                return true;
            }
        }
        return false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Rope")
        {
            
            if (Input.GetButton("Vertical"))
            {
                transform.position = new Vector2(collision.transform.position.x, transform.position.y);
                rig.gravityScale = 0;
                rig.velocity = Vector2.zero;
            }

            float a = Input.GetAxisRaw("Vertical");
            transform.position = new Vector2(transform.position.x,transform.position.y+(0.02f*a));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Rope")
        {
            rig.gravityScale = 1;
        }
    }
}

