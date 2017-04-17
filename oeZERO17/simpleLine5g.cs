using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleLine5g : MonoBehaviour
{

    private LineRenderer lineRenderer;
    private float moveStrength = 0.5f;
    private GameObject go1;
    private GameObject go2;
    private GameObject go3;
    private GameObject go4;
    private GameObject go5;


    // Use this for initialization
    void Start()
    {
        go1 = GameObject.Find("cubeG1");
        go2 = GameObject.Find("cubeG2");
        go3 = GameObject.Find("cubeG3");
        go4 = GameObject.Find("cubeG4");
        go5 = GameObject.Find("cubeG5");

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 11;

        SetLine();
    }

    // Update is called once per frame
    void Update()
    {
        SetLine();
    }

    void SetLine()
    {
        lineRenderer.SetPosition(0, go1.transform.position);
        lineRenderer.SetPosition(1, go2.transform.position);
        lineRenderer.SetPosition(2, go3.transform.position);
        lineRenderer.SetPosition(3, go1.transform.position);
        lineRenderer.SetPosition(4, go4.transform.position);
        lineRenderer.SetPosition(5, go3.transform.position);
        lineRenderer.SetPosition(6, go5.transform.position);
        lineRenderer.SetPosition(7, go2.transform.position);
        lineRenderer.SetPosition(8, go4.transform.position);
        lineRenderer.SetPosition(9, go5.transform.position);
        lineRenderer.SetPosition(10, go1.transform.position);

    }

}