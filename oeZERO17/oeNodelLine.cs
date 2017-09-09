using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oeNodelLine : MonoBehaviour
{

    public int deltaRndEvery = 10;
    int cntU = 0;

    public float lineWidth = 0.002f;

    private LineRenderer lineRenderer;
    LineRenderer line;


    // Use this for initialization
    void Start()
    {
        line = gameObject.AddComponent<LineRenderer>();
        line.material = new Material(Shader.Find("Particles/Additive"));
        line.SetWidth(lineWidth * 2, lineWidth * 3);
        line.startColor = Color.red;
        line.endColor = Color.yellow;
        line.SetVertexCount(2);
    }

    // Update is called once per frame
    void Update()
    {
        cntU++;
        if (cntU % deltaRndEvery == 0 && transform.parent != null)
            updateLine();
    }

    void updateLine()
    {
        line.SetPosition(0, transform.parent.position);
        line.SetPosition(1, transform.position);
    }
}