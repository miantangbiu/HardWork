﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireCreate : MonoBehaviour {
    Animator ani;
	// Use this for initialization
	void Start () {
        ani = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (ani.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.99)
        {
            Destroy(this.gameObject);
        }
	}
}
