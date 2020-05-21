using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


/// <summary>
/// 状态ID
/// </summary>
public enum FSMStateID
{
    born,
    NullFSMStateID = 0,
    stayState,//等待状态
    attackState,//追逐状态
    skillOne,//技能
    skillTwo,
    skillThree,
    death,
}

/// <summary>
/// 状态转化条件
/// </summary>
public enum FSMTransition
{
    SeePlayer,//看到主角（目标）
    LeavePlayer,//远离敌人（目标）
    highHp,
    halfHp,
    lowHp,
    zeroHp,
}

public class FSMSystem
{
    private FSMStateID myStateID;
    private FSMBaseState myState;

    private Dictionary<FSMStateID, FSMBaseState> myStateDic = new Dictionary<FSMStateID, FSMBaseState>();
    private GameObject gameObject;

    public FSMSystem(GameObject gameObject)
    {
        this.gameObject = gameObject;
    }

    public void AddFSMState(FSMBaseState state)
    {
        if (state == null)
        {
            Debug.Log("角色状态为空，无法添加");
            return;
        }
        if (myState == null)
        {
            //第一个添加的状态被作为系统首个运行的状态
            myStateID = state.myStateID;
            myState = state;
            myState.StateStart(gameObject);
        }
        if (myStateDic.ContainsValue(state))
        {
            Debug.Log("容器内存在该状态");
            return;
        }
        myStateDic.Add(state.myStateID, state);
    }

    public void DeleteFSMState(FSMBaseState state)
    {
        if (state == null)
        {
            Debug.Log("角色状态为空，无法添加");
            return;
        }
        if (!myStateDic.ContainsValue(state))
        {
            Debug.Log("容器内不存在该状态");
            return;
        }
        myStateDic.Remove(state.myStateID);
    }

    //更新（执行）系统
    public void UpdateSystem()
    {
        if (myState != null)
        {
            myState.StateUpdate();
            myState.TransitionReason();
        }
    }

    //转换状态
    public void TransitionFSMState(FSMTransition transition)
    {
        FSMStateID stateID = myState.GetStateIdByTransition(transition);
        if (stateID != FSMStateID.NullFSMStateID)
        {
            myStateID = stateID;
            myState.StateEnd();
            //换状态
            myState = myStateDic.FirstOrDefault(q => q.Key == stateID).Value;
            myState.StateStart(gameObject);
        }
    }
}
