using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowHurt : MonoBehaviour
{
    GameObject player;
    float x,t;
    Rigidbody2D rig;
    Transform tran;
    private void Start()
    {
        player = GameObject.Find("xia");
        rig = gameObject.GetComponent<Rigidbody2D>();
        x = transform.position.x;        
    }

    private void Update()
    {
        t += Time.deltaTime;
        if (t > 5)
        {
            Destroy(this.gameObject);
        }
       

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            hurtCount.hurt(-1, player);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Earth" || collision.gameObject.tag == "Gun")
        {
            Destroy(this.gameObject);
        }

    }
}