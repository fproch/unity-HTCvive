using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// oeObjClass - octopusengine 
// 0.19 (2017/01 firts public)
// 0.20 (2017/02 Hackathon)
//---------------------------

[System.Serializable]
public class oeObjClass{

    public int index;
    public string oN;
	public Vector3 oT;
	public Vector3 oR;
    //private int oValue;
    //private string oNote;

    public oeObjClass(GameObject go, string oN, int index)
    {
        this.index = index;
        this.oT = go.transform.position;
        this.oR = go.transform.eulerAngles;
        this.oN = oN;
    }

    public void setPropertiesToGameObject(GameObject go)
    {
        go.transform.position = oT;
        go.transform.eulerAngles = oR;
        go.name = oN;
    }

    //===========================================================================
	public Vector3 GetPos()             { return oT;}
    public void SetPos(Vector3 sP)      { oT=sP; }

    public string GetName()             { return oN; }
    public void SetName(string sN)      { oN = sN; }

}
	
[System.Serializable]
public struct oeObjWrapper{ public oeObjClass[] oeObjects; }

[System.Serializable]
public struct oeObjWrapperDict { public oeObjClass[] oeObjectsDict; }
