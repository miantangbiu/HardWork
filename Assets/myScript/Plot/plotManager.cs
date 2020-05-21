using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class plotManager : MonoBehaviour
{
    

    /// <summary>
    /// 命令列表
    /// </summary>
    private List<plotCommand> commandList;

    /// <summary>
    /// 当前命令索引
    /// </summary>
    private int index = 0;

    /// <summary>
    /// 当前命令类型
    /// </summary>
    public enum CommandType
    {
           Manually//手动执行命令
    }

    /// <summary>
    /// 当前命令类型,默认为自动
    /// </summary>
    private CommandType commandType = CommandType.Manually;

    /// <summary>
    /// 命令管理器实例
    /// </summary>
    private static plotManager instance;
    public static plotManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<plotManager>();
            return instance;
        }
    }

    void Awake()
    {
        //初始化命令列表
        commandList = new List<plotCommand>();
        //初始化当前实例
        instance = this;
    }


    void Update()
    {
        ExcuteNextManually();
    }

    /// <summary>
    /// 向命令列表中添加命令
    /// </summary>
    /// <param name="command"></param>
    public void AddCommand(plotCommand command)
    {
        if (commandList == null || command == null)
            return;
        commandList.Add(command);
    }

    /// <summary>
    /// 设置命令的类型
    /// </summary>
    /// <param name="type"></param>
    public void SetCommandType(CommandType type)
    {
        this.commandType = type;
    }

    /// <summary>
    /// 使索引递增的一个方法
    /// </summary>
    public void MoveNext()
    {
        //判断列表是否为空
        if (commandList == null || commandList.Count <= 0)
            return;

        index += 1;
        if (index >= commandList.Count)
        {
            index = 0;
            commandList.Clear();
        }
    }

    /// <summary>
    /// 自动执行下一句命令
    /// </summary>
/*
    private void ExcuteNextAutomatic()
    {
        //判断列表是否合法
        if (commandList == null || commandList.Count <= 0)
        {
            return;

        }
            
        //判断索引是否合法
        if (index < 0 || index >= commandList.Count)
        {
            return;
        }
              

        //执行每一条命令
        if (index < commandList.Count)
        {
            
            commandList[index].Execute();
            this.MoveNext();
        }
    }
*/
    /// <summary>
    /// 手动执行下一句命令
    /// </summary>
    private void ExcuteNextManually()
    {
        //判断列表是否合法
        if (commandList == null || commandList.Count <= 0)
        {
            return;
        }

        //判断索引是否合法
        if (index < 0 || index >= commandList.Count)
        {
            return;
        }

        //执行每一条命令
        if (index < commandList.Count)
        {
            //获得第一条对话的索引
            int firstDialogIndex = GetFirstDialogIndex();
            if(index <= firstDialogIndex)
            {
                commandList[index].Execute();
                this.MoveNext();
            }
            //否则需要手动触发对话的显示
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                commandList[index].Execute();
                this.MoveNext();
             }
           
        }
    }

    private int GetFirstDialogIndex()
    {
        int result = -1;

        //遍历列表以获得第一个对话的索引
        for (int i = 0; i < commandList.Count; i++)
        {
            if (commandList[i].GetType() == typeof(plotDialog))
            {
                result = i;
                break;
            }
        }

        return result;
    }
}
