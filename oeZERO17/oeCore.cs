using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// oeObjClass - octopusengine 
// 0.19 (2017/01 firts public)
// 0.20 (2017/02 Hackathon)
// 0.30 (2017/03 Demo03 oeCore)
//---------------------------
// todo - only Tag obj?
// test web-server - ZERO.json upload.. 

public class oeCore : MonoBehaviour
{
    //public GameObject[] oeBasicTag;
    public bool ListAllObjects = false;

    GameObject goTag;
    int iObj = 0;
    int iTag = 0; //index for tag

    string textFile;
    int cntBTC;
    int cntLED;
    int cntU;
    public string data17File;
    public string dataString;
    string[] dataLines16; //
    string lineOfText;

    // 2016:
    string[] oeObjName = { "oeObjZERO", "oeObjINFO1", "oeObjINFO2", "obj2", "obj3", "obj4", "obj5", "obj6", "obj7", "obj8", "obj9", "cubeYel1", "cubeYel2", "cubeYel2", "cubeYel4", "cubeYel5", "cubeYel6", "cubeYel7", "cubeYel8", "cubeYel9", "light1", "light2", "light3", "lightR", "lightG", "lightB" }; //board-foto/light/cube-wall-.../... 
    GameObject[] oeObjSave; // 2017: oeObjSave.name = oeObjName
    public GameObject goObj0;
    public GameObject[] goObj;
    int indexObj;


    public Transform originalValue;
    private LineRenderer line;
    private Color lineColor = Color.red;
    private int lineWidth = 1;
    public Renderer rend1;
    TextMesh textObject0;
    //public string dataFile = Application.dataPath+"/Resources/";

    //================================================================================================
    //start-inicializace
    void Start()
    {
        Debug.Log("--- oeCore.Start ---"); //semi-constructor

        if (ListAllObjects)
        {
            GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
            foreach (object go in allObjects)
            {
                Debug.Log(iObj + " > " + go.ToString());
                iObj++;
            }
        }

        Debug.Log("-------- TAG --------"); //https://docs.unity3d.com/ScriptReference/GameObject.FindGameObjectsWithTag.html
        oeObjSave = GameObject.FindGameObjectsWithTag("oeSave");

        indexObj = 0;
        foreach (GameObject goTag in oeObjSave)
        {
            //Instantiate(respawnPrefab, respawn.transform.position, respawn.transform.rotation);
            Debug.Log("oeSave >>> " + goTag.name);
            oeObjName[indexObj++] = goTag.name;
            //goObj[indexObj] = goTag; //GameObject.Find(value);
            indexObj++;
        }

        Debug.Log("----------------------oeCore17.Start(End)");
        

        //Scene scene = SceneManager.GetActiveScene();
        //scene.name; // name of scene
        string sName = Application.loadedLevelName;
        data17File = Application.dataPath + "/Resources/" + sName + ".json";
        //Debug.Log(data16File);

        goObj = new GameObject[oeObjName.Length];

        indexObj = 0;
        foreach (string value in oeObjName)
        {
            goObj[indexObj] = GameObject.Find(value);
            indexObj++;
        }


        dataLines16 = new string[255];

        goObj0 = GameObject.Find("oeObjZERO");
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
        int kazdych = 3000;

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
        var file = new System.IO.StreamReader(data17File, System.Text.Encoding.UTF8, true, 128);

        dataString = file.ReadToEnd();
        file.Close();

        //Debug.Log("dataString: " + dataString);
        oeObjWrapper wrapperLoad = JsonUtility.FromJson<oeObjWrapper>(dataString);
        //Debug.Log("wrapper, fst object: " + wrapperLoad.oeObjects[0].oT);

        int index = 0;
        foreach (var obj in wrapperLoad.oeObjects)
        {
            //Debug.Log("obj " + index + " -> " + obj.oT);
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

        ///Debug.Log(data16File);
        System.IO.File.WriteAllText(data17File, json);
    }
}
