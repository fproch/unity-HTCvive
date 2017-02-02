using UnityEngine;
using System.IO; //streamReader
using System.Collections; //JSON
using System.Collections.Generic;

//http://answers.unity3d.com/questions/332001/how-to-reset-a-gamev-object-to-its-original-rotati.html
//

public class oeData16 : MonoBehaviour
{
    //příprava
    string textFile;
    int cntBTC;
    int cntLED;
    int cntU;
    public string data16File = "unity-temp-data/data16.txt";
    string[] dataLines16; //
    string lineOfText;

    GameObject goObj0; //object ZERO
    GameObject goObj1;
    GameObject goObj2;
    GameObject goObj3;
    GameObject goObj4;
    GameObject goObj5;
    GameObject goObj6;
    GameObject goObj7;
    GameObject goObj8;
    GameObject goObj9;
    GameObject goObj10;
    //2017
    string[] oeObjName = { "obj0", "obj1", "obj2" }; //board-foto/light/cube-wall-.../... 
    public GameObject[] goObj;
    int indexObj;


    public Transform originalValue;
    private LineRenderer line;
    private Color lineColor = Color.red;
    private int lineWidth = 1;
    public Renderer rend1;
    TextMesh textObject0;

    //================================================================================================
    //start-inicializace
    void Start()
    {
        Debug.Log("oeData16.constructor");

        //Scene scene = SceneManager.GetActiveScene();
        //scene.name; // name of scene
        string sName = Application.loadedLevelName;
        data16File = "unity-temp-data/data16"+sName+".txt";
        Debug.Log(data16File);

       goObj = new GameObject[255];

       
        indexObj = 0;
        foreach (string value in oeObjName)
        {
            Debug.Log(indexObj.ToString()+":"+value);
            goObj[indexObj] = GameObject.Find("obj0");
            indexObj++;
        }


        dataLines16 = new string[255];  

        goObj0 = GameObject.Find("oeObj0");
        goObj1 = GameObject.Find("obj1");
        goObj2 = GameObject.Find("obj2");
        goObj3 = GameObject.Find("obj3");
        goObj4 = GameObject.Find("obj4");
        goObj5 = GameObject.Find("obj5");
        goObj6 = GameObject.Find("obj6");
        goObj7 = GameObject.Find("obj7");
        goObj8 = GameObject.Find("obj8");
        goObj9 = GameObject.Find("obj9");
        goObj10 = GameObject.Find("obj10");
        

        textObject0 = GameObject.Find("text0").GetComponent<TextMesh>();        
              
        rend1 = goObj0.GetComponent<Renderer>();
        float deltaRnd1 = Mathf.Floor(Random.Range(0, 3));
        if (deltaRnd1 == 1) rend1.material.color = Color.white;
        if (deltaRnd1 == 2) rend1.material.color = Color.blue;
        if (deltaRnd1 == 3) rend1.material.color = Color.black;

        //file1
        using (var streamReader = new StreamReader(@"d:\unity-temp-data/file1.txt"))
        {
            textFile = streamReader.ReadToEnd();
            Debug.Log("---------------- textFile1 " + textFile);               
        }

        var jsonD = System.IO.File.ReadAllText(@"d:\unity-temp-data/file2.json");
        Debug.Log("---------------- JSON-File2 " + jsonD);
        //textObject.text = json;

        StartCoroutine(iBTC());
        StartCoroutine(iTime());
        StartCoroutine(iGetLed2());

        //float.Parse(reader.Value.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
        //saveDataTest();
        //originalValue = goObj0.transform;
        loadDataFile();


        loadData(goObj0, 0);
        loadData(goObj1, 1);
        loadData(goObj2, 2);
        loadData(goObj3, 3);
        loadData(goObj4, 4);
        loadData(goObj5, 5);
        loadData(goObj6, 6);
        loadData(goObj7, 7);
        loadData(goObj8, 8);
        loadData(goObj9, 9);
        loadData(goObj10, 10);

        
    }
    //------------------------------------------------/start----------------------------------------

