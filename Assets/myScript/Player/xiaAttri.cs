using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class xiaAttri : attriBuild
{

   
    public override void buildAtk()
    {
        attri.Atk = 1;
    }

    public override void buildAtkRange()
    {
        attri.AtkRange = 8f;
    }

    public override void buildAtkSpd()
    {
        attri.AtkSpd = 3;
    }

    public override void buildHP()
    {
        attri.Hp = 10;
    }

    public override void buildJumpSpd()
    {
        attri.JumpSpd = 7f;
    }

    public override void buildMoveSpd()
    {
        attri.MoveSpd = 4f;
    }

    public override void buildMaxHp()
    {
        attri.MaxHp = 10;
    }

    public override void buildName()
    {
        attri.Name = "王三";
    }
}
