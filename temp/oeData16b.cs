using UnityEngine;
using System.IO; //streamReader
using System.Collections; //JSON
using System.Collections.Generic;



public class oeData16b : MonoBehaviour
{
    //ulozeni kompletni pozice jedineho objektu - do txt souboru, jen na jednotlive radky.. viz. kod
    //nefunguje korektne  goObj0.transform.Rotate(new Vector3(rx, ry, rz));
    //http://answers.unity3d.com/questions/332001/how-to-reset-a-gamev-object-to-its-original-rotati.html
    //

    //příprava
    string textFile;
    int cntBTC;
    int cntLED;
    int cntU;
    string data16File = "unity-temp-data/data16.txt";
    string[] dataLines16 = { "x", "y", "z", "x", "y", "z" };
    string lineOfText;

    GameObject goObj0; //object ZERO
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
        goObj0 = GameObject.Find("obj0");
        textObject0 = GameObject.Find("text0").GetComponent<TextMesh>();        

        //cubeMatrix1[i * numCube + j] = (GameObject)Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube), new Vector2(i + Matrix1x, j + Matrix1z), Quaternion.identity);
        //cubeMatrix1[i * numCube + j].transform.localScale = new Vector3(0.8F, 0.5F, 0.8F);

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

        //float.Parse(reader.Value.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
        //saveDataTest();
        originalValue = goObj0.transform;
        loadData();
    }
    //------------------------------------------------/start----------------------------------------

    //timer cca60 FPS
    void Update()
    {
        cntU++;
        if (cntU % 100 == 0)  //simple timer cca 0.6 sec (60FPs>/100)
        {
            Debug.Log(cntU.ToString());
            string sCnt = "Object ZERO: obj0 \ncounter cntU: " + cntU.ToString() + "\n";
            string sPos = "possition x:" + Mathf.Round(goObj0.transform.position.x*1000)/1000 + " y:" + Mathf.Round(goObj0.transform.position.y * 1000) / 1000 + " z:" + Mathf.Round(goObj0.transform.position.z * 1000) / 1000 + "\n";
            string sRot1 = "rotation  x:" + Mathf.Round(goObj0.transform.rotation.x * 1000) / 1000 + " y:" + Mathf.Round(goObj0.transform.rotation.y * 1000) / 1000 + " z:" + Mathf.Round(goObj0.transform.rotation.z * 1000) / 1000 + "\n";
            string sRot2 = "rot2 ";
            //string sRot2 = "rotation  x:" + Mathf.Round(Quaternion.Slerp(transform.rotation * 1000) / 1000 + " y:" + Mathf.Round(goObj0.transform.rotation.y * 1000) / 1000 + " z:" + Mathf.Round(goObj0.transform.rotation.z * 1000) / 1000 + "\n";
            string sSca = "scale  :" + Mathf.Round(goObj0.transform.localScale.x * 1000) / 1000;
            string sNote = "...";

            textObject0.text = sCnt + sPos+ sRot1 + sRot2 + sSca + sNote;
        }

        if (cntU == 700)
        {
            //automaticke ulozeni po cca sedmi sec.
            rend1.material.color = Color.red;
            saveData();
        }


    }

    //------------------------------------------------------------------------------------------------
      private void saveData()
    {

        //x//dataLines16 = { "x", "y", "z" };
        dataLines16[0] = (Mathf.Round(goObj0.transform.position.x * 1000) / 1000).ToString();
        dataLines16[1] = (Mathf.Round(goObj0.transform.position.y * 1000) / 1000).ToString();
        dataLines16[2] = (Mathf.Round(goObj0.transform.position.z * 1000) / 1000).ToString();
        dataLines16[3] = (Mathf.Round(goObj0.transform.rotation.x * 1000) / 1000).ToString();
        dataLines16[4] = (Mathf.Round(goObj0.transform.rotation.y * 1000) / 1000).ToString();
        dataLines16[5] = (Mathf.Round(goObj0.transform.rotation.z * 1000) / 1000).ToString();
        System.IO.File.WriteAllLines(@"d:\"+data16File, dataLines16); 
    }


    private void loadData()
    {
        Debug.Log("loadData():");
        var file = new System.IO.StreamReader(@"d:\" + data16File, System.Text.Encoding.UTF8, true, 128);

        int indexLine = 0;
        while ((lineOfText = file.ReadLine()) != null)
        {
            dataLines16[indexLine] = lineOfText;
            Debug.Log(indexLine.ToString()+" > "+ dataLines16[indexLine].ToString());
            indexLine++;
        }

        float dx = float.Parse(dataLines16[0]);
        float dy = float.Parse(dataLines16[1]);
        float dz = float.Parse(dataLines16[2]);
        float rx = float.Parse(dataLines16[3]);
        float ry = float.Parse(dataLines16[4]);
        float rz = float.Parse(dataLines16[5]);
        //goObj0.transform.position = new Vector3(dx,dy,dz);
        Debug.Log("x:"+ dx.ToString());
        Debug.Log("rx:" + rx.ToString());
        goObj0.transform.position = new Vector3(dx, dy, dz);

        //Quaternion target = Quaternion.Euler(dx, dy, dz);
        goObj0.transform.Rotate(new Vector3(rx, ry, rz));
        //goObj0.transform.rotation = Quaternion.Slerp(transform.rotation, originalRotationValue.rotation, Time.time * 10);
        //Local????

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
}
