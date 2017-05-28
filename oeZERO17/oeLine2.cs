using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oeLine2 : MonoBehaviour {

   
    public GameObject point1;
    public GameObject point2;
    GameObject lineObject;
    private LineRenderer line;


    // Use this for initialization
    void Start () {
        //var go = GameObject.Instantiate(point1);
        //var lineRenderer = go.GetComponent<LineRenderer>();
        //var lineRenderer = go.AddComponent(LineRenderer);
        //var lineRenderer = src.AddComponent(LineRenderer);
        //lineObject = new GameObject("Line");
        lineObject = GameObject.Find("line");
        //line = lineObject.AddComponent(LineRenderer);
        line = GetComponent<LineRenderer>();
        line.SetWidth(0.1f, 0.5f);
        //line.SetColor(Color.red, Color.yellow);


        line.startColor = Color.red;
        line.endColor = Color.yellow;
        //lineRenderer = thisCamera.AddComponent(LineRenderer);
        line.SetVertexCount(2);
        //lineRenderer.numPositions =2 ;
        line.SetPosition(0, point1.transform.position);
        line.SetPosition(1, point2.transform.position);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
