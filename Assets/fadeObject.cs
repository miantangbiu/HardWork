using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeObject : MonoBehaviour
{
    GameObject quilt;
    GameObject suit;
    GameObject pants;

    // Start is called before the first frame update
    void Start()
    {
        quilt = GameObject.Find("quilt");
        suit = GameObject.Find("suit");
        pants = GameObject.Find("pants");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if(collision.gameObject.tag == "Player") {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            switch (gameObject.name)
            {
                case "suitout":
                    quilt.SetActive(false);
                    pants.SetActive(false);
                    break;
                case "pantsout":
                    quilt.SetActive(false);
                    suit.SetActive(false);
                    break;
                case "quiltout":
                    suit.SetActive(false);
                    pants.SetActive(false);
                    break;
            }
        
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"){
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
       
            switch (gameObject.name)
            {
                case "suitout":
                    quilt.SetActive(true);
                    pants.SetActive(true);
                    break;
                case "pantsout":
                    quilt.SetActive(true);
                    suit.SetActive(true);
                    break;
                case "quiltout":
                    suit.SetActive(true);
                    pants.SetActive(true);
                    break;
            }
        }
    }
}
