namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEventHelper;

    public enum TR //type reactor
    { noneR, lightR, soundR, generatorR, toolsR, leftR, rightR }

    public enum TF //type fysic
    { kinematic, gravity, random }

    public class oeButtonReactor : MonoBehaviour
    {
        public int indexData = 0;       

        public TR typeReactor;

        public GameObject go;
        public GameObject goBum;
        public Transform dispenseLocation;

        public GameObject myLed;

        public bool debugLog = false;
        bool stav = false;
        Light oeLight1;
        GameObject oeAudio1;
        AudioClip audiosource;
        GameObject oeTools;
        GameObject oeToolsL;
        GameObject oeToolsR;

        //---test
        private Renderer rend;
        int cnt = 0;
        public bool sourcePositionIsController = false;
        public bool asAParent = true;
        public bool useGravity = false;
        public bool useKinematic = false;
        public float oeMass = 1f;
        public bool cubeYesSphereNo = true;

        public TF typeFyz;
        public bool addNoise = true;
        public float numRandom = 10; 

        public GameObject goCon0;
        public GameObject goCon;
        public string nameObj = "oeTrig";
        public float scale = 0.15f;



        private VRTK_Button_UnityEvents buttonEvents;

        private void Start()
        {
            // test
            goBum = GameObject.Find("oeBum");
            if (typeReactor == TR.lightR) { stav = true; oeLight1 = GameObject.Find("oeLight1").GetComponent<Light>(); }
            if (typeReactor == TR.soundR) { stav = true; oeAudio1 = GameObject.Find("oeAudio"); }
            //if (typeReactor == TR.toolsR) oeTools = GameObject.Find("oeTools");
            oeTools = GameObject.Find("oeTools"); //oeTools.SetActive(false);
            oeToolsL = GameObject.Find("oeToolsL"); // oeToolsL.SetActive(false);
            oeToolsR = GameObject.Find("oeToolsR"); //oeToolsR.SetActive(false);


            myLed.SetActive(stav);

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

            switch (typeReactor)
            {
                case TR.noneR:
                                       break;

                case TR.lightR:
                    oeLight1.enabled = !oeLight1.enabled;
                    myLed.SetActive(oeLight1.enabled);
                    break;

                case TR.soundR:
                    oeAudio1.SetActive(stav);
                    myLed.SetActive(stav);
                    break;

                case TR.toolsR:
                    oeTools.SetActive(stav);
                    myLed.SetActive(stav);
                    break;

                case TR.leftR:
                    oeToolsL.SetActive(stav);
                    myLed.SetActive(stav);
                    break;

                case TR.rightR:
                    oeToolsR.SetActive(stav);
                    myLed.SetActive(stav);
                    break;

                case TR.generatorR:
                    oeGenerateObject();
                    break;


                default:
                    Debug.Log("err reactor Type");
                    break;
            }








            if (debugLog) Debug.Log("--- oeButtonReactor " + indexData + ": " + stav);
       
           
          
            

        }

        private void oeGenerateObject()
        {
            goBum.SetActive(false); // sound1.ok
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

            //audiosource = go.AddComponent<AudioSource>(); x
            //go.GetComponent<AudioSource>. = Resources.Load("idle_power_fist_1"); x
           
            goBum.SetActive(true); ///sound1.ok 
            goBum.GetComponent<AudioSource>().volume = (float)oeData0/100;
            ///AudioSource.PlayClipAtPoint("idle_power_fist_1") x

            Rigidbody gameObjectsRigidBody = go.AddComponent<Rigidbody>(); // Add the rigidbody.
            gameObjectsRigidBody.mass = oeMass; // Set the GO's mass to 5 via the Rigidbod

            switch (typeFyz)
            {
                case TF.gravity:
                    go.GetComponent<Rigidbody>().useGravity = true;
                    go.GetComponent<Rigidbody>().isKinematic = false;
                    break;

                case TF.kinematic:
                    go.GetComponent<Rigidbody>().useGravity = false;
                    go.GetComponent<Rigidbody>().isKinematic = false;
                    break;

                case TF.random:
                    go.GetComponent<Rigidbody>().useGravity = stav;
                    go.GetComponent<Rigidbody>().isKinematic = false;
                   break;
                
                default:
                    Debug.Log("err fyz Type");
                    break;
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


            if (addNoise)
            {
                float deltaRnd1 = Mathf.Floor(Random.Range(0, numRandom))/100;
                float deltaRnd2 = Mathf.Floor(Random.Range(0, numRandom))/100;
                float deltaRnd3 = Mathf.Floor(Random.Range(0, numRandom))/100;
                go.transform.position = go.transform.position + new Vector3(deltaRnd1, deltaRnd2, deltaRnd3);
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