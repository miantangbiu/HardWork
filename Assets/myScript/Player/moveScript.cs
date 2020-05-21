using UnityEngine;
using System.Collections;
using DragonBones;
using System.Collections.Generic;

public class moveScript : MonoBehaviour
{
    private Rigidbody2D rig;   //刚体
    private float jumpSpeed;  //跳跃的力
    private float horizontal;  //水平轴值
    private float moveSpeed; //水平移动速度绝对值
    private float move; //水平移动速度
    private int jumpTime;//跳跃次数

    private UnityArmatureComponent _playerArmature = null;//龙骨动画对象
  
    private bool isIgnore;//忽略层
    private bool _isJump;//跳跃状态
    private bool _isSqaut;//蹲状态
    private bool _isWalk;//行走状态
    private bool _isAttack;//攻击状态

    private DragonBones.AnimationState _walkState;
    private DragonBones.AnimationState _jumpState;


    private float t;//计时器

   // private Animator animator;//动画状态机

    private attribute myAttri;//角色属性对象

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();   //获取主角刚体组件
        //animator = GetComponent<Animator>();//获取动画状态机


        _playerArmature = GetComponent<UnityArmatureComponent>();
       
        
        _playerArmature.AddDBEventListener(EventObject.FRAME_EVENT, _OnAnimationEventHandler);
        
       
        _playerArmature.animation.Play("idle");

        


        myAttri = GetComponent<createAttri>().xia; //引用对象
        jumpSpeed = myAttri.JumpSpd;
        moveSpeed = myAttri.MoveSpd;

        t = 0;

        jumpTime = 1;//初始化跳跃次数

        isIgnore = false;
        _isJump = false;
        _isSqaut = false;
        _isWalk = false;
        _isAttack = false;

        _walkState = null;
        _jumpState = null;
        

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - 0.78f), Vector2.down * 0.1f, Color.red);
        

        if (Input.GetKeyDown(KeyCode.S))
        {
            isIgnore = true;
            Physics2D.IgnoreLayerCollision(9, 10, isIgnore);            
        }
        if (isIgnore)
        {
            timeDown();
        }
        else
        {
            Physics2D.IgnoreLayerCollision(9, 10, !onWhere("Terrace")); //碰撞忽视
        }

        if(Input.GetButton("Horizontal"))
        {
            _isWalk = true;
        }
        else if(Input.GetButtonUp("Horizontal"))
        {
            _isWalk = false;
        }

        if (Input.GetButtonDown("Jump"))//跳跃
        {
            
            playerJump();

        }
        playerMove();
        _updateJump();

    }
   
    void timeDown()
    {
        t += Time.deltaTime;
        if (t > 0.45f)
        {

            t = 0;
            isIgnore = false;
            
        }
    }
    
    void playerMove()
    {
        if (_isWalk)
        {
            if(_walkState == null)
            {
                _walkState = _playerArmature.animation.FadeIn("walk", -1.0f, -1, 0, "normal");
               
                _walkState.resetToPose = false;
             
            }

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
            if(_walkState != null)
            {
                _playerArmature.animation.Play("idle");
                _walkState = null;
            }
           
            rig.velocity = Vector2.zero;
        }
       

    }

    void playerJump()
    {
        if (onWhere("Earth") || onWhere("Terrace"))
        {
            rig.velocity = new Vector2(0,jumpSpeed);
            _jumpState =  _playerArmature.animation.FadeIn("jump", -1, 1, 0, "normal");
            _isJump = true;
        }
        
          
    }
      
    bool onWhere(string str)
    {
        Vector2 ve = new Vector2(transform.position.x, transform.position.y - 0.78f);
        //射线检测
        RaycastHit2D myray = Physics2D.Raycast(ve, Vector2.down, 0.1f);
        
        if (myray && myray.collider.tag == str)
        {
            return true;
        }
        return false;
    }

    void _OnAnimationEventHandler(string type, EventObject eventObject)
    {
        
        
    }

    void _updateJump()
    {
        if (_jumpState == null)
            return;
        //Debug.Log(_jumpState.name);
        if (_isJump)
        {
            switch (_jumpState.name)
            {
                case "jump":
                    if (_jumpState.isCompleted == true)
                    {
                        _jumpState = _playerArmature.animation.FadeIn("jumpup", -1f, -1, 0, "normal");
                    }
                    break;
                case "jumpup":
                    if(rig.velocity.y <= 0.5f)
                    {
                        _jumpState = _playerArmature.animation.FadeIn("jumpturn", -1f, 1, 0, "normal");
                    }
                    break;

                case "jumpturn":
                    if(_jumpState.isCompleted == true)
                    {
                        _jumpState = _playerArmature.animation.FadeIn("jumpdown", -1f, -1, 0, "normal");
                    }
                    break;
             
                case "jumpdown":
                    if (onWhere("Earth") || onWhere("Terrace"))
                    {
                        _jumpState = _playerArmature.animation.FadeIn("fall", -1f, 1, 0, "normal");                        
                    }
                    break;
                case "fall":
                    if(_jumpState.isCompleted == true)
                    {
                        _jumpState = null;
                        _isJump = false;
                    }
                    break;
                case "":
                    _jumpState = null;
                    break;
            }
                
        }
    }
}