    //timer cca60 FPS
    void Update()
    {
        //DrawLine();

        cntU++;
        int kazdych = 3000;

        if (cntU % 100 == 0)
        {
            ///Debug.Log(cntU.ToString());
            string sCnt = "Object ZERO: obj0 \ncounter cntU: " + cntU.ToString() + "\n";
            string sPos = "possition x:" + Mathf.Round(goObj0.transform.position.x*1000)/1000 + " y:" + Mathf.Round(goObj0.transform.position.y * 1000) / 1000 + " z:" + Mathf.Round(goObj0.transform.position.z * 1000) / 1000 + "\n";
            string sRot1 = "rotation  x:" + Mathf.Round(goObj0.transform.rotation.x * 1000) / 1000 + " y:" + Mathf.Round(goObj0.transform.rotation.y * 1000) / 1000 + " z:" + Mathf.Round(goObj0.transform.rotation.z * 1000) / 1000 + "\n";
            string sRot2 = "rotation  x:" + Mathf.Round(goObj0.transform.eulerAngles.x * 1000) / 1000 + " y:" + Mathf.Round(goObj0.transform.eulerAngles.y * 1000) / 1000 + " z:" + Mathf.Round(goObj0.transform.eulerAngles.z * 1000) / 1000 + "\n";
            string sSca = "scale  :" + Mathf.Round(goObj0.transform.localScale.x * 1000) / 1000;
            string sNote = "...";

            textObject0.text = sCnt + sPos+ sRot1 + sRot2 + sSca + sNote;
        }

        if (cntU % kazdych == 0)
        {
            rend1.material.color = Color.red;
           
            saveData(goObj0, 0);
            saveData(goObj1, 1);
            saveData(goObj2, 2);
            saveData(goObj3, 3);
            saveData(goObj4, 4);
            saveData(goObj5, 5);
            saveData(goObj6, 6);
            saveData(goObj7, 7);
            saveData(goObj8, 8);
            saveData(goObj9, 9);
            saveData(goObj10, 10);
            indexObj = 0;
           


            System.IO.File.WriteAllLines(@"c:\" + data16File, dataLines16);
        }

        if ((cntU-50) % kazdych*5 == 0)
        {
            rend1.material.color = Color.blue;
           
        }

        if ((cntU - 100) % kazdych*5 == 0)
        {
            rend1.material.color = Color.green;
            loadDataFile();
           
            loadData(goObj0, 0);
            loadData(goObj1, 1);
            loadData(goObj2, 2);
            loadData(goObj3, 3);
            loadData(goObj4, 4);
            loadData(goObj5, 5);
            loadData(goObj6, 6);
            loadData(goObj7, 7);
            loadData(goObj8, 8);
            loadData(goObj9, 9);
            loadData(goObj10, 10);

        }

       


    }

    //------------------------------------------------------------------------------------------------
    private void SetLine1()
    {
        line = transform.FindChild("Line").GetComponent<LineRenderer>();
        ///line.material = Resources.Load("TooltipLine") as Material;
        line.material.color = lineColor;

        //line.GetComponent<LineRenderer>().startColor(lineColor);
        line.SetColors(lineColor, lineColor);
        line.SetWidth(lineWidth, lineWidth);

        line.SetPosition(0, new Vector3(0, 2, -11));
        line.SetPosition(1, new Vector3(10, 10, 10));       

    }
    

    private void SetLine()
    {
        line = transform.FindChild("Line").GetComponent<LineRenderer>();
        line.material = Resources.Load("TooltipLine") as Material;
        line.material.color = lineColor;
        line.SetColors(lineColor, lineColor);
        line.SetWidth(lineWidth, lineWidth);

        line.SetPosition(0, goObj0.transform.position);
        line.SetPosition(1, new Vector3(10,10,10));          
    }

    private void DrawLine()
    {       
            //line.SetPosition(0, goObj0.transform.position);
            //line.SetPosition(1, originalValue.position);       
    }


    private void saveData(GameObject go, int id)
    {
        //x//dataLines16 = { "x", "y", "z" };
        //Debug.Log(id.ToString() + " >>> saveData ");
        dataLines16[id * 6 + 0] = (Mathf.Round(go.transform.position.x * 1000) / 1000).ToString();
        dataLines16[id * 6 + 1] = (Mathf.Round(go.transform.position.y * 1000) / 1000).ToString();
        dataLines16[id * 6 + 2] = (Mathf.Round(go.transform.position.z * 1000) / 1000).ToString();

        dataLines16[id * 6 + 3] = (Mathf.Round(go.transform.eulerAngles.x * 1000) / 1000).ToString();
        dataLines16[id * 6 + 4] = (Mathf.Round(go.transform.eulerAngles.y * 1000) / 1000).ToString();
        dataLines16[id * 6 + 5] = (Mathf.Round(go.transform.eulerAngles.z * 1000) / 1000).ToString();
        //dataLines16[5] = (Mathf.Round(go.transform.eulerAngles.w * 1000) / 1000).ToString();
       
       


    }

    private void loadDataFile()
    {
        Debug.Log("loadData():");
        var file = new System.IO.StreamReader(@"c:\" + data16File, System.Text.Encoding.UTF8, true, 128);

        int indexLine = 0;
        while ((lineOfText = file.ReadLine()) != null)
        {
            dataLines16[indexLine] = lineOfText;
            Debug.Log(indexLine.ToString() + " > " + dataLines16[indexLine].ToString());
            indexLine++;
        }

    }


    private void loadData(GameObject go, int id)
    {       

        float dx = float.Parse(dataLines16[id * 6 + 0]);
        float dy = float.Parse(dataLines16[id * 6 + 1]);
        float dz = float.Parse(dataLines16[id * 6 + 2]);
        float rx = float.Parse(dataLines16[id * 6 + 3]);
        float ry = float.Parse(dataLines16[id * 6 + 4]);
        float rz = float.Parse(dataLines16[id * 6 + 5]);
        //float rw = float.Parse(dataLines16[5]);

        go.transform.position = new Vector3(dx, dy, dz);        
        go.transform.eulerAngles = new Vector3(rx, ry, rz); 

    }


    private void saveDataTest()
    {
        // Example #2:
        string[] lines = { "First line", "Second line", "Third line" };
        System.IO.File.WriteAllLines(@"d:\unity-temp-data\WriteLines.txt", lines);

        // Example #2: Write one string to a text file.
        string text = "A class is the most powerful data type in C#. Like a structure, " +
                       "a class defines the data and behavior of the data type. ";
        System.IO.File.WriteAllText(@"d:\unity-temp-data\WriteText.txt", text);

        // Example #3: Write only some strings in an array to a file.
        using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"d:\unity-temp-data\WriteLines2.txt"))
        {
            foreach (string line in lines)
            {
               if (!line.Contains("Second"))  {   file.WriteLine(line);  }
            }
        }

    }

   
    private IEnumerator iGetLed2()
    {
        Debug.Log("IoT light off");
        WWW w = new WWW("http://sentu.cz/api/led2.txt");
        yield return w;
        if (w.error != null)
        {
            Debug.Log("Error .. " + w.error);  // for example, often 'Error .. 404 Not Found'
        }
        else
        {
            Debug.Log("Led2 - Found ... ==>" + w.text + "<==");
            //textObjectLED.text = cntLED.ToString() + ": " + w.text;
            cntLED++;
        }

        //teleport0
        // go.AddComponent<SteamVR_Camera>().ForceLast();
        //myCam.transform.position = myCam.transform.position + new Vector3(0, 1F, 0);


    }

