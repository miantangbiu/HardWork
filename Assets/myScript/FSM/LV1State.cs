using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV1BornState : FSMBaseState
{
    Animator ani;
    GameObject monsetObj;
    public LV1BornState(FSMSystem fsmSystem) : base(fsmSystem, FSMStateID.born){ }

    public override void StateStart(GameObject myObject)
    {
        monsetObj = myObject;
        ani = monsetObj.GetComponent<Animator>();
        ani.Play("born");
    }

    public override void StateUpdate()
    {
        monsetObj.GetComponent<BoxCollider2D>().enabled = false;
    }

    public override void StateEnd()
    {
        monsetObj.GetComponent<BoxCollider2D>().enabled = true;
    }
    public override void TransitionReason()
    {
        if(ani.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.99f)
        {
            myFSMSystem.TransitionFSMState(FSMTransition.LeavePlayer);
        }
    }
}

public class LV1StayState : FSMBaseState
{
    Animator ani;
    Vector3 myposi;

    GameObject monsterObj;
    attribute att;

    GameObject playerObj;

    public LV1StayState(FSMSystem fsmSystem) : base(fsmSystem, FSMStateID.stayState) { }

    public override void StateStart(GameObject myObject)
    {

        monsterObj = myObject;
        playerObj = GameObject.Find("xia");

        ani = monsterObj.GetComponent<Animator>();
        myposi = monsterObj.transform.position;

        att = monsterObj.GetComponent<LV1>().LV1Att;
        ani.Play("stay");

        //att.Hp = 5;
    }

    public override void StateUpdate()
    {
        if (monsterObj.name == "fly")
        {
          
            monsterObj.transform.position = new Vector3(
            monsterObj.transform.position.x,
            myposi.y + Mathf.PingPong(Time.time, 1),
            monsterObj.transform.position.z
            );
        }
        if (monsterObj.name == "mite")
        {
            monsterObj.transform.position = new Vector3(
            myposi.x + Mathf.PingPong(Time.time, 0.5f),
            monsterObj.transform.position.y,
            monsterObj.transform.position.z
          );
        }
    }

    public override void StateEnd()
    {

    }

    public override void TransitionReason()
    {
       

        if (Vector2.Distance(monsterObj.transform.position, playerObj.transform.position) <= att.AtkRange)
        {
            myFSMSystem.TransitionFSMState(FSMTransition.SeePlayer);
        }
        if(att.Hp <= 0)
        {
            Debug.Log("1");
            myFSMSystem.TransitionFSMState(FSMTransition.zeroHp);
        }
    }
}

public class LV1AttackState : FSMBaseState
{
    Animator ani;

    
    GameObject monsterObj;
    
    GameObject playerObj;
    attribute att;
    Collider2D colli;

    public LV1AttackState(FSMSystem fsmSystem) : base(fsmSystem,FSMStateID.attackState){ }

   
    public override void StateStart(GameObject myObject)
    {

        monsterObj = myObject;
        playerObj = GameObject.Find("xia");
        att = monsterObj.GetComponent<LV1>().LV1Att;
        ani = monsterObj.GetComponent<Animator>();
        colli = playerObj.GetComponent<BoxCollider2D>();

        //ani.Play("attck");
       

    }

    public override void StateUpdate()
    {
        if (monsterObj.gameObject.name == "fly")
        {
            monsterObj.transform.position = new Vector3(
            Mathf.MoveTowards(monsterObj.transform.position.x, playerObj.transform.position.x,0.02f),
            Mathf.MoveTowards(monsterObj.transform.position.y, playerObj.transform.position.y,0.02f),
            monsterObj.transform.position.z
            );
        }
        if (monsterObj.gameObject.name == "mite")
        {
            monsterObj.transform.position = new Vector3(
            Mathf.MoveTowards(monsterObj.transform.position.x, playerObj.transform.position.x, 0.02f),
            monsterObj.transform.position.y,
            monsterObj.transform.position.z
            );
        }



    }
 public override void StateEnd()
    {
       
    }

    public override void TransitionReason()
    {
     
        if (Vector2.Distance(monsterObj.transform.position, playerObj.transform.position) >= att.AtkRange*2)
        {
            myFSMSystem.TransitionFSMState(FSMTransition.LeavePlayer);
        }
        if (att.Hp <= 0)
        {
            myFSMSystem.TransitionFSMState(FSMTransition.zeroHp);
        }
    }
   
}

public class LV1DieState : FSMBaseState
{
    public LV1DieState(FSMSystem fsmSystem) : base(fsmSystem, FSMStateID.death){ }

    Animator ani;
    GameObject monsetObj;


    public override void StateStart(GameObject myObject)
    {
        monsetObj = myObject;
        ani = monsetObj.GetComponent<Animator>();
        ani.Play("die");
    }

    public override void StateUpdate()
    {
        if (ani.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.99f)
        {
            MonoBehaviour.Destroy(monsetObj);
        }

    }

    public override void StateEnd()
    {
        
    }

    public override void TransitionReason()
    {

       
    }
}