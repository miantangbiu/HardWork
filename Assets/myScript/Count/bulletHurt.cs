using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHurt : MonoBehaviour {

    attribute player;
    float x;
    private void Start()
    {
        player = GameObject.Find("player").GetComponent<createAttri>().xia;
        x = transform.position.x;
    }

    private void Update()
    {
        if (Mathf.Abs(transform.position.x - x) > player.AtkRange)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            hurtCount.hurt(player.Atk, collision.gameObject);
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.tag == "Earth" || collision.gameObject.tag == "Gun")
        {
            Destroy(this.gameObject);
        }
       
    }
}
