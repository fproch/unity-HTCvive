using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class testLine : MonoBehaviour {

    private LineRenderer line;
    private Color lineColor = Color.red;
    private int lineWidth = 10;
    public Renderer rend1;

    // Use this for initialization
    void Start () {
        Debug.Log("testLine.constructor");
        //SetLine1();

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    private void SetLine1()
    {
        line = transform.Find("Line").GetComponent<LineRenderer>();
        ///line.material = Resources.Load("TooltipLine") as Material;
        line.material.color = lineColor;

        //line.GetComponent<LineRenderer>().startColor(lineColor);
        line.SetColors(lineColor, lineColor);
        line.SetWidth(lineWidth, lineWidth);

        line.SetPosition(0, new Vector3(0, 0,0));
        line.SetPosition(1, new Vector3(2,2, 2));

    }



}





