using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plotPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            switch (gameObject.name)
            {
                case "plotPoint1":
                    myPlot.plotShow1();
                break;
                case "plotPoint2":
                    myPlot.plotShow2();
                    break;
                case "plotPoint3":
                    myPlot.plotShow3();
                    break;
                case "plotPoint4":
                    myPlot.plotShow4();
                    break;
                case "plotPoint5":
                    myPlot.plotShow5();
                    break;
                case "plotPoint6":
                    myPlot.plotShow6();
                    break;
                case "plotPoint7":
                    myPlot.plotShow7();
                    break;
                case "plotPoint8":
                    myPlot.plotShow8();
                    break;
                case "plotPoint9":
                    myPlot.plotShow9();
                    break;
                case "plotPoint10":
                    myPlot.plotShow10();
                    break;
                case "plotPoint11":
                    myPlot.plotShow11();
                    break;
                case "plotPoint12":
                    myPlot.plotShow12();
                    break;
                case "plotPoint13":
                    myPlot.plotShow13();
                    break;
                case "plotPoint14":
                    myPlot.plotShow14();
                    break;
                case "plotPoint15":
                    myPlot.plotShow15();
                    break;
                case "plotPoint16":
                    myPlot.plotShow16();
                    break;
            }
           Destroy(this.gameObject);
            
        }
    }
}
