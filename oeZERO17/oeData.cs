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
    string[] lineData;
    GameObject go;
    Renderer rend;
    public int xMinus;
    public enum NO { Sphere, Cube }
    public float scaleSize = 0.1f;
    public NO newObjects;
    public string nameObj = "dObj";
    public bool debugList = false;


    //================================================================================================
    //start-inicializace
    void Start()
    {
        Debug.Log("oeData.constructor - newObjects: " + newObjects);
        Debug.Log(dataFile);
        dataLines = new string[100000];        
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
            if (debugList) Debug.Log(indexLine.ToString() + " > " + dataLines[indexLine].ToString());

            lineData = (dataLines[indexLine].Trim()).Split(";"[0]);
            go = GameObject.CreatePrimitive(PrimitiveType.Cube);

            try
            {
                float xi = float.Parse(lineData[0]) - xMinus;
                float yi = float.Parse(lineData[0]);
                float zi = float.Parse(lineData[0]);
               
                //Rigidbody gameObjectsRigidBody = go.AddComponent<Rigidbody>(); // Add the rigidbody.
                //gameObjectsRigidBody.mass = oeMass; // Set the GO's mass to 5 via the Rigidbod
                //go.GetComponent<Rigidbody>().useGravity = true;
                go.name = nameObj + "." + indexLine;
                if (debugList) Debug.Log(go.name);

                go.transform.position = new Vector3(xi, yi, zi);
                go.transform.localScale = new Vector3(scaleSize, scaleSize, scaleSize);
                
            }
            catch
            {
                Debug.Log("Err: try Parse...");
            }

            rend = go.GetComponent<Renderer>();
            indexLine++;
        }


        Debug.Log("------------ indexLines > " + indexLine);
        Debug.Log("first dataLines test > " + dataLines[0].ToString());        
        lineData = (dataLines[0].Trim()).Split(";"[0]);
        Debug.Log("lineData x test > " + lineData[0]);
        float x =  float.Parse(lineData[0]) - xMinus;
        Debug.Log("lineData x+1 test > " + (x+1).ToString());
       
    }
}
