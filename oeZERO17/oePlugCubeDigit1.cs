using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oePlugCubeDigit1 : MonoBehaviour
{
    public string nameObj = "oeCD1";
    private int horizontal = 5;
    private int vertical = 9;
    //public int size = 1;
    public float scale = 0.1f;
    public bool onlyBlack = false; //
    public Transform startTrans;
   

    private int cntU = 0;
    private int startTime = 10;
    private Renderer rend1;
    private Vector3 position0;
    private GameObject[,] goD  = new GameObject[5, 9];

    private bool[,] numDigit = new bool[,] { 
        { true, true, true, true, true, true, false },  //0
        { false, true, true, false, false, false, false },  //1
        { true, true, false, true, true, false, true }, //2
        { true, true, true, true, false, false, true }, //3
        { false, true, true, false, false, true, true }, //
        { true, false, true, true, false, true, true }, //5
        { true, false, true, true, true, true, true },    //6
        { true, true, true, false, false, false, false }, //7
        { true, true, true, true, true, true, true },  //8
        { true, true, true, true, false, true, true }  //9
    };
    
    // Use this for initialization
    void Start()
    {   
        createCubePoints();
    }

    // Update is called once per frame
    void Update()
    {
        cntU++;
        int i = 0; int j = 0;        
        GameObject go = GameObject.Find(nameObj + j + "." + i); //?i obj reference     
        if (cntU % 100 ==0)
        {
            var randomD = Random.Range(-1, 9);
            drawNum(randomD);
        }     

    }


    int[,] digA() { int[,] points = new int[,] { { 3, 8 }, { 2, 8 }, { 1, 8 } };  return points; }
    int[,] digB() { int[,] points = new int[,] { { 0, 7 }, { 0,6  }, { 0, 5 } }; return points;  }
    int[,] digC() { int[,] points = new int[,] { { 0, 3 }, { 0, 2 }, { 0, 1 } }; return points; }
    int[,] digD() { int[,] points = new int[,] { { 3, 0 }, { 2, 0 }, { 1, 0 } }; return points; }
    int[,] digE() { int[,] points = new int[,] { { 4, 1 }, { 4, 2 }, { 4, 3 } }; return points; }
    int[,] digF() { int[,] points = new int[,] { { 4, 5 }, { 4, 6 }, { 4, 7 } }; return points; }
    int[,] digG() { int[,] points = new int[,] { { 3, 4 }, { 2, 4 }, { 1, 4 } }; return points; }

    void drawSegment(bool light, int[,] segment)
    {
        for (int s = 0; s < 3; s++)
        {
            //Debug.Log("--- segment ---" + s +": "+ segment[s, 0] + "." + segment[s, 1]);
            //go = GameObject.Find(nameObj + segment[s,0] + "." + segment[s, 1]);
            rend1 = goD[segment[s, 0], segment[s, 1]].GetComponent<Renderer>();
            if (light)  rend1.material.color = Color.red;
            else rend1.material.color = Color.black;
        }

    }

    void drawNum(int num) {
        if (num > 9) num = 9;
        if (num < 0)
        {
            drawSegment(false, digA());
            drawSegment(false, digB());
            drawSegment(false, digC());
            drawSegment(false, digD());
            drawSegment(false, digE());
            drawSegment(false, digF());
            drawSegment(false, digG());
        }

            if (num > -1)
        {
            drawSegment(numDigit[num, 0], digA());
            drawSegment(numDigit[num, 1], digB());
            drawSegment(numDigit[num, 2], digC());
            drawSegment(numDigit[num, 3], digD());
            drawSegment(numDigit[num, 4], digE());
            drawSegment(numDigit[num, 5], digF());
            drawSegment(numDigit[num, 6], digG());
        }
           
    }


    void createCubePoints()
    {

        position0 = startTrans.position+ new Vector3(0, scale * 2.5f, scale * 0); // Vector3.zero;

        for (int j = 0; j < vertical; j++)
        {

            for (int i = 0; i < horizontal; i++)
            {

                position0.x += scale * 1.1f;
                //GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                goD[i ,j]  = GameObject.CreatePrimitive(PrimitiveType.Cube);
                goD[i, j].name = nameObj + j + "." + i;
                goD[i, j].transform.position = position0;
                goD[i, j].transform.localScale = new Vector3(scale, scale, scale/2);
                goD[i, j].transform.SetParent(startTrans);
                //go.transform.position = startTrans.position;
                rend1 = goD[i, j].GetComponent<Renderer>();
                if (onlyBlack)
                {
                    Color colorBla = new Color(0,0,0);
                    rend1.material.color = colorBla;
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
            position0.y += scale * 1.1f;

        }

    }
}
