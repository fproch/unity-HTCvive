using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class oeSceneSelect : MonoBehaviour
{

    GameObject goCudl1;

    TextMesh textObject1;
    TextMesh textObject2A;
    TextMesh textObject2B;
    public string selObj = "nic";

    // Use this for initialization
    void Start()
    {
        Debug.Log("oeSceneSelector.Start()");
        //goCudl1 = GameObject.Find("cudl1");
        ///textObject = GameObject.Find("label2").GetComponent<TextMesh>();
        textObject1 = GameObject.Find("textINFO1A").GetComponent<TextMesh>();
        textObject2A = GameObject.Find("textINFO2A").GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //============================================================================================================
    void OnCollisionEnter(Collision colSel)
    {
        //Debug.Log();
        //if (col.gameObject.name == "prop_powerCube")        {            Destroy(col.gameObject);        }
        //https://unity3d.com/learn/tutorials/topics/physics/detecting-collisions-oncollisionenter
        //rigid body
        selObj = colSel.collider.name;
        Debug.Log("sceneSelector: " + selObj);
        ///textObject.text = selObj;
        ///textObject2A.text = "sceneSelector: " + selObj;
        //Debug.Log();

        if (selObj == "sel1") SceneManager.LoadScene("matoPeklo");
        if (selObj == "sel2") SceneManager.LoadScene("oePracovna");
        if (selObj == "sel4") SceneManager.LoadScene("oeData");
        if (selObj == "sel3") SceneManager.LoadScene("oeGal1");
        if (selObj == "sel5") SceneManager.LoadScene("oeHerna");
    }
    //============================================================================================================   
}
