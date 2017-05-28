using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//https://docs.unity3d.com/ScriptReference/LineRenderer.SetPosition.html
//----------------------------------------------------------------------

public class oeCanvasND : MonoBehaviour {

    public float canvasSize = 2;
    public bool showCenter = true;
    public bool showRandomTestStatic = false;
    public bool showRandomTest = true;
    public bool drawLines = false;
    public float lineWidth = 0.01f;

    public int numRnd = 100;
    int rndDim = 50;
    public float sizeRnd = 0.05f;

    public bool isDynamic = false;
    public bool isDynamic2 = false;
    int cntU;
    public int deltaRndEvery = 100;

    GameObject goCenter;
    GameObject goData;
    GameObject[] goDataArr;
    public bool debugLog = false;
    public bool debugLogAll = false;

    Vector3[] data3D0; //array of 3D vector
    Vector3[] data3D; //
    oe3Dint[] data3Dint; //
    LineRenderer[] line;

    // Use this for initialization
    void Start() {
        data3D0 = new Vector3[8];
        data3D0[0] = new Vector3(1, 1, 1);
        data3D0[1] = new Vector3(-1, -1, -1);
        data3D0[2] = new Vector3(-1, -1, 1);
        data3D0[3] = new Vector3(-1, 1, -1);
        data3D0[4] = new Vector3(-1, 1, 1);
        data3D0[5] = new Vector3(1, -1, -1);
        data3D0[6] = new Vector3(1, 1, -1);
        data3D0[7] = new Vector3(1, -1, 1);



        if (debugLog) Debug.Log("--------------oeCanvasND");
        if (showCenter)
        {
            goCenter = GameObject.CreatePrimitive(PrimitiveType.Cube);
            goCenter.name = "goCenter";

            goCenter.transform.localScale = new Vector3(canvasSize / 20, canvasSize / 20, canvasSize / 20);
            goCenter.transform.localPosition = transform.localPosition;

            Renderer rend = goCenter.GetComponent<Renderer>();
            rend.material.color = Color.red;

            //  float deltaRnd2 = Mathf.Floor(Random.Range(0, numRandom));
            //  var randomA = Random.Range(200, 300);  

        }
        for (int iData = 0; iData < 8; iData++)
        {
            goData = GameObject.CreatePrimitive(PrimitiveType.Cube);
            goCenter.name = "goData";

            goData.transform.localScale = new Vector3(canvasSize / 20, canvasSize / 20, canvasSize / 20);
            goData.transform.localPosition = transform.localPosition + data3D0[iData];

            Renderer rend = goData.GetComponent<Renderer>();
            rend.material.color = Color.black;

        }

        if (showRandomTestStatic)
        {

           for (int iData = 0; iData < numRnd; iData++)
             {
                 goData = GameObject.CreatePrimitive(PrimitiveType.Cube);
                 goCenter.name = "goRnd";

                 goData.transform.localScale = new Vector3(sizeRnd, sizeRnd, sizeRnd);
                 goData.transform.localPosition = transform.localPosition + new Vector3((float)(Random.Range(0, rndDim * 2) - rndDim) / 100, (float)(Random.Range(0, rndDim * 2) - rndDim) / 100, (float)(Random.Range(0, rndDim * 2) - rndDim) / 100);

                 Renderer rend = goData.GetComponent<Renderer>();
                 rend.material.color = Color.white;

             }
        }
        

        if (showRandomTest)
        {
           initRnd();
           createRnd();
           /* for (int iData = 0; iData < numRnd; iData++)
            {
                goData = GameObject.CreatePrimitive(PrimitiveType.Cube);
                goCenter.name = "goRnd";

                goData.transform.localScale = new Vector3(sizeRnd, sizeRnd, sizeRnd);
                goData.transform.localPosition = transform.localPosition + new Vector3((float)(Random.Range(0, rndDim * 2) - rndDim) / 100, (float)(Random.Range(0, rndDim * 2) - rndDim) / 100, (float)(Random.Range(0, rndDim * 2) - rndDim) / 100);

                Renderer rend = goData.GetComponent<Renderer>();
                rend.material.color = Color.white;

            }*/
        }
    }

    // Update is called once per frame
    void Update() {
        cntU++;
        if (cntU % deltaRndEvery == 0)
        {

            if (isDynamic) {
                changeRnd(new oe3Dint(0, 0, 1));
                updateRnd();
            }

            if (isDynamic2)
            {
                changeRnd2();
                updateRnd();
            }

            /* {
                 for (int iData = 0; iData < numRnd; iData++)
                 {
                     goData = GameObject.CreatePrimitive(PrimitiveType.Cube);
                     goCenter.name = "goRnd";

                     goData.transform.localScale = new Vector3(sizeRnd, sizeRnd, sizeRnd);
                     goData.transform.localPosition = transform.localPosition + new Vector3((float)(Random.Range(0, rndDim * 2) - rndDim) / 100, (float)(Random.Range(0, rndDim * 2) - rndDim) / 100, (float)(Random.Range(0, rndDim * 2) - rndDim) / 100);

                     Renderer rend = goData.GetComponent<Renderer>();
                     var randomC = Random.Range(1, 10);
                     if (randomC == 3) rend.material.color = Color.red;
                     else rend.material.color = Color.white;
                     //var randomD = Random.Range(150, 200);
                     Destroy(goData, 50);

                 }
             }*/
        }
    }

