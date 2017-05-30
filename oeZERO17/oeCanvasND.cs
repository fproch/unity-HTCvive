using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//https://docs.unity3d.com/ScriptReference/LineRenderer.SetPosition.html
//----------------------------------------------------------------------


public class oeCanvasND : MonoBehaviour {

    public enum TF //type fyz
    { none, kinematic, gravity, both, random }

    public enum TO //type object
    {cube, sphere }

    public float canvasSize = 2;
    public bool showCenter = true;
    public bool distanceColor = false;
    public float distanceCenter = 0.5f;
    public bool showRandomTestStatic = false;
    public bool showRandomTest = true;
    public string s______________________________ = "---";
    public Color lineStart;
    public Color lineEnd;
    public bool drawLinesToCenter = false;
    public bool updateLinesToCenter = false;
    public bool drawLinesLine = false;
    public bool drawLinesAll = false;
    
    public float lineWidth = 0.01f;

    public TO typeObject;
    [Tooltip("Number of generated data")]
    public int numRnd = 100;
    public TF typeFyz;
    [Tooltip("Radius-Size 50 defa.")]
    public int rndDim = 50;
    public float sizeRnd = 0.05f;

    public bool isDynamic = false;
    public bool isDynamic2 = false;
    int cntU;
    public int deltaRndEvery = 100;

    GameObject goCenter;
    GameObject goData;
    GameObject[] goDataArr;  //basic
    GameObject[,] goDataArr2; //lineAll
    GameObject[] goDataArr3; //lineLine

    public float characterSize = 0.01f;
    public int fontSize = 12;
    public Color fontColor;
    public bool showLabels = false;
    public string s_data_____________________________ = "---";
    string data17File;
    public string dataFileName = "data3dint.txt";
    public bool saveData = false;
    public bool loadData = false;
        public string s_log_____________________________ = "---";
    [Tooltip("For debuging or testing")]
    public bool debugLog = false;
    public bool debugLogAll = false;

    Vector3[] data3D0; //array of 3D vector
    Vector3[] data3D; //
    oe3Dint[] data3Dint; //
    LineRenderer[] line;
    LineRenderer[] lineLine;
    LineRenderer[,] lineAll;
   

    private GameObject label1;

    // Use this for initialization
    void Start() {
        data17File = Application.dataPath + "/Resources/" + dataFileName;
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
            goData.transform.eulerAngles = transform.eulerAngles;

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
                float dist = Vector3.Distance(transform.localPosition, goData.transform.localPosition);
                if (distanceColor)
                {
                    if (dist < distanceCenter) rend.material.color = Color.red;
                }

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

        if (saveData)
        {
            if (debugLogAll) Debug.Log("---------------saveData");
            string data2save = "";
            for (int iData = 0; iData < numRnd; iData++)
            {
                data2save = data2save + (data3Dint[iData].x).ToString() + "," + (data3Dint[iData].y).ToString() + "," + (data3Dint[iData].z).ToString() + "\n";
            }
            if (debugLogAll) Debug.Log(data2save);
            System.IO.File.WriteAllText(data17File, data2save);
        }






    }

