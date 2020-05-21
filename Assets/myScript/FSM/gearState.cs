using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//开启状态
public class gearOpenState : FSMBaseState
{
    public gearOpenState(FSMSystem fsmSystem) : base(fsmSystem, FSMStateID.born)
    {

    }
    
    public override void StateStart(GameObject myObject)
    {
       
    }

    public override void StateUpdate()
    {
        
    }

    public override void StateEnd()
    {
        
    }

    public override void TransitionReason()
    {
        
    }
}
//关闭状态
public class gearCloseState : FSMBaseState
{
    public gearCloseState(FSMSystem fsmSystem) : base(fsmSystem, FSMStateID.death)
    {
    }

    public override void StateStart(GameObject myObject)
    {
       
    }

    public override void StateUpdate()
    {
        
    }

    public override void StateEnd()
    {

    }

    public override void TransitionReason()
    {
       
    }
}
//开启中
public class gearOnState : FSMBaseState
{
    public gearOnState(FSMSystem fsmSystem) : base(fsmSystem, FSMStateID.attackState)
    {
    }

    public override void StateStart(GameObject myObject)
    {
        
    }

    public override void StateUpdate()
    {
       
    }

    public override void StateEnd()
    {
       
    }

    public override void TransitionReason()
    {
        
    }
}
//关闭中
public class gearOfState : FSMBaseState
{
    public gearOfState(FSMSystem fsmSystem) : base(fsmSystem, FSMStateID.stayState)
    {
    }

    public override void StateStart(GameObject myObject)
    {
        
    }

    public override void StateUpdate()
    {
        
    }

    public override void StateEnd()
    {
      
    }

    public override void TransitionReason()
    {
        
    }
}