    //------------------------------------------------------
    void initRnd()
    {
        if (debugLogAll) Debug.Log("---------------initRnd()");
        data3Dint = new oe3Dint[numRnd];
        goDataArr = new GameObject[numRnd];
        line = new LineRenderer[numRnd];

        //data3D = new Vector3[numRnd];

        for (int iData = 0; iData < numRnd; iData++)
        {
            data3Dint[iData] = new oe3Dint((Random.Range(0, rndDim * 2) - rndDim), (Random.Range(0, rndDim * 2) - rndDim), (Random.Range(0, rndDim * 2) - rndDim));
           
            // data3Dint[iData].z =  (Random.Range(0, rndDim * 2) - rndDim);
            if (debugLogAll) Debug.Log(iData + ": "+ data3Dint[iData].x + ", "+ data3Dint[iData].y + "," + data3Dint[iData].z);
            //data3Dint[iData] = new oe3Dint(1,2,3);// (Random.Range(0, rndDim * 2) - rndDim);
        }
    }

    void createRnd()
    {
        //data3Dint = new oe3Dint[numRnd];
        if (debugLogAll) Debug.Log("---------------createRnd()");

        for (int iData = 0; iData < numRnd; iData++)
        {
            goDataArr[iData] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            goCenter.name = "goRnd";

            goDataArr[iData].transform.localScale = new Vector3(sizeRnd, sizeRnd, sizeRnd);
            goDataArr[iData].transform.localPosition = transform.localPosition + new Vector3((float)(data3Dint[iData].x)/100, (float)(data3Dint[iData].y) / 100, (float)(data3Dint[iData].z) / 100);

            Renderer rend = goDataArr[iData].GetComponent<Renderer>();
            var randomC = Random.Range(1, 10);
            if (randomC == 3) rend.material.color = Color.red;
            else rend.material.color = Color.white;

            if (drawLines)
            {

                //line[iData] = GetComponent<LineRenderer>(); //ok pro updatre
                line[iData] = goDataArr[iData].AddComponent<LineRenderer>();
                line[iData].material = new Material(Shader.Find("Particles/Additive"));
                //line[iData] = goDataArr[iData].AddComponent<LineRenderer>;
      

                line[iData].SetWidth(lineWidth, lineWidth*2);
                //line.SetColor(Color.red, Color.yellow);
                
                line[iData].startColor = Color.red;
                line[iData].endColor = Color.yellow;
                //lineRenderer = thisCamera.AddComponent(LineRenderer);
                line[iData].SetVertexCount(2);
                //lineRenderer.numPositions =2 ;
                line[iData].SetPosition(0, transform.position);
                line[iData].SetPosition(1, goDataArr[iData].transform.localPosition);

            }



            //var randomD = Random.Range(150, 200);
            //Destroy(goDataArr[iData], 50);
        }
    }

    void changeRnd(oe3Dint moveVectorint)
    {
        //data3Dint = new oe3Dint[numRnd];

        for (int iData = 0; iData < numRnd; iData++)
        {
            data3Dint[iData].x = data3Dint[iData].x + moveVectorint.x;
            data3Dint[iData].y = data3Dint[iData].y + moveVectorint.y;
            data3Dint[iData].z = data3Dint[iData].z + moveVectorint.z;
            //goDataArr[iData].transform.localPosition = goDataArr[iData].transform.localPosition + moveVector;
            //goDataArr[iData].transform.localPosition = transform.localPosition + new Vector3((float)(data3Dint[iData].x) / 100, (float)(data3Dint[iData].y) / 100, (float)(data3Dint[iData].z) / 100);
        }
    }


    void changeRnd2()
    {
        //data3Dint = new oe3Dint[numRnd];

        for (int iData = 0; iData < numRnd; iData++)
        {
            data3Dint[iData].x = data3Dint[iData].x + (Random.Range(0, rndDim * 2) - rndDim)/20;
            data3Dint[iData].y = data3Dint[iData].y + (Random.Range(0, rndDim * 2) - rndDim) / 20;
            data3Dint[iData].z = data3Dint[iData].z + (Random.Range(0, rndDim * 2) - rndDim) / 20;
            //goDataArr[iData].transform.localPosition = goDataArr[iData].transform.localPosition + moveVector;
            //goDataArr[iData].transform.localPosition = transform.localPosition + new Vector3((float)(data3Dint[iData].x) / 100, (float)(data3Dint[iData].y) / 100, (float)(data3Dint[iData].z) / 100);
        }
    }


    void updateRnd()
    {
        //data3Dint = new oe3Dint[numRnd];
      
        for (int iData = 0; iData < numRnd; iData++)
        {
            //goDataArr[iData].transform.localPosition = goDataArr[iData].transform.localPosition + moveVector;
            goDataArr[iData].transform.localPosition = transform.localPosition + new Vector3((float)(data3Dint[iData].x) / 100, (float)(data3Dint[iData].y) / 100, (float)(data3Dint[iData].z) / 100);
        }
    }


    public class oe3Dint
    {

        //public static int x;
        //public static int y;
        //public static int z;

        public int x;
        public int y;
        public int z;

        // Use this for initialization
        //void Start () {	}

        public oe3Dint(int sx, int sy, int sz)
        {
            x = sx;
            y = sy;
            z = sz;
        }


        public void set(int sx, int sy, int sz)
        {
            x = sx;
            y = sy;
            z = sz;
        }

        
    }


}
