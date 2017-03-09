using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; //streamReader

public class oeInfoDATA : MonoBehaviour
{

    GameObject goObjINFO; //object ZERO
    TextMesh textObject;
    private string textINFO;
    private string fileINFO;
    public string info2 = "info z koodu...\n";

    int cntU; //update counter
   
    // Use this for initialization
    void Start()
    {
        Debug.Log("oeInfoDATA.constructor");


        goObjINFO = GameObject.Find("oeObjINFO1");
        textObject = GameObject.Find("textINFO1").GetComponent<TextMesh>();
        //textObject2.text = info2;

        //using (var streamReader = new StreamReader(@"d:\unity-temp-data/file1.txt"))
        {
            //fileINFO = streamReader.ReadToEnd();
            //Debug.Log("---------------- textFile1 " + fileINFO);
            //textObject2.text += fileINFO;

            TextAsset PrnFile;
            PrnFile = Resources.Load("oeText1") as TextAsset;
            //Debug.Log(PrnFile.text); //.text?
            textObject.text = PrnFile.text;

            //Load texture from disk
            //TextAsset bindata = Resources.Load("Texture") as TextAsset;
            //Texture2D tex = new Texture2D(1, 1);
            //tex.LoadImage(bindata.bytes);


        }

    }

    // Update is called once per frame
    void Update()
    {
          





    }
}
