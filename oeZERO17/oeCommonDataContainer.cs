using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//testing container for 16 integer values
//using: oeCommonDataContainer.setArrInt(myIndex, numOnDisplay);
//oeCommonDataContainer.getArrInt(0);
//oeCommonDataContainer.addArrStr(0,"system")
//oeCommonDataContainer.getArrStr(index)


public class oeCommonDataContainer : MonoBehaviour
{
    int cntU = 0;
    public int everyFPS = 300;
    public static bool debugTest = false; //asi se nedá zvenku / static
    public static int[] arrInt; //celé kouzlo je asi "public static"
    public static string[] arrStr; //
    private int arrLenght = 32;
   

    // Use this for initialization
    void Start()
    {
        Debug.Log("oeCommonDataContainer.init");
        arrInt = new int[arrLenght];
        arrStr = new string[arrLenght];
        for (int i = 0; i < arrInt.Length-1; i++) { arrInt[i] = 0; arrStr[i] = " "; }  
    }

    // Update is called once per frame
    void Update()
    {
        cntU++;
        if (cntU % everyFPS == 0) {
            //getArrInt(0);
            //getArrInt(1);
            //getArrInt(2);
        }
    }

    public static int getArrInt(int index)
    {
        if (debugTest) Debug.Log("--- oeCommonDataContainer --- getArrInt > index " + index + " value " + arrInt[index]);
        try { return arrInt[index]; }
        catch { return -1; }
    }

    public static void setArrInt(int index, int value)
    {
        //Debug.Log("--- oeCommonDataContainer --- getArrInt > index " + index + " value " + arrInt[index]);
        arrInt[index] = value;
    }

    public static string getArrStr(int index)
    {
        if (debugTest) Debug.Log("--- oeCommonDataContainer --- getArrInt > index " + index + " value " + arrInt[index]);
        try { return arrStr[index]; }
        catch { return "Err.getArrStr"; }        
    }

    public static void setArrStr(int index, string value)
    {
        //Debug.Log("--- oeCommonDataContainer --- getArrInt > index " + index + " value " + arrInt[index]);
        arrStr[index] = value;
    }

    public static void addArrStr(int index, string value)
    {
        //Debug.Log("--- oeCommonDataContainer --- getArrInt > index " + index + " value " + arrInt[index]);
        arrStr[index] = getArrStr(index) + "\n" + value;
    }


}
