using DragonBones;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossOneBorn : FSMBaseState
{
    public bossOneBorn(FSMSystem fsmSystem) : base(fsmSystem,FSMStateID.born){ }

    UnityArmatureComponent ani;
    DragonBones.AnimationState aniState;

    GameObject monsterObj;


    public override void StateStart(GameObject myObject)
    {
        monsterObj = myObject;
        ani = monsterObj.GetComponent<UnityArmatureComponent>();
        aniState = ani.animation.Play("born",1);
      
    }

    public override void StateUpdate()
    {
       
    }

    public override void StateEnd()
    {
        
    }

    public override void TransitionReason()
    {
        if(aniState != null && aniState.isCompleted)
        {
            myFSMSystem.TransitionFSMState(FSMTransition.LeavePlayer);
        }
    }
}


public class bossOneStay : FSMBaseState
{

    GameObject monsterObj;

    UnityArmatureComponent ani;
    DragonBones.AnimationState aniState;


    float mytime;


    public bossOneStay(FSMSystem fsmSystem) : base(fsmSystem, FSMStateID.stayState){ }

  

    public override void StateStart(GameObject myObject)
    {
        monsterObj = myObject;
        ani = monsterObj.GetComponent<UnityArmatureComponent>();
        ani.animation.Play("stay");
        
        mytime = 0;
     }

    public override void StateUpdate()
    {
        mytime += Time.deltaTime;

    
    }
  public override void StateEnd()
    {
        monsterObj.GetComponent<BoxCollider2D>().enabled = true;
    }
    public override void TransitionReason()
    {
        if (monsterObj.GetComponent<bossOne>().bossOneAt.Hp == 0)
        {
            myFSMSystem.TransitionFSMState(FSMTransition.zeroHp);
        }
        if (mytime > 4f)
        {
            myFSMSystem.TransitionFSMState(FSMTransition.SeePlayer);
        }
        
    }
}


public class bossOneAttack : FSMBaseState
{
    //弹幕
    GameObject barrage;
    GameObject[] barrages;
    string name;

    Animator ani;
    GameObject monsterObj;

    attribute myAtt;
    int myhp;

    int index;
    int a;
    
    public bossOneAttack(FSMSystem fsmSystem) : base(fsmSystem, FSMStateID.attackState) { }

    public override void StateStart(GameObject gameObject)
    {
   
        monsterObj = gameObject;
        myAtt = monsterObj.GetComponent<bossOne>().bossOneAt;
        myhp = myAtt.Hp;

        ani = gameObject.GetComponent<Animator>();

        switch (monsterObj.name)
        {
            case "spider":
                name = "";
                break;
            case "notebook":
                name = "";
                break;
            case "dinosaur":
                name = "fireBall";
                break;
        }
        barrage = (GameObject)Resources.Load(name);

        ani.Play("attack");

        index = 0;
        a = 0;
    }

    public override void StateUpdate()
    {
        if(monsterObj.name == "dinosaur")
        {

            barrages = GameObject.FindGameObjectsWithTag("Gun");
            Vector3[] point =
            {
            monsterObj.transform.position + new Vector3(0,3,0),
            monsterObj.transform.position + new Vector3(-2,3,0),
            monsterObj.transform.position +new Vector3(-3,3,0),
            monsterObj.transform.position +new Vector3(-2,0,0),
            monsterObj.transform.position +new Vector3(-2,-2,0),
        };
            if (barrages.Length < 5)
            {
                GameObject gun = MonoBehaviour.Instantiate(barrage, point[index], Quaternion.identity, monsterObj.transform);

                index++;
                Debug.Log("1");
                if (index == 4)
                {
                    index = 0;
                    a++;
                }

                MonoBehaviour.Destroy(gun, 10);
            }
        }
        else if(monsterObj.name == "spider")
        {
            
        }
       
    }

    public override void StateEnd()
    {
        
    }

