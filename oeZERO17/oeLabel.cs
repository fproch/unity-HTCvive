using UnityEngine;
using System.IO; //streamReader
using System.Collections; //JSON
using System.Collections.Generic;



public class oeLabel : MonoBehaviour
{
    //příprava
    public int matrixIndex;
    public string labelTxt = "label";
    public float characterSize = 0.02f;
    public int fontSize = 12;
    public bool showLabel = true;
    public bool labelCnt = false;
    public bool labelObjName = false;

    private Vector3 startVector; //stred vykresleni matice
    public Transform strartTransform;
   
    public bool doUpdate = false;
    public int everyMilisec = 10;

    private GameObject InputUI;
    int cntU;
   


    //================================================================================================
    //start-inicializace
    void Start()
    {
        Debug.Log("oeLabel.constructor - " + labelTxt);
        startVector = strartTransform.position;
       
        if (showLabel) oeText(labelTxt);
        if (labelObjName) InputUI.GetComponent<TextMesh>().text = this.name;   //"name123";

    }
    //------------------------------------------------/start----------------------------------------

    //timer cca60 FPS
    void Update()
    {
        cntU++;
        if (labelCnt) {
            //labelTxt = cntU.ToString();
            //InputUI.transform.position = strartTransform.position;
            //InputUI.transform.eulerAngles = strartTransform.eulerAngles;
            InputUI.GetComponent<TextMesh>().text = (100000+cntU).ToString();
        }


        if (cntU % everyMilisec == 0)
        {          
            InputUI.transform.position = strartTransform.position;
            InputUI.transform.eulerAngles = strartTransform.eulerAngles ;
        }



    }

    //------------------------------------------------------------------------------------------------
    private void oeText(string txt)
    {

        InputUI = new GameObject("tx");

        InputUI.transform.position = strartTransform.position;
        InputUI.transform.eulerAngles = strartTransform.eulerAngles;
        /*
        InputUI.transform.parent = transform;
        InputUI.transform.position = transform.position
                                         + transform.forward * 0.32f                     //moving it in front of the cam so that it can be seen at all
                                         + transform.right * cameraWidth * -0.000215f    //positioning to the bottom-left of the screen
                                         + transform.up * -0.17f;                        //if the camera dimensions change - text stays on bottom, but shifts side-wise
                                                                                        //  -> first if in Update()
         InputUI.transform.rotation = transform.rotation;
         InputUI.transform.localScale = new Vector3(0.02f, 0.02f, 1.0f);
          */

        InputUI.AddComponent<TextMesh>();
        InputUI.GetComponent<TextMesh>().characterSize = characterSize; // This is to ensure
        InputUI.GetComponent<TextMesh>().fontSize = fontSize;       // that the text is not blurry
        InputUI.GetComponent<TextMesh>().anchor = TextAnchor.LowerLeft;

        InputUI.GetComponent<TextMesh>().text = "   " + txt;


    }




   

}



