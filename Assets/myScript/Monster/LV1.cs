using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV1 : MonoBehaviour{

    private FSMSystem fsmSystem { get; set; }
    attriBuild atBuild = new LV1Attri();
    attriControl atControl = new attriControl();
    public attribute LV1Att;
   
    void Start()
    {
        LV1Att = atControl.construct(atBuild);

        fsmSystem = new FSMSystem(this.gameObject);

        FSMBaseState bornState = new LV1BornState(fsmSystem);
        bornState.AddTransition(FSMTransition.LeavePlayer, FSMStateID.stayState);

        //巡逻状态，在构造参数传一个系统参数，确定该状态是在哪个状态系统中管理的，状态转换的时候调用
        FSMBaseState stayState = new LV1StayState(fsmSystem);
        stayState.AddTransition(FSMTransition.SeePlayer, FSMStateID.attackState);
        stayState.AddTransition(FSMTransition.zeroHp, FSMStateID.death);

        //追逐状态
        FSMBaseState attackState = new LV1AttackState(fsmSystem);
        attackState.AddTransition(FSMTransition.LeavePlayer, FSMStateID.stayState);
        attackState.AddTransition(FSMTransition.zeroHp, FSMStateID.death);

        FSMBaseState dieState = new LV1DieState(fsmSystem);

        fsmSystem.AddFSMState(bornState);
        fsmSystem.AddFSMState(stayState);
        fsmSystem.AddFSMState(attackState);
        fsmSystem.AddFSMState(dieState);

    }

    void Update()
    {
        fsmSystem.UpdateSystem();
       
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.gameObject.tag == "Player")
        {
            hurtCount.hurt(LV1Att.Atk,collision.gameObject);
            Destroy(gameObject);
            
        }

     }

}
