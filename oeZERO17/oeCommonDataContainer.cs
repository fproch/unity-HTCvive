using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//testing container for 16 integer values

public class oeCommonDataContainer : MonoBehaviour
{
    int cntU = 0;
    public static bool debugTest = true; //asi se nedá zvenku / static
    public static int[] arrInt; //celé kouzlo je asi "public static"

    // Use this for initialization
    void Start()
    {
        Debug.Log("oeCommonDataContainer");
        arrInt = new int[16];
        for (int i=0;i < arrInt.Length; i++) arrInt[i] = i*10;  
    }

    // Update is called once per frame
    void Update()
    {
        cntU++;
        if (cntU % 200 == 0) {
            getArrInt(0);
            getArrInt(1);
            getArrInt(2);
        }
    }

    public static int getArrInt(int index)
    {
        //if (debug)
        if (debugTest) Debug.Log("--- oeCommonDataContainer --- getArrInt > index " + index + " value " + arrInt[index]);
        return arrInt[index];
    }

    public static void setArrInt(int index, int value)
    {
        //Debug.Log("--- oeCommonDataContainer --- getArrInt > index " + index + " value " + arrInt[index]);
        arrInt[index] = value;
    }   
}
