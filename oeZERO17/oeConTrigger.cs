using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//-------------------------------------------------------------------------------------------------
//     octopusengine.org - oeConTrigger.cs
//-------------------------------------------------------------------------------------------------
// add this ccript to: [CameraRig]/Controller (left)
//
//
//
// 2017/02
//-------------------------------------------------------------------------------------------------


public class oeConTrigger : MonoBehaviour
{
    public bool sourcePositionIsController = false;
    public bool asAParent = true;
    public bool useGravity = false;
    public float oeMass = 1f;
    public bool cubeYesSphereNo = true;
    public GameObject goCon0;
    public GameObject goCon;
    public string nameObj = "oeTrig";
    public float scale = 0.15f;

    //---------------------------------------------------------------------------------------------
    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;
    private Renderer rend;
    int cnt = 0;
    private GameObject pickup;
    private Transform trans;
    private GameObject go;

    //private GameObject pickup;

    void Start()
    {
        Debug.Log("oeConTrigger.start()");
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        goCon0 = GameObject.Find("Controller (left)");
        cnt = 0;
       

    }

    // Update is called once per frame
    void Update()
    {
        ///trans = goCon.transform;
        if (controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }

        //--------------------------test------------------------------------
        if (controller.GetPressDown(triggerButton))
        {
            //Debug.Log("Controller GetPressDown(triggerButton) True");
            //Debug.Log("cnt: " + cnt.ToString());
            cnt++;

            //Debug.Log(goCon.transform.ToString());
            if (cubeYesSphereNo)
            {
                 go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            }
            else
            {
                 go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            }

            if (useGravity)
            {
                //pickup.transform.parent = this.transform;
                Rigidbody gameObjectsRigidBody = go.AddComponent<Rigidbody>(); // Add the rigidbody.
                gameObjectsRigidBody.mass = oeMass; // Set the GO's mass to 5 via the Rigidbod
                go.GetComponent<Rigidbody>().useGravity = true;
            }

            go.name = nameObj+"." + cnt;
            Debug.Log(go.name);

            if (sourcePositionIsController)
            {
                go.transform.position = goCon0.transform.position;
                go.transform.eulerAngles = goCon0.transform.eulerAngles;
                go.transform.localScale = new Vector3(scale, scale, scale);
            }
            else
            {
                if (asAParent)
                {
                    go.transform.position = goCon0.transform.position;
                    go.transform.eulerAngles = goCon0.transform.eulerAngles;
                    go.transform.SetParent(goCon.transform);
                    //go.transform.eulerAngles = goCon.transform.eulerAngles;
                }
                else
                {
                    go.transform.position = goCon.transform.position;
                    go.transform.eulerAngles = goCon.transform.eulerAngles;
                    go.transform.localScale = new Vector3(scale, scale, scale);
                }
            }

           


            ///go.transform.SetParent(goCon.transform); //x spojené s parent
            //go.transform.position = trans.position; //x fixní
           
            rend = go.GetComponent<Renderer>();

            //goRobot1.GetComponent<Spinner>().spinLeft();
            //gameObject.light.enabled = true;
            //text3D.text = "test";          

        }

        if (controller.GetPressDown(gripButton))
        {
           
        }

        //--------------------------/test-----------------------------------

        if (controller.GetPressDown(gripButton) && pickup != null)
        {
            Debug.Log("Controller GetPressDown(gripButton)");
            pickup.transform.parent = this.transform;
            pickup.GetComponent<Rigidbody>().useGravity = false;
        }
        if (controller.GetPressUp(gripButton) && pickup != null)
        {
            Debug.Log("Controller GetPressUp(gripButton)");
            pickup.transform.parent = null;
            pickup.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Controller OnTriggerEnter");
        pickup = collider.gameObject;
    }

    private void OnTriggerExit(Collider collider)
    {
        Debug.Log("Controller OnTriggerExit");
        pickup = null;
    }



}

