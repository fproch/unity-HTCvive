using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oePlugCubeDigit9 : MonoBehaviour
{
    public string nameObj = "oeCD3";
    public int myIndex = 0;
    public int digits = 3;
    public bool testSliceY = false;
    public bool testSliceX = false;
    public bool testBTC = false;
    private int horizontal = 5;
    private int vertical = 9;
    //public int size = 1;
    public float scale = 0.1f;
    public bool onlyBlack = false; //
    public Transform startTrans;
    public Color digColor = Color.red;
    public int numOnDisplay = 123;

    private int cntU = 0;
    private int startTime = 10;
    private Renderer rend1;
    private Vector3 positionP;
    private GameObject[,,] goD = new GameObject[7, 5, 9]; //digits > 5x8
    //public oeCommonDataContainer[] myCommonDataContainer = new oeCommonDataContainer[];
    //public oeCommonDataContainer[] myCommonDataContainer;
    //public oeCommonDataContainer myCommonDataContainer;

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
        Debug.Log("oePlugCubeDigit3");
        //oeNumBuff pom
        //startTrans.position = startTrans.position + new Vector3(10, 1, 0); // Vector3.zero;
        if (testBTC) StartCoroutine(BTC());
        createCubePoints();
    }

    // Update is called once per frame
    void Update()
    {
        cntU++;

        if (cntU % 1000 == 0) { if (testBTC) StartCoroutine(BTC()); }

        if (cntU > 10000) cntU = 0;
        //int i = 0; int j = 0;
        //GameObject go = GameObject.Find(nameObj + j + "." + i); //?i obj reference     
        if (cntU % 200 == 0) //100
        {
            //var randomN = Random.Range(-1, 9);
            //var randomD = Random.Range(0, 2);
            //drawNum(randomD, randomN);

            //test
            if (digits == 1)
            {
             var randomN = Random.Range(0, 9);
             drawNum(0, randomN);
            }

            if ((digits == 2) || (digits == 3))
            {
                //var randomN = Random.Range(0, 9);
                //drawNum(0, randomN);



                int n100 = 0;
                int n10 = 0;
                int n1 = 0;

                if (testSliceY)
                {
                    numOnDisplay = (int)(startTrans.position.y * 30);
                    //myCommonDataContainer[myIndex] = numOnDisplay;
                    oeCommonDataContainer.setArrInt(myIndex, numOnDisplay);
                }
                else numOnDisplay = (int)cntU / 100;
                //numOnDisplay = 78;

                if (numOnDisplay < 10) { n1 = numOnDisplay; }
                if (numOnDisplay < 100 && numOnDisplay > 9)
                {
                    n10 = (int)(numOnDisplay / 10);
                    n1 = numOnDisplay - n10 * 10;
                }

                if (numOnDisplay < 1000 && numOnDisplay > 99)
                {
                    n100 = (int)(numOnDisplay / 100);
                    n10 = (int)((numOnDisplay - n100 * 100) / 10);
                    n1 = numOnDisplay - n100 * 100 - n10 * 10;
                }

                drawNum(0, n1);
                drawNum(1, n10);
                drawNum(2, n100);

            }

           


            if (digits == 5)
            {
                int n1000 = 0;
                int n100 = 0;
                int n10 = 0;
                int n1 = 0;

                //numOnDisplay = (int)cntU / 100;
                //if (numOnDisplay > 999) cntU = 0;

                n1000 = (int)(numOnDisplay / 1000);
                n100 = (int)((numOnDisplay-n1000*1000) / 100);
                n10 = (int)((numOnDisplay - n1000*1000 -n100 * 100) / 10);
                n1 = numOnDisplay - n1000*1000 - n100 * 100 - n10 * 10;

                drawNum(0, n1);
                drawNum(1, n10);
                drawNum(2, n100);
                drawNum(3, n1000);
            }

            if (digits == 7)
            {
                drawNum(0, 1);
                drawNum(1, 2);
                drawNum(2, 3);
                drawNum(3, 4);
                drawNum(4, 5);
                drawNum(5, 6);
                drawNum(6, 7);
                //drawNum(2, 3);
            }                        
        }
    }

    int[,] digA() { int[,] points = new int[,] { { 3, 8 }, { 2, 8 }, { 1, 8 } }; return points; }
    int[,] digB() { int[,] points = new int[,] { { 0, 7 }, { 0, 6 }, { 0, 5 } }; return points; }
    int[,] digC() { int[,] points = new int[,] { { 0, 3 }, { 0, 2 }, { 0, 1 } }; return points; }
    int[,] digD() { int[,] points = new int[,] { { 3, 0 }, { 2, 0 }, { 1, 0 } }; return points; }
    int[,] digE() { int[,] points = new int[,] { { 4, 1 }, { 4, 2 }, { 4, 3 } }; return points; }
    int[,] digF() { int[,] points = new int[,] { { 4, 5 }, { 4, 6 }, { 4, 7 } }; return points; }
    int[,] digG() { int[,] points = new int[,] { { 3, 4 }, { 2, 4 }, { 1, 4 } }; return points; }

    void drawSegment(int d,bool light, int[,] segment)
    {
        for (int s = 0; s < 3; s++)
        {
            //Debug.Log("--- segment ---" + s +": "+ segment[s, 0] + "." + segment[s, 1]);
            //go = GameObject.Find(nameObj + segment[s,0] + "." + segment[s, 1]);
            rend1 = goD[d, segment[s, 0], segment[s, 1]].GetComponent<Renderer>();
            if (light) rend1.material.color = digColor;
            else rend1.material.color = Color.black;
        }
    }

    void drawNum(int d,int num)
    {
        if (num > 9) num = 9;
        if (num < 0)
        {
            drawSegment(d,false, digA());
            drawSegment(d,false, digB());
            drawSegment(d,false, digC());
            drawSegment(d,false, digD());
            drawSegment(d,false, digE());
            drawSegment(d,false, digF());
            drawSegment(d,false, digG());
        }

        if (num > -1)
        {
            drawSegment(d,numDigit[num, 0], digA());
            drawSegment(d,numDigit[num, 1], digB());
            drawSegment(d,numDigit[num, 2], digC());
            drawSegment(d,numDigit[num, 3], digD());
            drawSegment(d,numDigit[num, 4], digE());
            drawSegment(d,numDigit[num, 5], digF());
            drawSegment(d,numDigit[num, 6], digG());
        }
    }

    void createCubePoints()
    {       
        float deltaX = 0;
        float deltaY = 0;
        positionP.z = startTrans.position.z + scale*3;

        for (int d = 0; d < digits; d++)
        {
            //Debug.Log("---digit: "+d);
            for (int j = 0; j < vertical; j++)
            {
                deltaY = j * scale * 1.1f;
                for (int i = 0; i < horizontal; i++)
                {
                    deltaX = i * scale * 1.1f;
                    positionP.x = startTrans.position.x + deltaX + scale * 7 * d + scale * 0.5f + 0.1f;
                    positionP.y = startTrans.position.y + deltaY - scale * 2f;
                    //GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    goD[d, i, j] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    goD[d, i, j].name = nameObj + d+"."+j + "." + i;
                    goD[d, i, j].transform.position = positionP;
                    goD[d, i, j].transform.localScale = new Vector3(scale, scale, scale / 2);
                    goD[d, i, j].transform.SetParent(startTrans);
                    //go.transform.position = startTrans.position;
                    rend1 = goD[d, i, j].GetComponent<Renderer>();
                    if (onlyBlack)
                    {
                        Color colorBla = new Color(0, 0, 0);
                        rend1.material.color = colorBla;
                    }
                    else
                    {
                        float deltaRnd1 = Mathf.Floor(Random.Range(0,10));
                        int nasCol = 100;
                        Color colorRnd = new Color((deltaRnd1 / nasCol), deltaRnd1 / nasCol, deltaRnd1 / nasCol);
                        rend1.material.color = colorRnd;
                    }
                }  //i    
                
                //positionP.x = 0;
                
            } //j
            //position0.y = 0;
        }
    }


    private IEnumerator BTC()
    {
        Debug.Log(">BTC");
        WWW wBTC = new WWW("https://www.bitstamp.net/api/ticker");
        yield return wBTC;
        //toRet = "NIC";
        if (wBTC.error != null)
        {
            Debug.Log("Error BTC.. " + wBTC.error);
            // for example, often 'Error .. 404 Not Found'
        }
        else
        {
            //Debug.Log("Found BTC... ==>" + wBTC.text + "<==");
        }
        var jsonBTC = wBTC.text;
        int poziceKurzu = jsonBTC.IndexOf("last");
        //Debug.Log(poziceKurzu);
        float kurzBTC = float.Parse(jsonBTC.Substring(poziceKurzu + 8, 5));
        Debug.Log(kurzBTC);
        numOnDisplay = (int)kurzBTC;
    }




}
