using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numberDie : MonoBehaviour {

    float t;
    float x;
	// Use this for initialization
	void Start () {

        t = 0;
        

    }
	
	// Update is called once per frame
	void Update () {
        RectTransform rect = gameObject.GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(
            rect.anchoredPosition.x,
            rect.anchoredPosition.y+0.8f
            );
        t += Time.deltaTime;
        if (t >= 1.2f)
        {
            Destroy(this.gameObject);
        }
	}
}
