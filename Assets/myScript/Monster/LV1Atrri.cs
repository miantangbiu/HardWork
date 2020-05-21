using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class LV1Attri : attriBuild{
  
    public override void buildAtk()
    {
        attri.Atk = 1;
    }

    public override void buildAtkRange()
    {
        attri.AtkRange = 3f;
    }

    public override void buildAtkSpd()
    {
        attri.AtkSpd = 5;
    }

    public override void buildHP()
    {
        attri.Hp = 1;
    }

    public override void buildJumpSpd()
    {
        attri.JumpSpd = 10f;
    }

    public override void buildMoveSpd()
    {
        attri.MoveSpd = 10f;
    }

    public override void buildMaxHp()
    {
        attri.MaxHp = 1;
    }

    public override void buildName()
    {
        attri.Name = "NPC";
    }

}
