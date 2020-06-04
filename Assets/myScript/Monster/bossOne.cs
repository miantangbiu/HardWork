using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossOne : MonoBehaviour {


  
    private FSMSystem mySystem { get; set; }
    attriBuild atBuild = new bossOneAttri();
    attriControl atControl = new attriControl();
    public attribute bossOneAt;
    // Use this for initialization
    void Start () {

        bossOneAt = atControl.construct(atBuild);

        mySystem = new FSMSystem(this.gameObject);

        FSMBaseState bornState = new bossOneBorn(mySystem);
        FSMBaseState stayState = new bossOneStay(mySystem);
        FSMBaseState attackState = new bossOneAttack(mySystem);
        FSMBaseState skillOne = new bossOneSkillOne(mySystem);
        FSMBaseState skillTwo = new bossOneSkillTwo(mySystem);
        FSMBaseState skillThree = new bossOneSkillThree(mySystem);
        FSMBaseState dieState = new bossOneDie(mySystem);

        bornState.AddTransition(FSMTransition.LeavePlayer, FSMStateID.stayState);
        stayState.AddTransition(FSMTransition.SeePlayer, FSMStateID.attackState);
        stayState.AddTransition(FSMTransition.zeroHp, FSMStateID.death);
        attackState.AddTransition(FSMTransition.LeavePlayer, FSMStateID.stayState);
        attackState.AddTransition(FSMTransition.highHp, FSMStateID.skillOne);
        attackState.AddTransition(FSMTransition.halfHp, FSMStateID.skillTwo);
        attackState.AddTransition(FSMTransition.zeroHp, FSMStateID.death);
        skillOne.AddTransition(FSMTransition.SeePlayer, FSMStateID.attackState);
        skillOne.AddTransition(FSMTransition.zeroHp, FSMStateID.death);
        skillTwo.AddTransition(FSMTransition.SeePlayer, FSMStateID.attackState);
        skillTwo.AddTransition(FSMTransition.lowHp, FSMStateID.skillThree);
        skillTwo.AddTransition(FSMTransition.zeroHp, FSMStateID.death);
        skillThree.AddTransition(FSMTransition.SeePlayer, FSMStateID.attackState);
        skillThree.AddTransition(FSMTransition.zeroHp, FSMStateID.death);

        mySystem.AddFSMState(bornState);
        mySystem.AddFSMState(stayState);
        mySystem.AddFSMState(attackState);
        mySystem.AddFSMState(skillOne);
        mySystem.AddFSMState(skillTwo);
        mySystem.AddFSMState(skillThree);
        mySystem.AddFSMState(dieState);


    }
	
	// Update is called once per frame
	void Update () {

        Debug.Log("1");
        mySystem.UpdateSystem();
    }
}
