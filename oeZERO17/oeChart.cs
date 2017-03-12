using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oeChart : MonoBehaviour
{

    private LineRenderer lineRenderer;
    private LineRenderer lineRenderer2;
    private float moveStrength = 0.5f;
    public GameObject go1;
    public float side = 5f;
    public Transform startTrans;
    public int points = 30;
    //public Vector3 startV = new Vector3(0,-2,5.5f); 
   

    // Use this for initialization
    void Start()
    {
        //go1 = GameObject.Find("plug1");

        //transform.Translate(Vector3.forward * (Vector3.Distance(target.position, transform.position)); //Movement slightly towards the object to negate the offset of sideways motion
        //transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, Time.deltaTime* 1);


        
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.numPositions = 5;
        lineRenderer2 = GetComponent<LineRenderer>();
        lineRenderer2.numPositions = points* points+ points*2;

        go1.transform.position = startTrans.position;

        SetLine();
        //SetLine2();
    }

    // Update is called once per frame
    void Update()
    {
        //SetLine();
    }

    void SetLine()
    {
        lineRenderer.SetPosition(0, go1.transform.position);
        lineRenderer.SetPosition(1, go1.transform.position + new Vector3(0, side, 0));
        lineRenderer.SetPosition(2, go1.transform.position + new Vector3(side, side, 0));
        lineRenderer.SetPosition(3, go1.transform.position + new Vector3(side, 0, 0));
        lineRenderer.SetPosition(4, go1.transform.position);

        int xp = 5;
        for (float r = 0; r < points; r++)
        {
            for (float x = 0; x < points; x++)
            {

                lineRenderer.SetPosition(xp, go1.transform.position + new Vector3(x / 2, Mathf.Sin(x / 2) + Mathf.Cos(r / 2), r));
                xp++;
            }
            lineRenderer.SetPosition(xp, go1.transform.position + new Vector3(points/2 ,0, r));
            xp++;
            lineRenderer.SetPosition(xp, go1.transform.position + new Vector3(0, 0, 0));
            xp++;
        }

        //lineRenderer.SetPosition(5, go1.transform.position + new Vector3(side / 2, 0, 0));
        //lineRenderer.SetPosition(6, go1.transform.position + new Vector3(side / 2, side, 0));
        //lineRenderer.SetPosition(7, go1.transform.position + new Vector3(side / 2 + side, side, 0));
        //lineRenderer.SetPosition(8, go1.transform.position + new Vector3(side / 2 + side, 0, 0));
        //lineRenderer.SetPosition(9, go1.transform.position + new Vector3(side / 2, 0, 0));
    }

    /*void SetLine2()
    {
        lineRenderer2.SetPosition(0, go1.transform.position + new Vector3(side/2, 0, 0));
        lineRenderer2.SetPosition(1, go1.transform.position + new Vector3(side/2, side, 0));
        lineRenderer2.SetPosition(2, go1.transform.position + new Vector3(side/2+side, side, 0));
        lineRenderer2.SetPosition(3, go1.transform.position + new Vector3(side/2+side, 0, 0));
        lineRenderer2.SetPosition(4, go1.transform.position + new Vector3(side/2, 0, 0));
    }*/

}