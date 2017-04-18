using UnityEngine;
using System.IO; //streamReader
using System.Collections; //JSON
using System.Collections.Generic;

public class oeLabel : MonoBehaviour
{
    //příprava
    public int matrixIndex;
   
    public float characterSize = 0.02f;
    public int fontSize = 15;
    public Color fontColor;
    public bool showLabel1 = true;
    public float littleBitDown = 0;
    public bool showLabel2 = false;
    public bool showLabel3 = false;
    
    public bool labelObjName1 = false;
    public string labelTxt = "label"; // for label2
    public bool labelCnt3 = false;
    public bool labelRnd3 = false;


    private Vector3 startVector; //stred vykresleni matice
    public Transform strartTransform;
    public bool buttonTranf = false;
   
    public bool doUpdate = false;
    public int everyMilisec = 10;

    private GameObject label1;
    private GameObject label2;
    private GameObject label3;
    int cntU;

    public bool label2Data = false;
    public int dataIndex = 0;

   


    //================================================================================================
    //start-inicializace
    void Start()
    {
        Debug.Log("oeLabel.constructor - " + labelTxt);
        //if (buttonTranf) strartTransform.transform.eulerAngles = strartTransform.eulerAngles + new Vector3(0, 90, 0); 
        //strartTransform.position = strartTransform.position + new Vector3(0,0.1f,0);
        startVector = strartTransform.position;

        if (showLabel1) oeText1(labelTxt);
        if (showLabel2 || label2Data) oeText2(labelTxt);
        if (showLabel3) oeText3(labelTxt);
        if (labelObjName1) label1.GetComponent<TextMesh>().text = strartTransform.name; // this.name;   //"name123";

    }
    //------------------------------------------------/start----------------------------------------

    //timer cca60 FPS
    void Update()
    {
        cntU++;
        if (labelCnt3) {
            //labelTxt = cntU.ToString();
            //InputUI.transform.position = strartTransform.position;
            //InputUI.transform.eulerAngles = strartTransform.eulerAngles;
            label3.GetComponent<TextMesh>().text = (cntU/50).ToString();
        }

        if (cntU % everyMilisec == 0)
        {
            if (showLabel1)
            {

                if (buttonTranf)
                {
                    label1.transform.position = strartTransform.position + new Vector3(-0.05f, lineOffset(1), 0);
                    label1.transform.eulerAngles = strartTransform.eulerAngles + new Vector3(90, 90, 90);
                }
                else
                {
                    label1.transform.position = strartTransform.position + new Vector3(0, lineOffset(1), 0);
                    label1.transform.eulerAngles = strartTransform.eulerAngles;
                }
            }

            if (showLabel2)
            {
                label2.transform.position = strartTransform.position + new Vector3(0, lineOffset(2), 0);
                label2.transform.eulerAngles = strartTransform.eulerAngles;
                label2.GetComponent<TextMesh>().text = labelTxt;
            }

            if (showLabel3)
            {
                label3.transform.position = strartTransform.position + new Vector3(0, lineOffset(3), 0);
                label3.transform.eulerAngles = strartTransform.eulerAngles;
                var random1 = Random.Range(1000000, 9999999);
                if (labelRnd3) label3.GetComponent<TextMesh>().text = random1.ToString() + "\n" + (random1 / 2).ToString() + "\n" + (random1 / 3).ToString();

            }

            if (label2Data)
            {
                // oeCommonDataContainer.setArrInt(indexData, (int)e.normalizedValue);
                label2.transform.position = strartTransform.position + new Vector3(0, lineOffset(2), 0);
                label2.transform.eulerAngles = strartTransform.eulerAngles;
                label2.GetComponent<TextMesh>().text = dataIndex.ToString() + ": " + oeCommonDataContainer.getArrInt(dataIndex);//  + "\n" + oeCommonDataContainer.getArrStr(dataIndex);
            }          

        }
    }

    //------------------------------------------------------------------------------------------------
    public float lineOffset(int line)   { return (float)(fontSize * line*2 -50) / -1000 - littleBitDown; }


    private void oeText1(string txt)
    {
        label1 = new GameObject("tx");
        label1.transform.position = strartTransform.position + new Vector3(0, lineOffset(1), 0);
        label1.transform.eulerAngles = strartTransform.eulerAngles;
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
        //label1.GetComponent<TextMesh>().color = fontColor;
        label1.GetComponent<TextMesh>().anchor = TextAnchor.LowerLeft;

        label1.GetComponent<TextMesh>().text = "   " + txt;
    }

    private void oeText2(string txt)
    {
        label2 = new GameObject("tx2");
        label2.transform.position = strartTransform.position + new Vector3(0, lineOffset(2), 0);
        label2.transform.eulerAngles = strartTransform.eulerAngles;

        label2.AddComponent<TextMesh>();
        label2.GetComponent<TextMesh>().characterSize = characterSize; // This is to ensure
        label2.GetComponent<TextMesh>().fontSize = fontSize;       // that the text is not blurry
        label2.GetComponent<TextMesh>().anchor = TextAnchor.LowerLeft;

        label2.GetComponent<TextMesh>().text = "   " + txt;
    }

    private void oeText3(string txt)
    {
        label3 = new GameObject("tx3");
        label3.transform.position = strartTransform.position + new Vector3(0, lineOffset(3), 0);
       
        label3.transform.eulerAngles = strartTransform.eulerAngles;

        label3.AddComponent<TextMesh>();
        label3.GetComponent<TextMesh>().characterSize = characterSize; // This is to ensure
        label3.GetComponent<TextMesh>().fontSize = fontSize;       // that the text is not blurry
        label3.GetComponent<TextMesh>().anchor = TextAnchor.LowerLeft;

        label3.GetComponent<TextMesh>().text = "   " + txt;
    }



}



