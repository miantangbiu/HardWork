using UnityEngine;
using UnityEngine.UI;



public class playerScript : MonoBehaviour
{
    //预设体
    private GameObject bullet;
    private GameObject ray;
    private GameObject fire;
    private GameObject arrow;

    //组件
    BoxCollider2D boxCollider;
    CircleCollider2D circleCollider;

    //技能图标
    Image imaOne, imaTwo;

    private Rigidbody2D rig;   //刚体
    private attribute myAttri;//角色属性对象
    private Animator ani;

    //本地 数值
    private float jumpSpeed;  //跳跃的力
    private float horizontal;  //水平轴值
    private float moveSpeed; //水平移动速度绝对值
    private float fireSpd;
    private float move; //水平移动速度
    public int jumpCount;//跳跃次数

    //标记
    private bool isWalk;//行走状态
    private bool isJump;//跳跃状态
    private bool isSquat;//蹲状态
    private bool isIgnore;//忽略层
    public bool isHit;
    private bool isFire;//攻击状态
    private bool isSkillO;//技能1
    private bool isSkillT;//技能2
    private bool isCD;

      //CD
    float fireCD;
    float skillOneCD;
    float skillTwoCD;

    float t;//倒计时
     


    private void Awake()
    {
        isIgnore = false;
        isJump = false;
        isSquat = false;
        isWalk = false;
        isFire = false;
        isHit = false;
        isSkillO = false;
        isSkillT = false;
        isCD = false;

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

        boxCollider = GetComponent<BoxCollider2D>();
        circleCollider = GetComponent<CircleCollider2D>();

        rig = GetComponent<Rigidbody2D>();   //获取主角刚体组件

        ani = GetComponent<Animator>();


        myAttri = GetComponent<createAttri>().xia; //引用对象
        //设置角色数据
        jumpSpeed = myAttri.JumpSpd;
        moveSpeed = myAttri.MoveSpd;
        fireSpd = myAttri.AtkSpd;
        fireCD = 1 / fireSpd;

        
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
            TimeDown(0.45f);
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
        if (isJump ==false && Input.GetButtonDown("Jump"))
        {
            isJump = true;
        }

      
        if (Input.GetKeyDown(KeyCode.J) || Input.GetKey(KeyCode.J))
        {
            if (!isCD)
                isFire = true;
            else
                isFire = false;
            isCD = true;
            TimeDown(fireCD);
        }

        //技能1：激光
        if (Input.GetKeyDown(KeyCode.U) && imaOne.fillAmount == 0)
        {
            isSkillO = true;
        }
       

        //技能2：弹幕
        if (Input.GetKeyDown(KeyCode.I) && imaTwo.fillAmount == 0)
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


        UpdateAnimation();
       
       
     }

    private void FixedUpdate()
    {
        PlayerMove();
        Attack();
      
    }

    //倒计时
    void TimeDown(float i)
    {
        t += Time.deltaTime;
        if (t >= i)
        {
            isCD = false;
        }
    }
    
    void PlayerMove()
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

        if (isJump)
        {
            rig.velocity = new Vector2(rig.velocity.x, jumpSpeed);
            isJump = false;
        }
        
    }

  
    
    void UpdateAnimation()
    {
        if (isWalk)
        {
            ani.SetBool("isWalk", true);
        }
        else
        {
            ani.SetBool("isWalk", false);
        }

        if (isJump)
        {
            ani.SetBool("isJump", true);
        }
        if((onWhere("Terrace")||onWhere("Earth"))&&!isJump)
        {
            ani.SetBool("isJump", false);
        }

        if (isSquat)
        {
            ani.SetBool("isSquat", true);
        }
        else
        {
            ani.SetBool("isSquat", false);
        }
        
        if (isHit)
        {
            ani.SetBool("isHit", true);
        }
        else
        {
            ani.SetBool("isHit", false);
        }

        if (isFire)
        {
            ani.SetFloat("fireSpd", fireSpd);
            ani.SetBool("isFire", true);
        }
        else
        {
            ani.SetBool("isFire", false);
        }

        if (isSkillO)
        {
            ani.SetBool("isSkillO", true);
        }
        else
        {
            ani.SetBool("isSkillO", false);
        }
        if (isSkillT)
        {
            ani.SetBool("isSkillT", true);
        }
        else
        {
            ani.SetBool("isSkillT", false);
        }


    }
  
    //fire
    private void Attack()
    {
        
        GameObject bulletObject = Instantiate(bullet, transform.position, transform.rotation);
        Rigidbody2D rig2 = bulletObject.GetComponent<Rigidbody2D>();
        rig2.velocity = new Vector2(transform.localScale.x * fireSpd, 0);
        bulletObject.transform.localScale = transform.localScale;
        Destroy(bulletObject, myAttri.AtkRange / fireSpd);
        AnimatorStateInfo aniState = ani.GetCurrentAnimatorStateInfo(0);
        if(aniState.normalizedTime > 1f)
        {
            isFire = false;
        }
       
        
    }
    private void SkillOne()
    {
        Vector3 ve;
        ve = new Vector3(transform.position.x + boxCollider.size.x+0.2f,
              transform.position.y - 0.2f,
              transform.position.z
              );
        if (transform.localScale.x == -1)
        {
            ve = new Vector3(
                transform.position.x - (boxCollider.size.x+0.2f),
                transform.position.y -0.2f,
                transform.position.z
                );
        }

        Instantiate(fire, ve,transform.rotation, gameObject.transform);
        Instantiate(ray, ve, transform.rotation, gameObject.transform);
        imaOne.fillAmount = 1;

        AnimatorStateInfo aniState = ani.GetCurrentAnimatorStateInfo(0);
        if(aniState.IsName("skillO") && aniState.normalizedTime > 1f)
        {
            isSkillO = false;
        }

    }

    private void SkillTwo()
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
        AnimatorStateInfo aniState = ani.GetCurrentAnimatorStateInfo(0);
        if (aniState.IsName("skillT") && aniState.normalizedTime > 1f)
        {
            isSkillT = false;

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

