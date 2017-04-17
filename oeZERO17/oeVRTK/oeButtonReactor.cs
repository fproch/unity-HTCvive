namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEventHelper;

    public class oeButtonReactor : MonoBehaviour
    {
        public int indexData = 0;
        public GameObject go;
        public Transform dispenseLocation;
        public bool debugLog = false;
        bool stav = false;
        Light oeLight1;
        GameObject oeAudio1;

        public bool MainLihgt = false;
        public bool MainSound = false;
        public bool MainTest = false;

        //---test
        private Renderer rend;
        int cnt = 0;
        public bool sourcePositionIsController = false;
        public bool asAParent = true;
        public bool useGravity = false;
        public float oeMass = 1f;
        public bool cubeYesSphereNo = true;
        public GameObject goCon0;
        public GameObject goCon;
        public string nameObj = "oeTrig";
        public float scale = 0.15f;



        private VRTK_Button_UnityEvents buttonEvents;

        private void Start()
        {
            // test
            if (MainLihgt) oeLight1 = GameObject.Find("oeLight1").GetComponent<Light>();
            if (MainSound) oeAudio1 = GameObject.Find("oeAudio");

            buttonEvents = GetComponent<VRTK_Button_UnityEvents>();
            if (buttonEvents == null)
            {
                buttonEvents = gameObject.AddComponent<VRTK_Button_UnityEvents>();
            }
            buttonEvents.OnPushed.AddListener(handlePush);
        }

        private void handlePush(object sender, Control3DEventArgs e)
        {
            VRTK_Logger.Info("Pushed");
            //akce:
            //GameObject newGo = (GameObject)Instantiate(go, dispenseLocation.position, Quaternion.identity);
            //Destroy(newGo, 10f);
            stav = !stav;
            if (debugLog) Debug.Log("--- oeButtonReactor "+indexData + ": "+stav);
            if (MainLihgt) oeLight1.enabled = !oeLight1.enabled;
            if (MainSound) oeAudio1.active = stav;
            if (MainTest) oeGenerateObject();
            

        }

        private void oeGenerateObject()
        {
            cnt++;
            int oeData0 = oeCommonDataContainer.getArrInt(indexData)+1;
            if (debugLog) Debug.Log("--- oeButtonReactor " + oeData0);

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

            go.name = nameObj + "." + cnt;
            Debug.Log(go.name);

            if (sourcePositionIsController)
            {
                go.transform.position = goCon0.transform.position;
                go.transform.eulerAngles = goCon0.transform.eulerAngles;
                //go.transform.localScale = new Vector3(scale/ oeData0, scale/ oeData0, scale/ oeData0);
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
                    //go.transform.localScale = new Vector3(scale / oeData0, scale / oeData0, scale / oeData0);

                }
            }

            go.transform.localScale = new Vector3(scale * oeData0, scale * oeData0, scale * oeData0);




            ///go.transform.SetParent(goCon.transform); //x spojené s parent
            //go.transform.position = trans.position; //x fixní

            rend = go.GetComponent<Renderer>();

            //goRobot1.GetComponent<Spinner>().spinLeft();
            //gameObject.light.enabled = true;
            //text3D.text = "test";  


        }



    }
}