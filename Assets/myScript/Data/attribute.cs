
using System.Collections.Generic;
using UnityEngine;
//建造者模式
public class attribute   //复合产品
{
    public string Name { get; set; }
    public int Hp { get; set; }
    public int MaxHp { get; set; }
    public int Atk { get; set; }
    public float AtkRange { get; set; }
    public float AtkSpd { get; set; }
    public float MoveSpd { get; set; }
    public float JumpSpd { get; set; }
  
}

abstract class attriBuild //抽象创建者
{
    protected attribute attri = new attribute();
    public abstract void buildName();
    public abstract void buildHP();
    public abstract void buildMaxHp();
    public abstract void buildAtk();
    public abstract void buildAtkRange();
    public abstract void buildAtkSpd();
    public abstract void buildMoveSpd();
    public abstract void buildJumpSpd();
    public attribute createAttri()
    {
        return attri;
    }
   }

class attriControl//指挥者
{
    public attribute construct(attriBuild at)
    {
        attribute attri;
        at.buildName();
        at.buildHP();
        at.buildAtk();
        at.buildAtkRange();
        at.buildAtkSpd();
        at.buildMoveSpd();
        at.buildJumpSpd();
        at.buildMaxHp();
        attri = at.createAttri();
        return attri;
    }
}
