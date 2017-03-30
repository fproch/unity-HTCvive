using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oeHoneycomb : MonoBehaviour {

    GameObject go1;
    GameObject go2;
    GameObject go3; //object_3 = main white

    TextMesh to1;
    Renderer rendHoney;
    public int indexHoney = 1;
    public bool mainWhiteVisible = true;
    public Color upColor;

    // Use this for initialization
    void Start () {
        string parentName = transform.root.gameObject.name;

        //parent(gameobject)->child(gameobject)--->child(gameobject)
        //gameObject.transform.parent.gameObject.transform.parent.gameObject

        Debug.Log("--- oeHoneycomb --- "+ parentName);
        //go1 = GameObject.Find("object_1up"); //ok - only first       
        //go1 = transform.Find(parentName + "/object_1up").gameObject; //null
        go1 = getChildGameObject(transform.root.gameObject, "object_1up");

        //to1 = GameObject.Find("text0").GetComponent<TextMesh>();
        rendHoney = go1.GetComponent<Renderer>();
        rendHoney.material.color = upColor; //Color.green;

        go3 = getChildGameObject(transform.root.gameObject, "object_3");
        if (!mainWhiteVisible) go3.active = false;


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    static public GameObject getChildGameObject(GameObject fromGameObject, string withName)
    {
        //How to find a Child Gameobject by name?
        //Transform[] ts = fromGameObject.transform.GetComponentsInChildren();
        Transform[] ts = fromGameObject.transform.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in ts) if (t.gameObject.name == withName) return t.gameObject;
        return null;
    }


}
