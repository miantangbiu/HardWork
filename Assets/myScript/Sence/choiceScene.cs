using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class choiceScene : MonoBehaviour {

    // Use this for initialization
    private void Awake()
    {
        lockScene();
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void clickScene(int index)
    {
        switch (index)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
        }
    } 
    public void lockScene()
    {
        int maxScene = loadData.getMaxScene(myData.user);
        
        switch (maxScene)
        {
            case 1:
                GameObject.Find("Second").GetComponent<Button>().interactable = false;
                GameObject.Find("Third").GetComponent<Button>().interactable = false;
                break;
            case 2:
                GameObject.Find("Third").GetComponent<Button>().interactable = false;
                break;
            case 3:
                break;
        }
    }
}