    void createRnd()
    {
        //data3Dint = new oe3Dint[numRnd];
        if (debugLogAll) Debug.Log("---------------createRnd()");

        for (int iData = 0; iData < numRnd; iData++)
        {

            switch (typeObject)
            {
                case TO.cube:
                    goDataArr[iData] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    break;

                case TO.sphere:
                    goDataArr[iData] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    break;              

                default:
                    goDataArr[iData] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    //Debug.Log("err obj Type");
                    break;
            }
            
           
            goCenter.name = "goRnd";

            goDataArr[iData].transform.localScale = new Vector3(sizeRnd, sizeRnd, sizeRnd);
            goDataArr[iData].transform.localPosition = transform.localPosition + new Vector3((float)(data3Dint[iData].x)/100, (float)(data3Dint[iData].y) / 100, (float)(data3Dint[iData].z) / 100);

            switch (typeFyz)
            {
                case TF.none:
                    //goDataArr[iData].GetComponent<Rigidbody>().useGravity = true;
                    //goDataArr[iData].GetComponent<Rigidbody>().isKinematic = false;
                    break;

                case TF.gravity:
                    goDataArr[iData].GetComponent<Rigidbody>().useGravity = true;
                    goDataArr[iData].GetComponent<Rigidbody>().isKinematic = false;
                    break;

                case TF.kinematic:
                    goDataArr[iData].GetComponent<Rigidbody>().useGravity = false;
                    goDataArr[iData].GetComponent<Rigidbody>().isKinematic = false;
                    break;

                case TF.random:
                    goDataArr[iData].GetComponent<Rigidbody>().useGravity = false;
                    goDataArr[iData].GetComponent<Rigidbody>().isKinematic = true;
                    break;

                default:
                    Debug.Log("err fyz Type");
                    break;
            }



            Renderer rend = goDataArr[iData].GetComponent<Renderer>();
            var randomC = Random.Range(1, 10);
            if (randomC == 3) rend.material.color = Color.red;
            float dist = Vector3.Distance(transform.localPosition, goDataArr[iData].transform.localPosition);
            if (distanceColor)
            {
                if (dist < distanceCenter) rend.material.color = Color.gray;
            }

            else rend.material.color = Color.white;

            if (showLabels) oeText1(goDataArr[iData], iData.ToString());
            
            if (drawLinesToCenter)
            {
                //line[iData] = GetComponent<LineRenderer>(); //ok pro updatre
                line[iData] = goDataArr[iData].AddComponent<LineRenderer>();
                line[iData].material = new Material(Shader.Find("Particles/Additive"));
                //line[iData] = goDataArr[iData].AddComponent<LineRenderer>;      

                line[iData].SetWidth(lineWidth*2, lineWidth*3);
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

        if (drawLinesAll)
        {
            if (debugLogAll) Debug.Log("---------------drawLinesAll()");
            goDataArr2 = new GameObject[numRnd,numRnd];
            lineAll = new LineRenderer[numRnd,numRnd];
            for (int iData = 0; iData < numRnd; iData++)
            {
                //int jData = 0;
                for (int jData = 0; jData < numRnd; jData++)
                {
                    if (debugLogAll) Debug.Log(iData + "," + jData + " > ");
                    //int k = iData * jData + jData;
                    goDataArr2[iData, jData] = GameObject.CreatePrimitive(PrimitiveType.Sphere);    //Cube); ///must exist
                    lineAll[iData ,jData] = goDataArr2[iData,jData].AddComponent<LineRenderer>();   //one objest > one compolent LR!
                    
                    lineAll[iData, jData].material = new Material(Shader.Find("Particles/Additive"));
                    lineAll[iData, jData].SetWidth(lineWidth, lineWidth);
                    lineAll[iData, jData].startColor = Color.white;
                    lineAll[iData, jData].endColor = Color.blue;
                    lineAll[iData, jData].SetVertexCount(2);
                    //lineRenderer.numPositions =2 ;
                    lineAll[iData, jData].SetPosition(0, goDataArr[iData].transform.localPosition);
                    lineAll[iData, jData].SetPosition(1, goDataArr[jData].transform.localPosition);                   
                } 
            }
        }

        if (drawLinesLine)
        {
            if (debugLogAll) Debug.Log("---------------drawLinesLine");
            goDataArr3 = new GameObject[numRnd];
            lineLine = new LineRenderer[numRnd+1];
            for (int iData = 0; iData < numRnd-1; iData++)
            {            
                   
                goDataArr3[iData] = GameObject.CreatePrimitive(PrimitiveType.Sphere);    //Cube); ///must exist
                lineLine[iData] = goDataArr3[iData].AddComponent<LineRenderer>();   //one objest > one compolent LR!

                lineLine[iData].material = new Material(Shader.Find("Particles/Additive"));
                lineLine[iData].SetWidth(lineWidth, lineWidth);
                lineLine[iData].startColor = Color.blue;
                lineLine[iData].endColor = Color.white;
                lineLine[iData].SetVertexCount(2);
                //lineRenderer.numPositions =2 ;
                lineLine[iData].SetPosition(0, goDataArr[iData].transform.localPosition);
                lineLine[iData].SetPosition(1, goDataArr[iData+1].transform.localPosition);
               
            }
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
            if (updateLinesToCenter)
            {                
                line[iData].SetPosition(0, transform.position);
                line[iData].SetPosition(1, goDataArr[iData].transform.localPosition);
            }
        }
    }


    private void oeText1(GameObject strartTransform,  string txt)
    {
        label1 = new GameObject("tx");
        label1.transform.position = strartTransform.transform.position + new Vector3(0, sizeRnd, 0);
        label1.transform.eulerAngles = strartTransform.transform.eulerAngles;
        /*
        InputUI.transform.parent = transform;
        InputUI.transform.position = transform.position
                                         + transform.forward * 0.32f                     //moving it in front of the cam so that it can be seen at all
                                         + transform.right * cameraWidth * -0.000215f    //positioning to the bottom-left of the screen
                                         + transform.up * -0.17f;                        //if the camera dimensions change - text stays on bottom, but shifts side-wise
                                                                                        //  -> first if in Update()
         InputUI.transform.rotation = transform.rotation;
         InputUI.transform.localScale = new Vector3(0.02f, 0.02f, 1.0f);          */

        label1.AddComponent<TextMesh>();
        label1.GetComponent<TextMesh>().characterSize = characterSize; // This is to ensure
        label1.GetComponent<TextMesh>().fontSize = fontSize;       // that the text is not blurry
        //label1.GetComponent<TextMesh>().font.material.color = fontColor;
        label1.GetComponent<TextMesh>().anchor = TextAnchor.LowerLeft;

        label1.GetComponent<TextMesh>().text = "   " + txt;
    }

    public class oe3Dint //normalize
                         //Random.Range(0, rndDim * 2) - rndDim) > 200: (-100 | +100 )
    {
        public int x;
        public int y;
        public int z;

        // Use this for initialization
        //void Start () {	}
        public oe3Dint(int sx, int sy, int sz) //costructor
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