    public override void TransitionReason()
    {
        if (a > 3)
        {
            myFSMSystem.TransitionFSMState(FSMTransition.LeavePlayer);
        }
        if ((float)myAtt.Hp / myAtt.MaxHp > 0.5f && (float)(myhp - myAtt.Hp) / myAtt.MaxHp > 0.05f)
        {
            myFSMSystem.TransitionFSMState(FSMTransition.highHp);
        }
        if ((float)myAtt.Hp / myAtt.MaxHp < 0.5f && (float)(myhp - myAtt.Hp) / myAtt.MaxHp > 0.05f)
        {
            myFSMSystem.TransitionFSMState(FSMTransition.halfHp);
        }
        if(myAtt.Hp == 0)
        {
            myFSMSystem.TransitionFSMState(FSMTransition.zeroHp);
        }
    }
}


public class bossOneSkillOne : FSMBaseState
{
    Animator ani;
    GameObject monsterObj;

    public bossOneSkillOne(FSMSystem fsmSystem) : base(fsmSystem, FSMStateID.skillOne){ }

    public override void StateStart(GameObject gameObject)
    {
        monsterObj = gameObject;
        ani = monsterObj.GetComponent<Animator>();
        ani.Play("skillOne");
    }

    public override void StateUpdate()
    {
       
    }

    public override void StateEnd()
    {
        
    }

    public override void TransitionReason()
    {
        if(ani.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.99f)
        {
            myFSMSystem.TransitionFSMState(FSMTransition.SeePlayer);
        }
        if (monsterObj.GetComponent<bossOne>().bossOneAt.Hp == 0)
        {
            myFSMSystem.TransitionFSMState(FSMTransition.zeroHp);
        }
    }
}


public class bossOneSkillTwo : FSMBaseState
{
    Animator ani;
    GameObject monsterObj;
    attribute myAtt;

    public bossOneSkillTwo(FSMSystem fsmSystem) : base(fsmSystem, FSMStateID.skillTwo) { }
    
    public override void StateStart(GameObject gameObject)
    {
        monsterObj = gameObject;
        ani = monsterObj.GetComponent<Animator>();
        ani.Play("skillTwo");
        myAtt = monsterObj.GetComponent<bossOne>().bossOneAt;
    }

    public override void StateUpdate()
    {
      
    }

    public override void StateEnd()
    {

    }

    public override void TransitionReason()
    {
        if(ani.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.99f)
        {
            if((float)myAtt.Hp / myAtt.MaxHp > 0.2f)
            {
                myFSMSystem.TransitionFSMState(FSMTransition.SeePlayer);
            }
            else
            {
                myFSMSystem.TransitionFSMState(FSMTransition.lowHp);
            }
        }
        if (myAtt.Hp == 0)
        {
            myFSMSystem.TransitionFSMState(FSMTransition.zeroHp);
        }
    }
}



public class bossOneSkillThree : FSMBaseState
{
    Animator ani;
    GameObject monsterObj;
    attribute myAtt;
    public bossOneSkillThree(FSMSystem fsmSystem) : base(fsmSystem, FSMStateID.skillThree) { }

   

    public override void StateStart(GameObject gameObject)
    {
        monsterObj = gameObject;
        ani = monsterObj.GetComponent<Animator>();
        ani.Play("skillThree");
        myAtt = monsterObj.GetComponent<bossOne>().bossOneAt;
    }

    public override void StateUpdate()
    {

    }
    public override void StateEnd()
    {
     
    }
    public override void TransitionReason()
    {
        if (ani.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.99f)
        {
            myFSMSystem.TransitionFSMState(FSMTransition.SeePlayer);
        }
        if (monsterObj.GetComponent<bossOne>().bossOneAt.Hp == 0)
        {
            myFSMSystem.TransitionFSMState(FSMTransition.zeroHp);
        }
    }
}

public class bossOneDie : FSMBaseState
{
    Animator ani;
    GameObject monsterObj;

    public bossOneDie(FSMSystem fsmSystem) : base(fsmSystem,FSMStateID.death){ }



    public override void StateStart(GameObject myObject)
    {
        monsterObj = myObject;
        ani = monsterObj.GetComponent<Animator>();
        ani.Play("die");
    }

    public override void StateUpdate()
    {
        if (ani.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.99f)
        {
            MonoBehaviour.Destroy(monsterObj);
        }
    }

    public override void StateEnd()
    {

    }
    public override void TransitionReason()
    {
      
    }
}