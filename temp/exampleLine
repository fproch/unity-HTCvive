using UnityEngine;
using System.Collections;

public class exampleLine : MonoBehaviour
{
    //(3) otazka: jak nejjednoduzsim zpusobem nakreslit line mezi dvěmi body? 
    //mozna zbytecne lineRenderer
    ///------------------------------------------------


    // Creates a line renderer that follows a Sin() function
    // and animates it.

    public Color c1 = Color.yellow;
    public Color c2 = Color.red;
    public int lengthOfLineRenderer = 1;
    GameObject goObj0; //object ZERO

    void Start()
    {
        goObj0 = GameObject.Find("obj0");

        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer.widthMultiplier = 0.1f;
        lineRenderer.numPositions = lengthOfLineRenderer;

        LineRenderer lineRenderer2 = gameObject.AddComponent<LineRenderer>();
        //lineRenderer2.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer2.widthMultiplier = 0.1f;
        lineRenderer2.numPositions = lengthOfLineRenderer;
        //lineRenderer2.SetPosition(0, new Vector3(0,0,0));
        //lineRenderer2.SetPosition(1, new Vector3(1,10,1));

        lineRenderer2 = GetComponent<LineRenderer>();
        lineRenderer2.SetPosition(0, new Vector3(0.0f, 0.0f, 0.0f));
        lineRenderer2.SetPosition(1, new Vector3(1.0f, 1.0f, 1.0f));


        // A simple 2 color gradient with a fixed alpha of 1.0f.
        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
            );
        lineRenderer.colorGradient = gradient;
    }

    void Update()
    {

        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        var t = Time.time;
        for (int i = 0; i < lengthOfLineRenderer; i++)
        {
            lineRenderer.SetPosition(i, new Vector3(i * 0.5f, Mathf.Sin(i + t), 0.0f));
        }

        //LineRenderer lineRenderer2 = GetComponent<LineRenderer>();
        //lineRenderer2.SetPosition(0, new Vector3(0.0f, 0.0f, 0.0f));
        //lineRenderer2.SetPosition(1, new Vector3(1.0f, 1.0f, 1.0f));
        //lineRenderer2.SetPosition(1, new Vector3(goObj0.transform.position.x, goObj0.transform.position.y, goObj0.transform.position.z)); 


    }

}
