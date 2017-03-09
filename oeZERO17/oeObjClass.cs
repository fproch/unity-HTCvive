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
    private string oName;
	public Vector3 oT;
	public Vector3 oR;
    //private int oValue;
    //private string oNote;

    public oeObjClass(GameObject go, int index)
    {
        this.index = index;
        oT = go.transform.position;
        oR = go.transform.eulerAngles;
        oName = go.name;
    }

    public void setPropertiesToGameObject(GameObject go)
    {
        go.transform.position = oT;
        go.transform.eulerAngles = oR;
        //go.name = oName;
    }

    //===========================================================================
	public Vector3 GetPos()             { return oT;}
    public void SetPos(Vector3 sP)      { oT=sP; }

    public string GetName()             { return oName; }
    public void SetName(string sN)      { oName = sN; }

}
	
[System.Serializable]
public struct oeObjWrapper{ public oeObjClass[] oeObjects; }