    private IEnumerator iIoTon()
    {
        Debug.Log("IoT light on ->");
        WWW w1 = new WWW("http://sentu.cz/api/led2.php?light2=on");
        yield return w1;
        if (w1.error != null)
        {
            Debug.Log("Error .. " + w1.error);  // for example, often 'Error .. 404 Not Found'
        }
        else { Debug.Log("Ligt2on - Found ... ==>" + w1.text + "<=="); }


    }

    private IEnumerator iIoToff()
    {
        Debug.Log("IoT light off ->");
        WWW w0 = new WWW("http://sentu.cz/api/led2.php?lihgt2=off");
        yield return w0;
        if (w0.error != null)
        {
            Debug.Log("Error .. " + w0.error);  // for example, often 'Error .. 404 Not Found'
        }
        else { Debug.Log("Ligt2off - Found ... ==>" + w0.text + "<=="); }

    }

    private IEnumerator iBTC()
    {
        //StartCoroutine(BTC());
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
            Debug.Log("Found BTC... ==>" + wBTC.text + "<==");
        }
        var jsonBTC = wBTC.text;
        int poziceKurzu = jsonBTC.IndexOf("last");
        //Debug.Log(poziceKurzu);
        float kurzBTC = float.Parse(jsonBTC.Substring(poziceKurzu + 8, 5));
        Debug.Log(kurzBTC);
        //textObjectBTC.text = cntBTC.ToString() + " B> " + kurzBTC.ToString();
        cntBTC++;
        //public JSONNode btcData;

        //System.IO.File.ReadAllText(@"d:\unity-temp-data/test.json");
        //btcData = ProcessInboundData(jsonBTC);

        //var kBTC = JsonUtility.FromJson<object>(jsonBTC); //["last"];
        //var kBTC = JsonUtility.FromJson<Info[]>(jsonBTC);
        //Debug.Log("BTC::: " + kBTC[0].ToString());


        //var objects = JArray.Parse(jsonBTC); // parse as array 
        //myObject = JsonUtility.FromJson(jsonBTC);
        //List<Item> items = JsonConvert.DeserializeObject<List<Item>>(jsonBTC);
        //Debug.Log("BTC::: " + items);

        //example code to separate all that text in to lines:
        //longStringFromFile = w.text
        //List<string> lines = new List<string>(longStringFromFile.Split(new string[] { "\r","\n" }, StringSplitOptions.RemoveEmptyEntries) );
        // remove comment lines...
        //lines = lines.Where(line => !(line.StartsWith("//") || line.StartsWith("#"))).ToList();

        //return toRet;

    }


    private IEnumerator iTime()
    {
        Debug.Log(">Check");
        WWW w = new WWW("http://sentu.cz/api/datetime.php");
        yield return w;
        //toRet = "NIC";
        if (w.error != null)
        {
            Debug.Log("Error .. " + w.error);
            // for example, often 'Error .. 404 Not Found'
        }
        else
        {
            Debug.Log("Found ... ==>" + w.text + "<==");
            //toRet = w.text;
            // don't forget to look in the 'bottom section'
            // of Unity console to see the full text of
            // multiline console messages.
        }
        //textObjectRED.text = toRet;
        ///textObjectRED.text = w.text.Substring(0, 19);  //"cudl RED";
       Debug.Log("--- w.text.Substring .. " + w.text.Substring(0, 19));

        /* example code to separate all that text in to lines:
        longStringFromFile = w.text
        List<string> lines = new List<string>(
            longStringFromFile
            .Split(new string[] { "\r","\n" },
            StringSplitOptions.RemoveEmptyEntries) );
        // remove comment lines...
        lines = lines
            .Where(line => !(line.StartsWith("//")
                            || line.StartsWith("#")))
            .ToList();
        */
        //return toRet;




    }
}
