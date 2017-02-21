using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Linq;


public class oeZeroNet : MonoBehaviour {
    int cntU;
    private int numZERO;
    private int numZEROdelta;
    private int numZEROold;
    public Vector3 transZERO;
    public Vector3 transZEROdelta;
    public Vector3 transZEROold;

    // Use this for initialization
    void Start () {
        Debug.Log("oeZeroNet.constructor()");
        //StartCoroutine(getZero1());        
        StartCoroutine(getZero2());       
        StartCoroutine(BTC());
    }

    // Update is called once per frame*100
    void Update () {
        cntU++;
        if (cntU % 50 == 0)  //simple timer cca 0.6 sec (60FPs>/100)
        {
            //StartCoroutine(getZero1());
            StartCoroutine(getZero2());
        }
    }

    //------------------------------------------------------------------
    [Serializable]
    public class netData2
    {
        public int x;
        public int y;
        public int z;
    }

    private IEnumerator getZero2()
    {
        Debug.Log("-------getZero2-------");
        WWW w2 = new WWW("http://octopusengine.org/api/zero2.json");
        yield return w2;
        if (w2.error != null) { Debug.Log("Error .. " + w2.error); } 
            else
        {
            Debug.Log("==>" + w2.text + "<==");
            netData2 tt = JsonUtility.FromJson<netData2>(w2.text);
            transZERO = new Vector3(tt.x, tt.y, tt.z);
            //Debug.Log("zero x: " + transZERO.x);
            //Debug.Log("zero y: " + transZERO.y);
            //Debug.Log("zero z: " + transZERO.z);

            transZEROdelta = transZEROold - transZERO;
            transform.Translate(new Vector3((float)transZEROdelta.x / 10, (float)transZEROdelta.y / 10, (float)transZEROdelta.z / 10));
            transZEROold = transZERO;
            }   

    }

    private IEnumerator getZero1()
    {
        Debug.Log("getZero1");
        WWW w = new WWW("http://octopusengine.org/api/get-zero1.php");
        yield return w;
        if (w.error != null)  { Debug.Log("Error .. " + w.error); } // for example, often 'Error .. 404 Not Found'
        else
        {
            numZERO = Convert.ToInt32(w.text);
            numZEROdelta = numZEROold - numZERO;
            Debug.Log("Delta1  ==>" + numZEROdelta.ToString() + "<==");
            transform.Translate(new Vector3((float)numZEROdelta /10, 0, 0));
            numZEROold = numZERO;
        }
    }
 
    private IEnumerator BTC()
    {
        Debug.Log(">BTC");
        WWW wBTC = new WWW("https://www.bitstamp.net/api/ticker");
        yield return wBTC;
        //toRet = "NIC";
        if (wBTC.error != null)
        {
            Debug.Log("Error BTC.. " + wBTC.error);
            // for example, often 'Error .. 404 Not Found'
        }
        else
        {
            Debug.Log("Found BTC... ==>" + wBTC.text + "<==");
        }
        var jsonBTC = wBTC.text;
        int poziceKurzu = jsonBTC.IndexOf("last");
        //Debug.Log(poziceKurzu);
        float kurzBTC = float.Parse(jsonBTC.Substring(poziceKurzu + 8, 5));
        Debug.Log(kurzBTC);
    }

}
