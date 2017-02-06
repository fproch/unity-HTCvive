using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// oeObjClass - octopusengine 
// 0.19 (2017/01 firts public)
// 0.20 (2017/02 Hackathon)
//---------------------------
// todo - only Tag obj?
// test web-server - ZERO.json upload.. 

public class oeJsonData : MonoBehaviour {

    //příprava
    string textFile;
    int cntBTC;
    int cntLED;
    int cntU;
    public string data16File;
    string[] dataLines16; //
    string lineOfText;
    string dataString;

    //2017
    string[] oeObjName = { "oeObj0", "obj1", "obj2", "obj3", "obj4", "obj5", "obj6", "obj7"}; //board-foto/light/cube-wall-.../... 
    public GameObject goObj0;
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
        data16File = "unity-temp-data/data16" + sName + ".json";
        //Debug.Log(data16File);

        goObj = new GameObject[oeObjName.Length];

        indexObj = 0;
        foreach (string value in oeObjName)
        {
            goObj[indexObj] = GameObject.Find(value);
            indexObj++;
        }


        dataLines16 = new string[255];

        goObj0 = GameObject.Find("oeObj0");
        textObject0 = GameObject.Find("text0").GetComponent<TextMesh>();
        rend1 = goObj0.GetComponent<Renderer>();

        /*
        var jsonD = System.IO.File.ReadAllText(@"d:\unity-temp-data/file2.json");
        Debug.Log("---------------- JSON-File2 " + jsonD);
        //textObject.text = json;
        */
        
        oeLoad();

    }
    //------------------------------------------------/start----------------------------------------

    //timer cca60 FPS
    void Update()
    {
        cntU++;
        int kazdych = 1000;

        if (cntU % kazdych == 0)
        {
            rend1.material.color = Color.red;
            oeSave();
        }

        if ((cntU - 100) % kazdych * 5 == 0)
        {
            rend1.material.color = Color.green;
            oeLoad();
        }
    }
    //------------------------------------------------------------------------------------------------

    private void oeLoad()
    {
        //Debug.Log("loadData():");
        var file = new System.IO.StreamReader(@"c:\" + data16File, System.Text.Encoding.UTF8, true, 128);

        dataString = file.ReadToEnd();
        file.Close();

        //Debug.Log("dataString: " + dataString);
        oeObjWrapper wrapperLoad = JsonUtility.FromJson<oeObjWrapper>(dataString);
        Debug.Log("wrapper, fst object: " + wrapperLoad.oeObjects[0].oT);

        int index = 0;
        foreach (var obj in wrapperLoad.oeObjects)
        {
            Debug.Log("obj " + index + " -> " + obj.oT);
            obj.setPropertiesToGameObject(goObj[index]);
            index++;
        }
    }

    private void oeSave()
    {
        oeObjClass[] oeObjArray = new oeObjClass[goObj.Length];

        int index = 0;
        foreach (var go in goObj)
        {        
            //Debug.Log(index + " " + go.transform.position);
            oeObjArray[index] = new oeObjClass(go, index);
            index++;
        }
  
        oeObjWrapper wrapperSave = new oeObjWrapper();      
        wrapperSave.oeObjects = oeObjArray;
        string json = JsonUtility.ToJson(wrapperSave);

        Debug.Log(json);
        Debug.Log(data16File);

        System.IO.File.WriteAllText(@"c:\" + data16File, json);
    }
}
