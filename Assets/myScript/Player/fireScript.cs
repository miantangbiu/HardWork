using DragonBones;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fireScript : MonoBehaviour
{
    private UnityArmatureComponent playerArmature;
    private DragonBones.AnimationState state;
    private void Start()
    {
        playerArmature = GetComponent<UnityArmatureComponent>();
        playerArmature.animation.Play("walk",-1);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            state = playerArmature.animation.FadeIn("jump", -1, 1, 1,"hand",AnimationFadeOutMode.None);
            //playerArmature.animation.FadeIn("jump", -1, 1, 1, "normal", AnimationFadeOutMode.SameLayer);
            state.resetToPose = false;

        }

        if(state!= null && state.isCompleted)
        {
            state.layer = 0;
            state = null;
        }
    }
}
