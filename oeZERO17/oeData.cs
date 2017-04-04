using UnityEngine;
using System.IO; //streamReader
using System.Collections; //JSON
using System.Collections.Generic;

//http://answers.unity3d.com/questions/332001/how-to-reset-a-gamev-object-to-its-original-rotati.html
//

public class oeData : MonoBehaviour
{
    //příprava
    string textFile;
    string lineOfText;
    public string dataFile = "data.txt";
    string[] dataLines; // 
        
    //================================================================================================
    //start-inicializace
    void Start()
    {
        Debug.Log("oeData.constructor");
        Debug.Log(dataFile);
        dataLines = new string[255];        
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
        var file = new System.IO.StreamReader(dataFile, System.Text.Encoding.UTF8, true, 128);

        int indexLine = 0;
        while ((lineOfText = file.ReadLine()) != null)
        {
            dataLines[indexLine] = lineOfText;
            Debug.Log(indexLine.ToString() + " > " + dataLines[indexLine].ToString());
            indexLine++;
        }
        
        Debug.Log("first dataLines test > " + dataLines[0].ToString());

        string[] lineData;
        lineData = (dataLines[0].Trim()).Split(";"[0]);

        Debug.Log("lineData x test > " + lineData[0]);
        
        float x =  float.Parse(lineData[0]);
        Debug.Log("lineData x+1 test > " + (x+1).ToString());

    }
}
