using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class pointData : MonoBehaviour {
    GameObject dialog;
    Text text;
	// Use this for initialization
	void Start () {
     

	}
	
	// Update is called once per frame
	void Update () {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dialog = GameObject.Find("tipBack");
            text = dialog.GetComponentInChildren<Text>();
            if (this.gameObject.name == "point1")
            {

            }
            else if (this.gameObject.name == "point0")
            {
                attribute playAttri = collision.gameObject.GetComponent<createAttri>().xia;
                saveData.saveGame(new myData(playAttri, SceneManager.GetActiveScene().buildIndex + 1,"point1",0f,SceneManager.GetActiveScene().buildIndex+1), myData.user);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                Vector2 ve = new Vector2(transform.position.x, transform.position.y + 1.1f);
                dialog.GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(ve);
                text.text = "按E保存";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    attribute playAttri = collision.gameObject.GetComponent<createAttri>().xia;
                    float t = GameObject.Find("timeText").GetComponent<timeCount>().t;
                    myData mydata = new myData(playAttri, SceneManager.GetActiveScene().buildIndex+1, this.gameObject.name, t, SceneManager.GetActiveScene().buildIndex+1);
                    saveData.saveGame(mydata,myData.user);
                    
                }
            }
        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dialog = GameObject.Find("tipBack");
            dialog.GetComponent<RectTransform>().position = new Vector2(0, -220);

        }
    }
   
}
