using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oeBezier : MonoBehaviour
{

    private List<GameObject> controlObjects;
    private List<Vector3> controlPoints;
    private LineRenderer lineRenderer;
    private List<Vector3> drawingPoints;
    private int actualControlIndex;
    public float moveStrength = 0.3f;

    public int noOfControls = 5;
    public bool randomize = true;
    public int speed = 10;
    public float randomizeStep = 0.01f;
    public float minX = 0;
    public float maxX = 5;
    public float minY = 0;
    public float maxY = 5;
    public float minZ = 0;
    public float maxZ = 5;

    public bool only5dynamic = false; 

    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public GameObject target4;
    public GameObject target5;



    private int timer;

    // Use this for initialization
    void Start()
    {
        InitControls();
        CreateBezier();
    }

    // Update is called once per frame
    void Update()
    {

        //controlObjects [actualControlIndex].GetComponent<Material> ().color = Color.white;

        if (Input.GetKey(KeyCode.N))
        {
            actualControlIndex++;
        }

        if (actualControlIndex == noOfControls)
        {
            actualControlIndex = 0;
        }

        GameObject controlledObj = controlObjects[actualControlIndex];
        //controlledObj.GetComponent<Material> ().color = Color.red;

        //bool noChange;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            controlledObj.transform.Translate(new Vector3(-moveStrength, 0, 0));
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            controlledObj.transform.Translate(new Vector3(moveStrength, 0, 0));
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            controlledObj.transform.Translate(new Vector3(0, 0, moveStrength));
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            controlledObj.transform.Translate(new Vector3(0, 0, -moveStrength));
        }

        controlPoints[actualControlIndex] = controlledObj.transform.position;

        if (timer % speed == 0)
        {
            Randomize();
        }
        timer++;

        CreateBezier();
    }

    private void InitControls()
    {
        controlObjects = new List<GameObject>();
        controlPoints = new List<Vector3>();

        if (only5dynamic)
        {
            controlObjects.Add(target1);
            controlPoints.Add(target1.transform.position);
            controlObjects.Add(target2);
            controlPoints.Add(target2.transform.position);
            controlObjects.Add(target3);
            controlPoints.Add(target3.transform.position);
        }
        else
        {
        for (int i = 0; i < noOfControls; i++)
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            go.name = "BezierControl" + i;
            //Material mat = go.AddComponent<Material>() as Material;
            //mat.color = Color.red;
            // go.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
            go.transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
            go.transform.localScale = new Vector3(0.2F, 0.2F, 0.2F);

            controlObjects.Add(go);
            controlPoints.Add(go.transform.position);
        }
        }


        actualControlIndex = 0;
    }

    private void CreateBezier()
    {
        BezierPath bezierPath = new BezierPath();
        // bezierPath.SamplePoints(controlObjects, 0.01f, 0.02f, 4f);
        bezierPath.Interpolate(controlPoints, 4f);
        drawingPoints = bezierPath.GetDrawingPoints2();
        SetLinePoints(drawingPoints);
    }


    private void SetLinePoints(List<Vector3> drawingPoints)
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetVertexCount(drawingPoints.Count);

        for (int i = 0; i < drawingPoints.Count; i++)
        {
            lineRenderer.SetPosition(i, drawingPoints[i]);
        }
    }

    private void Randomize()
    {
        if (!randomize)
        {
            return;
        }

        for (int i = 0; i < noOfControls; i++)
        {
            var random1 = Random.Range(-randomizeStep, randomizeStep);
            var random2 = Random.Range(-randomizeStep, randomizeStep);
            var random3 = Random.Range(-randomizeStep, randomizeStep);
            controlObjects[i].transform.Translate(new Vector3(random1, random2, random3));
            controlPoints[i] = controlObjects[i].transform.position;
        }
    }
}