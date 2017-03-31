using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oeHoneycomb : MonoBehaviour
{

    GameObject goL1;
    GameObject goL2;
    GameObject goL3;

    GameObject goLR;
    GameObject goLO;
    GameObject goLY;
    GameObject goLG;
    GameObject goLB;


    GameObject go1;
    GameObject go2;
    GameObject go3; //object_3 = main white

    TextMesh toStatus; //beeTextStatus
    TextMesh to1;
    Renderer rendHoney;
    public int indexHoney = 1;
    public bool colorLightsVisible = false;
    public bool mainCylinderVisible = false;
    public bool mainWhiteVisible = true;
    public Color upColor;

    // Use this for initialization
    void Start()
    {
        string parentName = transform.root.gameObject.name;

        //parent(gameobject)->child(gameobject)--->child(gameobject)
        //gameObject.transform.parent.gameObject.transform.parent.gameObject
        go1 = getChildGameObject(transform.root.gameObject, "object_1-cylinder");
        go2 = getChildGameObject(transform.root.gameObject, "object_2-whitebox");
        go3 = getChildGameObject(transform.root.gameObject, "object_3");
        if (!mainCylinderVisible) go1.active = false;
        if (!mainWhiteVisible) go2.active = false;

        goLR = getChildGameObject(transform.root.gameObject, "object_LEDR");
        goLO = getChildGameObject(transform.root.gameObject, "object_LEDO");
        goLY = getChildGameObject(transform.root.gameObject, "object_LEDY");
        goLG = getChildGameObject(transform.root.gameObject, "object_LEDG");
        goLB = getChildGameObject(transform.root.gameObject, "object_LEDB");

        if (!colorLightsVisible) {
            goLR.active = false;
            goLO.active = false;
            goLY.active = false;
            goLG.active = false;
            goLB.active = false;            
        }


        Debug.Log("--- oeHoneycomb --- " + parentName);
        //go1 = GameObject.Find("object_1up"); //ok - only first       
        //go1 = transform.Find(parentName + "/object_1up").gameObject; //null
        goL1 = getChildGameObject(transform.root.gameObject, "object_L1");
       

        toStatus = getChildGameObject(transform.root.gameObject, "beeTextStatus").GetComponent<TextMesh>();
        toStatus.text = "beeTextStatus: "+ parentName + " index: "+ indexHoney;
        //to1 = GameObject.Find("text0").GetComponent<TextMesh>();
        rendHoney = goL1.GetComponent<Renderer>();
        rendHoney.material.color = upColor; //Color.green;

       
        

    }

    // Update is called once per frame
    void Update()
    {

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
