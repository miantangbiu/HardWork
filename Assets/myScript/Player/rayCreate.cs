using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayCreate : MonoBehaviour {

    Animator ani;
    SpriteRenderer mySprite;
    BoxCollider2D box;


    attribute player;
	// Use this for initialization
	void Start () {

        mySprite = gameObject.GetComponent<SpriteRenderer>();
        box = gameObject.GetComponent<BoxCollider2D>();
        ani = gameObject.GetComponent<Animator>();
        player = transform.parent.GetComponent<createAttri>().xia;
        
        if (transform.position.x>transform.parent.position.x)
        {
            transform.position = new Vector3(
            transform.position.x + mySprite.size.x / 2,
            transform.position.y,
            transform.position.z
            );
        }
        else
        {
            transform.position = new Vector3(
           transform.position.x - mySprite.size.x / 2,
           transform.position.y,
           transform.position.z
           );
        }
        
    }
	
	// Update is called once per frame
	void Update () {

       
     
        box.size = new Vector2(mySprite.size.x,box.size.y);
    
        if (ani.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.99)
        {
            Destroy(this.gameObject);
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Enemy" || collision.tag != "Gun")
            return;
        hurtCount.hurt(2 * player.Atk, collision.gameObject);
        if (collision.gameObject.tag == "Gun")
        {
            Destroy(collision.gameObject);
        }
    }
}
