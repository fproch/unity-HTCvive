using UnityEngine;
using System.Collections;
using System.IO; //streamReader
using System.Collections; //JSON
using System.Collections.Generic;

public class oeInfo : MonoBehaviour
{
    public string toRet;
    //----------------------------------------

    public oeInfo()
    {
        Debug.Log("oeInfo.constructor");
        //StartCoroutine(BTC());
        //StartCoroutine(GetDateTime());
        
    }




    // Use this for initialization
    void Start () {
        Debug.Log("oeInfo.start()");

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public int GetNum(int inNum)
    {
        return 123*inNum;
    }


    private IEnumerator BTC()
    {
        //StartCoroutine(BTC());
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
        //textObject.text = cntBTC.ToString() + " B> " + kurzBTC.ToString();
        //textObject2B.text = cntBTC.ToString() + " B> " + kurzBTC.ToString();
        //cntBTC++;

    }

    private IEnumerator GetLed2()
    {
        Debug.Log("IoT light off");
        WWW w = new WWW("http://sentu.cz/api/led2.txt");
        yield return w;
        if (w.error != null)
        {
            Debug.Log("Error .. " + w.error);  // for example, often 'Error .. 404 Not Found'
        }
        else
        {
            Debug.Log("Led2 - Found ... ==>" + w.text + "<==");
            //textObject.text = cntLED.ToString() + ": " + w.text;
            //cntLED++;
            //if (cntLED == 3) SceneManager.LoadScene("oeIntroDraft");


        }

        //teleport0
        // go.AddComponent<SteamVR_Camera>().ForceLast();
        //myCam.transform.position = myCam.transform.position + new Vector3(0, 1F, 0);


    }

    private IEnumerator IoTon()
    {
        Debug.Log("IoT light on ->");
        WWW w1 = new WWW("http://sentu.cz/api/led2.php?light2=on");
        yield return w1;
        if (w1.error != null)
        {
            Debug.Log("Error .. " + w1.error);  // for example, often 'Error .. 404 Not Found'
        }
        else { Debug.Log("Ligt2on - Found ... ==>" + w1.text + "<=="); }

    }

    private IEnumerator IoToff()
    {
        Debug.Log("IoT light off ->");
        WWW w0 = new WWW("http://sentu.cz/api/led2.php?lihgt2=off");
        yield return w0;
        if (w0.error != null)
        {
            Debug.Log("Error .. " + w0.error);  // for example, often 'Error .. 404 Not Found'
        }
        else { Debug.Log("Ligt2off - Found ... ==>" + w0.text + "<=="); }
    }


    private IEnumerator GetDateTime()
    {
        Debug.Log(">Check");
        WWW w = new WWW("http://sentu.cz/api/datetime.php");
        yield return w;
        //toRet = "NIC";
        if (w.error != null)
        {
            Debug.Log("Error .. " + w.error);
            // for example, often 'Error .. 404 Not Found'
        }
        else
        {
            Debug.Log("Found ... ==>" + w.text + "<==");
            //toRet = w.text;
            // don't forget to look in the 'bottom section'
            // of Unity console to see the full text of
            // multiline console messages.
        }
        //textObjectRED.text = toRet;
        ///textObject.text = w.text.Substring(0, 19);  //"cudl RED";

        /* example code to separate all that text in to lines:
        longStringFromFile = w.text
        List<string> lines = new List<string>(
            longStringFromFile
            .Split(new string[] { "\r","\n" },
            StringSplitOptions.RemoveEmptyEntries) );
        // remove comment lines...
        lines = lines
            .Where(line => !(line.StartsWith("//")
                            || line.StartsWith("#")))
            .ToList();
        */
        //return toRet;
    }



    public IEnumerator getServerTime2()
    {
        //string toRet;
        WWW w = new WWW("http://sentu.cz/api/datetime.php");
        yield return w;
        toRet = "NIC";

        if (w.error != null)
        {
            Debug.Log("Error .. " + w.error);
            // for example, often 'Error .. 404 Not Found'
        }
        else
        {
            Debug.Log("oe getServer(): " + w.text);
            toRet = w.text;
            // don't forget to look in the 'bottom section'
            // of Unity console to see the full text of
            // multiline console messages.
        }

        /* example code to separate all that text in to lines:
        longStringFromFile = w.text
        List<string> lines = new List<string>(
            longStringFromFile
            .Split(new string[] { "\r","\n" },
            StringSplitOptions.RemoveEmptyEntries) );
        // remove comment lines...
        lines = lines
            .Where(line => !(line.StartsWith("//")
                            || line.StartsWith("#")))
            .ToList();
        */
        //return toRet;
    }

   /* public string GetTim()
    {
        StartCoroutine(getServerTime());
        //return toRet;
    }
    */


}
