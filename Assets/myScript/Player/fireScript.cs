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
    private Animator ani;

    private void Start()
    {
        playerArmature = GetComponent<UnityArmatureComponent>();
        //  playerArmature.animation.Play("walk",-1);
        //ani = GameObject.Find("fire").GetComponent<Animator>();
        ani = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            state = playerArmature.animation.FadeIn("skillOne", -1, 1, 1,"hand",AnimationFadeOutMode.None);
            //playerArmature.animation.FadeIn("jump", -1, 1, 1, "normal", AnimationFadeOutMode.SameLayer);
            state.resetToPose = false;

        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            ani.SetTrigger("walk");
        }
    }

    void test1()
    {
        Debug.Log("test");
        ani.Play("curtainFire");
        
    }
}
