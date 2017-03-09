using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oeLightTest : MonoBehaviour {

    int cntU;
    Light oeLight; 

	// Use this for initialization
	void Start () {
        Debug.Log("oeLightTest.Start");
        oeLight = GameObject.Find("oeLight1").GetComponent<Light>();
        //oeLight = GameObject.FindObjectOfType<Light>();

    }
	
	// Update is called once per frame
	void Update () {
        cntU++;

        if (cntU % 10000 == 0)
        {
            Debug.Log("oeLightTest.ON");
            oeLight.enabled = true;
        }

        if (cntU % 11000 == 0)
        {
            Debug.Log("oeLightTest.OFF");
            oeLight.enabled = false;
        }

       

    }
}
