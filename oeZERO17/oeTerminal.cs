using UnityEngine;
using System.IO; //streamReader
using System.Collections; //JSON
using System.Collections.Generic;

public class oeTerminal : MonoBehaviour
{
    //příprava
    public int dataIndex = 0;
    public string headline = "...";
    public bool showHeadline = true;

    public float characterSize = 0.012f;
    public int fontSize = 12;
    public Color fontColor;

    public Transform strartTransform;
    private Vector3 startVector = new Vector3(0.02f, 0, 0);

    public bool doUpdate = false;
    public int everyMilisec = 10;

    private GameObject label1;
    int cntU;
    public bool logInfo = false;
    private int terminalNumLines = 16;




    string terminalText = "terminal test\n";

    //================================================================================================
    //start-inicializace
    void Start()
    {
        if (logInfo) Debug.Log("oeTerminal.constructor - " + dataIndex);
        //if (buttonTranf) strartTransform.transform.eulerAngles = strartTransform.eulerAngles + new Vector3(0, 90, 0); 
        //strartTransform.position = strartTransform.position + new Vector3(0,0.1f,0);
        //startVector = strartTransform.position;

        //terminalText = oeCommonDataContainer.getArrStr(dataIndex);
        oeTerminalText(true, terminalText);
        //label1.GetComponent<TextMesh>().text = strartTransform.name; // this.name;   //"name123";

    }
    //------------------------------------------------/start----------------------------------------

    //timer cca60 FPS
    void Update()
    {
        cntU++;
        if (cntU % everyMilisec == 0)
        {
            if (dataIndex == 2)
            {
                string terminalText2 = "";
                for (int i = 0; i < 9; i++)
                {
                    terminalText2 = terminalText2 + "\n" + i.ToString() + ": " + oeCommonDataContainer.getArrInt(i).ToString();
                }
                oeCommonDataContainer.setArrStr(2, terminalText2);
            }

            terminalText = oeCommonDataContainer.getArrStr(dataIndex);
            int numLines = terminalText.Split('\n').Length - 1;
            if (numLines <  terminalNumLines)
            {
                string addLines = "";
                for (int i = 0;i<(terminalNumLines-numLines);i++)
                {
                    addLines += "\n";
                }
                terminalText += addLines;
            }

            oeTerminalText(false, terminalText); //true = create again.. for painting width text ;-)
        }
    }
    
    private void oeTerminalText(bool create, string txt)
    {
        if (create) label1 = new GameObject("tx"+ dataIndex.ToString());
        if (showHeadline) txt = headline + "\n " + txt;
        label1.transform.position = strartTransform.position + startVector; // x, y=up, z
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
        //label1.GetComponent<MeshRenderer>().material.SetColor("_Color", fontColor);
        //label1.GetComponent<TextMesh>().color = fontColor;
        label1.GetComponent<TextMesh>().anchor = TextAnchor.LowerLeft;

        label1.GetComponent<TextMesh>().text = "   " + txt;
    }




}



