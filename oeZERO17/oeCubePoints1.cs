using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oeCubePoints1 : MonoBehaviour
{
    public string nameObj = "oeCP1";
    public int horizontal = 5;
    public int vertical = 3;
    //public int size = 1;
    public float scale = 0.1f;
    public bool onlyWhite = false; //
    public Transform startTrans;

    private int cntU = 0;
    private int startTime = 10;
    private Renderer rend1;
    private Vector3 position0;

    // Use this for initialization
    void Start()
    {
        createCubePoints();
    }

    // Update is called once per frame
    void Update()
    {
        /*cntU++;       
        if (cntU == startTime)
        {
            createCubePoints();
        }*/
    }

    void createCubePoints()
    {

        position0 = startTrans.position; // Vector3.zero;

        for (int j = 0; j < vertical ; j++)
        {

            for (int i = 0; i < horizontal; i++)
            {
              
                position0.x += scale * 1.2f;
                GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                go.name = nameObj + j + "." + i;
                go.transform.position = position0;
                go.transform.localScale = new Vector3(scale, scale, scale);
                go.transform.SetParent(startTrans);
                //go.transform.position = startTrans.position;
                rend1 = go.GetComponent<Renderer>();
                if (onlyWhite)
               {

               }
               else
               {

                   float deltaRnd1 = Mathf.Floor(Random.Range(0, 100));
                   int nasCol = 200;
                   Color colorRnd = new Color((deltaRnd1 / nasCol), deltaRnd1 / nasCol, deltaRnd1 / nasCol);
                   rend1.material.color = colorRnd;
               }

            }
            position0.x = 0;
            position0.y += scale * 1.2f;         

        }

    }
}