using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossTwoBorn : FSMBaseState
{
    public bossTwoBorn(FSMSystem fsmSystem) : base(fsmSystem, FSMStateID.born){}
    Animator ani;
    GameObject monsterObj;



    public override void StateStart(GameObject myObject)
    {
        monsterObj = myObject;
        ani = monsterObj.GetComponent<Animator>();
        ani.Play("born");
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
            myFSMSystem.TransitionFSMState(FSMTransition.LeavePlayer);
        }
    }
}

public class bossTwoStay : FSMBaseState
{
    public bossTwoStay(FSMSystem fsmSystem) : base(fsmSystem, FSMStateID.stayState)
    { }


    GameObject monsterObj;

    private Animator ani;

    float mytime;

    public override void StateStart(GameObject myObject)
    {
        monsterObj = myObject;
        ani = myObject.GetComponent<Animator>();
        ani.Play("stay");
        mytime = 0;
    }

    public override void StateUpdate()
    {
        mytime += Time.deltaTime;


    }
    public override void StateEnd()
    {

    }
    public override void TransitionReason()
    {
        if (monsterObj.GetComponent<bossTwo>().bossTwoAt.Hp == 0)
        {
            myFSMSystem.TransitionFSMState(FSMTransition.zeroHp);
        }
        if (mytime > 2f)
        {
            myFSMSystem.TransitionFSMState(FSMTransition.SeePlayer);
        }

    }
}

public class bossTwoAttack : FSMBaseState
{
    public bossTwoAttack(FSMSystem fsmSystem) : base(fsmSystem, FSMStateID.attackState)
    {  }

    GameObject monsterObj;
    GameObject fire;

    private Animator ani;

    float mytime;


    public override void StateStart(GameObject myObject)
    {
        monsterObj = myObject;
        fire = (GameObject)Resources.Load("fireBall");

        ani = monsterObj.GetComponent<Animator>();
        ani.Play("attack");
    }

    public override void StateUpdate()
    {
        GameObject g = MonoBehaviour.Instantiate(fire);
        g.name = "arrow";
        mytime += Time.deltaTime;
    }

    public override void StateEnd()
    {

    }

    public override void TransitionReason()
    {
        if (mytime > 10)
        {
            switch((int)Mathf.Floor(UnityEngine.Random.Range(0, 4)))
            {
                case 0:
                    myFSMSystem.TransitionFSMState(FSMTransition.LeavePlayer);
                    break;
                case 1:
                    myFSMSystem.TransitionFSMState(FSMTransition.highHp);
                    break;
                case 2:
                    myFSMSystem.TransitionFSMState(FSMTransition.halfHp);
                    break;
                case 3:
                    myFSMSystem.TransitionFSMState(FSMTransition.lowHp);
                    break;
            }
        }
        if (monsterObj.GetComponent<bossTwo>().bossTwoAt.Hp == 0)
        {
            myFSMSystem.TransitionFSMState(FSMTransition.zeroHp);
        }
    }
}

public class bossTwoSkillOne : FSMBaseState
{
    public bossTwoSkillOne(FSMSystem fsmSystem) : base(fsmSystem, FSMStateID.skillOne)
    {
    }
    GameObject monsterObj;
    Animator ani;

    public override void StateStart(GameObject myObject)
    {
        monsterObj = myObject;
        
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
        if (monsterObj.GetComponent<bossTwo>().bossTwoAt.Hp == 0)
        {
            myFSMSystem.TransitionFSMState(FSMTransition.zeroHp);
        }
        else if (ani.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.99f)
        {
            myFSMSystem.TransitionFSMState(FSMTransition.SeePlayer);
        }
    }
}

public class bossTwoSkillTwo : FSMBaseState
{
    public bossTwoSkillTwo(FSMSystem fsmSystem) : base(fsmSystem, FSMStateID.skillTwo)
    {
    }

    GameObject monsterObj;
    Animator ani;

    public override void StateStart(GameObject myObject)
    {
        monsterObj = myObject;

        ani = monsterObj.GetComponent<Animator>();
        ani.Play("skillTwo");
    }

    public override void StateUpdate()
    {

    }

    public override void StateEnd()
    {

    }

    public override void TransitionReason()
    {
        if (monsterObj.GetComponent<bossTwo>().bossTwoAt.Hp == 0)
        {
            myFSMSystem.TransitionFSMState(FSMTransition.zeroHp);
        }
        else if (ani.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.99f)
        {
            myFSMSystem.TransitionFSMState(FSMTransition.SeePlayer);
        }
    }
}

public class bossTwoSkillThree : FSMBaseState
{
    public bossTwoSkillThree(FSMSystem fsmSystem) : base(fsmSystem, FSMStateID.skillThree)
    {
    }

    GameObject monsterObj;
    Animator ani;

    public override void StateStart(GameObject myObject)
    {
        monsterObj = myObject;

        ani = monsterObj.GetComponent<Animator>();
        ani.Play("skillThree");
    }

    public override void StateUpdate()
    {

    }

    public override void StateEnd()
    {

    }

    public override void TransitionReason()
    {
        if (monsterObj.GetComponent<bossTwo>().bossTwoAt.Hp == 0)
        {
            myFSMSystem.TransitionFSMState(FSMTransition.zeroHp);
        }
        else if (ani.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.99f)
        {
            myFSMSystem.TransitionFSMState(FSMTransition.SeePlayer);
        }
    }
}

public class bossTwoDie : FSMBaseState
{
    Animator ani;
    GameObject monsterObj;
    public bossTwoDie(FSMSystem fsmSystem, FSMStateID stateID) : base(fsmSystem, stateID)
    {
    }



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

