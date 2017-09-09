using UnityEngine;
using System.IO; //streamReader
using System.Collections; //JSON
using System.Collections.Generic;

//http://answers.unity3d.com/questions/332001/how-to-reset-a-gamev-object-to-its-original-rotati.html
//

public class oeTree1 : MonoBehaviour
{
    //příprava
    string textFile;
    string lineOfText;
    public string dataFile = "tree1.txt";

    int[,] fields;
    string[] dataLines;

    string[] lineData;
    GameObject go;
    Renderer rend;
    public int MaximumPoints = 10000;
    public int xMinus;
    public int yMinus;
    public enum NO { Sphere, Cube }
    public float scaleSize = 0.1f;
    public int scaleTransp = 5;
    public NO newObjects;
   // public string nameObj = "dObj";

    [Tooltip("For debuging or testing")]
    public bool debugList = false;


    //================================================================================================
    //start-inicializace
    void Start()
    {
        if (debugList)
        {
            Debug.Log("oeTree.constructor: " + newObjects);
            Debug.Log(dataFile);
        }
        oeLoadData();
    }
    //------------------------------------------------/start----------------------------------------

    //timer cca60 FPS
    void Update()
    {


    }

    //------------------------------------------------------------------------------------------------



    private void oeLoadData()
    {
        Debug.Log("loadData():");

        //var file = new System.IO.StreamReader(@"c:\" + data16File, System.Text.Encoding.UTF8, true, 128);
        string sName = Application.loadedLevelName;
        dataFile = Application.dataPath + "/Resources/" + dataFile;

        int lineCount = 1;
        using (var reader = File.OpenText(@dataFile))
        {
            while (reader.ReadLine() != null)
            {
                lineCount++;
            }
            if (debugList)
                Debug.Log("Line count: " + lineCount);
        }
        fields = new int[lineCount, 3];
        dataLines = new string[lineCount];


        var file = new System.IO.StreamReader(dataFile, System.Text.Encoding.UTF8, true, 128);
        int indexLine = 1;
        while ((lineOfText = file.ReadLine()) != null)
        {
            if (indexLine < lineCount)
            {
                dataLines[indexLine] = lineOfText;
                /*
                if (debugList)
                    Debug.Log(indexLine.ToString() + " > " + dataLines[indexLine].ToString());
                    */
                lineData = (dataLines[indexLine].Trim()).Split(';');
                if (debugList)
                    Debug.Log("name: " + lineData[0] + " - parent: " + lineData[1]);
                fields[indexLine, 0] = int.Parse(lineData[0]);
                fields[indexLine, 1] = int.Parse(lineData[1]);
                fields[indexLine, 2] = 0;

                fields[fields[indexLine, 1], 2]++;
            }
            indexLine++;
        }



        /*
        Debug.Log("------------ indexLines > " + indexLine);
        Debug.Log("first dataLines test > " + dataLines[0].ToString());
        lineData = (dataLines[0].Trim()).Split(";"[0]);
        Debug.Log("lineData x test > " + lineData[0]);
        float x = float.Parse(lineData[0]) - xMinus;
        Debug.Log("lineData x+1 test > " + (x + 1).ToString());
        */
        /*
        {
        for (int i = 1; i < lineCount; i++)
             if (fields[i, 1] == 0);
                fields[0, 1]++;
            Debug.Log("Main children: " + fields[0, 1].ToString());
        gameObject.GetComponent<VRTK.Examples.oeUzel>().quantity = fields[0, 1];*/
        gameObject.GetComponent<VRTK.Examples.oeUzel>().oeInitChildren();
       // }

        if (debugList)
            for (int i = 1; i < lineCount; i++)
                Debug.Log("Object #" + fields[i, 0].ToString() + " has parent #" + fields[i, 1].ToString() + " and " + fields[i, 2].ToString() + "children.");
        
        for (int i = 1; i < lineCount; i++)
        {
            if (debugList)
                Debug.Log("Object #" + fields[i, 0] + " is being born.");
            if (fields[i, 1] == 0)
            {
                gameObject.GetComponent<VRTK.Examples.oeUzel>().oeCreateChild(fields[i, 0].ToString(), fields[i, 2]);
            }
            else
            {
                Debug.Log("(cr) Looking for " + fields[i, 1].ToString());
                /*
                while (fields )
                string parentGO = */
                GameObject.Find(fields[i, 1].ToString()).GetComponent<VRTK.Examples.oeUzel>().oeCreateChild(fields[i, 0].ToString(), fields[i, 2]);
            }
            Debug.Log("(mod) Looking for " + fields[i, 0].ToString() + " : " + fields[i, 0]); 
            GameObject.Find(fields[i, 0].ToString()).GetComponent<VRTK.Examples.oeUzel>().oeInitChildren();
        }
    }
}
