using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour {
    public Transform target;
    float moveSpeed = 0.04f;
    float minx, miny, maxx, maxy;
    // 计算移动
    private Vector3 myposition, targetPosition;
    Vector2 backPic,backSize,mySize;
  
    float x, y;
    //public GameObject myUI;
    // Use this for initialization
    void Start () {
        // Instantiate(myUI);
        target = GameObject.Find("player").transform;
        backPic = GameObject.Find("wallpaper").transform.position;
        backSize = GameObject.Find("wallpaper").GetComponent<SpriteRenderer>().size;

        mySize = gameObject.GetComponent<BoxCollider>().size;
        minx = backPic.x - backSize.x / 2 + mySize.x / 2;
        miny = backPic.y - backSize.y / 2 + mySize.y / 2;
        maxx = backPic.x + backSize.x / 2 - mySize.x / 2;
        maxy = backPic.y + backSize.y / 2 - mySize.y / 2;

    }

    // Update is called once per frame
    void Update() {


        targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, -10);
        

    }
    private void FixedUpdate()
    {
        myposition = Vector3.Lerp(myposition, targetPosition, moveSpeed);

        // 设置摄像头位置

        transform.position = new Vector3(Mathf.Clamp(myposition.x, minx, maxx),
                                         Mathf.Clamp(myposition.y, miny ,maxy),
                                         myposition.z
                                         );
    }
}

