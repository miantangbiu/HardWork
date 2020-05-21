using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openGear : MonoBehaviour {
    private Animator ani;

    private BoxCollider2D box;

	// Use this for initialization

	void Start () {
        ani = this.GetComponent<Animator>();
        //关闭状态
        ani.Play("close");
        box = gameObject.GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (ani.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.99f && ani.GetCurrentAnimatorStateInfo(0).IsName("move"))
        {
           //开启状态动画
            ani.Play("open");
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        box.enabled = false;
        if(collision.gameObject.tag == "Player")
        {
            //播放开启动画
            ani.Play("openMove");
        }
        
    }
}
