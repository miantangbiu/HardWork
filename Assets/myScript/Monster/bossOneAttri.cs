using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class bossOneAttri : attriBuild
{
    public override void buildAtk()
    {
        attri.Atk = 3;
    }

    public override void buildAtkRange()
    {
        attri.AtkRange = 10f;
    }

    public override void buildAtkSpd()
    {
        attri.AtkSpd = 10f;
    }

    public override void buildHP()
    {
        attri.Hp = 100;
    }

    public override void buildJumpSpd()
    {
        attri.JumpSpd = 0f;
    }

    public override void buildMoveSpd()
    {
        attri.MoveSpd = 0f;
    }

    public override void buildMaxHp()
    {
        attri.MaxHp = 100;
    }

    public override void buildName()
    {
        attri.Name = "恐龙";
    }
}
