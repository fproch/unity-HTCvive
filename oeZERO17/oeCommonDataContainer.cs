using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//testing container for 16 integer values
//using: oeCommonDataContainer.setArrInt(myIndex, numOnDisplay);
//oeCommonDataContainer.getArrInt(0);


public class oeCommonDataContainer : MonoBehaviour
{
    int cntU = 0;
    public int everyFPS = 300;
    public static bool debugTest = false; //asi se nedá zvenku / static
    public static int[] arrInt; //celé kouzlo je asi "public static"
    private int arrLenght = 128;
   

    // Use this for initialization
    void Start()
    {
        Debug.Log("oeCommonDataContainer.init");
        arrInt = new int[arrLenght];
        for (int i=0;i < arrInt.Length; i++) arrInt[i] = 0;  
    }

    // Update is called once per frame
    void Update()
    {
        cntU++;
        if (cntU % everyFPS == 0) {
            getArrInt(0);
            getArrInt(1);
            getArrInt(2);
        }
    }

    public static int getArrInt(int index)
    {
        if (debugTest) Debug.Log("--- oeCommonDataContainer --- getArrInt > index " + index + " value " + arrInt[index]);
        return arrInt[index];
    }

    public static void setArrInt(int index, int value)
    {
        //Debug.Log("--- oeCommonDataContainer --- getArrInt > index " + index + " value " + arrInt[index]);
        arrInt[index] = value;
    }   
}
