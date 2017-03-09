using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oeZeroDATA : MonoBehaviour {

    GameObject goObj0; //object ZERO
    GameObject goLed1; //LED
    GameObject goLed2; //LED
    GameObject goLed3; //LED
    GameObject goLed4; //LED
    GameObject goLed5; //LED
    TextMesh textObject0;
    TextMesh textObject2;
    private string textZERO; 

    public Renderer rend0;
    public Renderer rendLed;
    int cntU;
    /*
     * public Transform originalValue;
    private LineRenderer line;
    private Color lineColor = Color.red;
    private int lineWidth = 1;
   
   */

    // Use this for initialization
    void Start () {
        Debug.Log("oeZeroDATA.constructor");      


        goObj0 = GameObject.Find("oeObjZERO");
        textObject0 = GameObject.Find("text0").GetComponent<TextMesh>();
        textObject2 = GameObject.Find("text2").GetComponent<TextMesh>();
        textObject2.text = "scene name: "+ Application.loadedLevelName;

        goLed1 = GameObject.Find("oeLed1");
        goLed2 = GameObject.Find("oeLed2");
        goLed3 = GameObject.Find("oeLed3");
       
        rendLed = goLed1.GetComponent<Renderer>();
        rendLed.material.color = Color.white;
                
    }

    // Update is called once per frame
    void Update () {

        cntU++;
        if (cntU % 100 == 0)  //simple timer cca 0.6 sec (60FPs>/100)
        {
            float deltaRnd1 = Mathf.Floor(Random.Range(0, 3));
            if (deltaRnd1 == 1) rendLed.material.color = Color.red; else rendLed.material.color = Color.white;

            //Debug.Log(cntU.ToString());
            string sCnt = "Object ZERO: obj0 \ncounter cntU: " + cntU.ToString() + "\n";
            string sPos = "position x:" + Mathf.Round(goObj0.transform.position.x * 1000) / 1000 + " y:" + Mathf.Round(goObj0.transform.position.y * 1000) / 1000 + " z:" + Mathf.Round(goObj0.transform.position.z * 1000) / 1000 + "\n";
            string sRot1 = "rotation  x:" + Mathf.Round(goObj0.transform.rotation.x * 1000) / 1000 + " y:" + Mathf.Round(goObj0.transform.rotation.y * 1000) / 1000 + " z:" + Mathf.Round(goObj0.transform.rotation.z * 1000) / 1000 + "\n";
            string sRot2 = "rot2 ";
            //string sRot2 = "rotation  x:" + Mathf.Round(Quaternion.Slerp(transform.rotation * 1000) / 1000 + " y:" + Mathf.Round(goObj0.transform.rotation.y * 1000) / 1000 + " z:" + Mathf.Round(goObj0.transform.rotation.z * 1000) / 1000 + "\n";
            string sSca = "scale  :" + Mathf.Round(goObj0.transform.localScale.x * 1000) / 1000;
            string sNote = "net:";

            textObject0.text = sCnt + sPos + sRot1 + sRot2 + sSca + sNote;

           

        }



        

    }
}
