using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunCount : MonoBehaviour
{
    private Rigidbody2D rig;
    private GameObject player;
    private Vector2 ve;

    private void Start()
    {
        rig = this.GetComponent<Rigidbody2D>();
        player = GameObject.Find("xia");
        ve = player.transform.position;     
    }
    private void Update()
    {
        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, player.transform.position.x, 0.01f),
           Mathf.Lerp(transform.position.y, ve.y, 0.05f),
            transform.position.z
            );
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Earth"|| collision.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.tag =="Player")
        {
            hurtCount.hurt(2,collision.gameObject);
            
        }
    }
}