using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class FSMBaseState
{
    public FSMStateID myStateID { get; set; }    //状态ID
    public FSMSystem myFSMSystem { get; set; }   //该对象属于在哪个状态机

    public Dictionary<FSMTransition, FSMStateID> myStateIdDic = new Dictionary<FSMTransition, FSMStateID>();

    public FSMBaseState(FSMSystem fsmSystem, FSMStateID stateID)
    {
        this.myFSMSystem = fsmSystem;
        this.myStateID = stateID;
    }

    public void AddTransition(FSMTransition transition, FSMStateID stateID)
    {
        if (myStateIdDic.ContainsKey(transition))
        {
            Debug.Log("本状态已经包含了该转换条件");
            return;
        }
        myStateIdDic.Add(transition, stateID);
    }

    public void DeleteTransition(FSMTransition transition)
    {
        if (!myStateIdDic.ContainsKey(transition))
        {
            Debug.Log("容器中没有该转换条件");
            return;
        }
        myStateIdDic.Remove(transition);
    }

    public FSMStateID GetStateIdByTransition(FSMTransition transition)
    {
        if (!myStateIdDic.ContainsKey(transition))
        {
            Debug.Log(transition);
            Debug.Log("容器内没有该转换条件，无法获取状态");
            return FSMStateID.NullFSMStateID;
        }

        return myStateIdDic.FirstOrDefault(q => q.Key == transition).Value;
    }

    public abstract void StateStart(GameObject myObject);
    public abstract void StateUpdate();
    public abstract void StateEnd();
    //转化状态条件
    public abstract void TransitionReason();
}

