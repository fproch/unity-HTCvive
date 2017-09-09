namespace VRTK.Examples
{
    using UnityEngine;

    public class oeUzelGenerator : VRTK_InteractableObject
    {
        public float scale = 0.1f;
        public int number = 3;
        private GameObject[] oeChildren;

        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            base.StartUsing(usingObject);
            oeGenerate();
        }

        protected void Start()
        {
            Debug.Log("---------------------> oeUzelGenerator");
            oeChildren = new GameObject[number];
        }

        private void oeGenerate()
        {
            Vector3 spawnPosition = transform.position + transform.up * 2f * scale; //* 0.48f;
            if (number % 2 == 1)
                spawnPosition += transform.right * -scale * 2f * (number / 2 - 1);
            else
                spawnPosition += transform.right * -scale * 2f * number / 2;

            //if (oeChildren[0] == null)
                for (int i = 0; i < number; i++)
                {
                    //oeChildren[i] = new GameObject("ObjGen" + i.ToString());
                    Debug.Log("Newling created");

                    oeChildren[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    oeChildren[i].transform.position = spawnPosition;
                    oeChildren[i].transform.localScale = new Vector3(scale, scale, scale);
                    spawnPosition += new Vector3(scale * 2f, 0, 0);                   

                    ///////////oeChildren[i].transform.parent = transform;                   

                    oeChildren[i].AddComponent<VRTK.GrabAttachMechanics.VRTK_FixedJointGrabAttach>();
                    //oeChildren[i].AddComponent<VRTK.SecondaryControllerGrabActions.VRTK_SwapControllerGrabAction>();
                    oeChildren[i].AddComponent<oeUzel>();
                    oeChildren[i].AddComponent<Rigidbody>();
                    //oeChildren[i].AddComponent<oeNodelLine>();


                    oeChildren[i].name = ("New." + i.ToString());
                    oeChildren[i].GetComponent<oeUzel>().scale = 0.1f;
                    //oeChildren[i].GetComponent<oeUzel>().number = 5;
                    //oeChildren[i].GetComponent<oeUzel>().grabAttachMechanicScript = GameObject.Find("Uzel0-Gun").GetComponent<VRTK.GrabAttachMechanics.VRTK_FixedJointGrabAttach>();
                    //oeChildren[i].GetComponent<oeUzel>().secondaryGrabActionScript = GameObject.Find("Uzel0-Gun").GetComponent<VRTK.SecondaryControllerGrabActions.VRTK_SwapControllerGrabAction>();
                    oeChildren[i].GetComponent<oeUzel>().isGrabbable = true;
                    //oeChildren[i].GetComponent<oeUzel>().isUsable = true;
                    //oeChildren[i].GetComponent<oeUzel>().holdButtonToGrab = false;
                    //oeChildren[i].GetComponent<oeUzel>().holdButtonToUse = false;
                    //oeChildren[i].GetComponent<oeUzel>().useOnlyIfGrabbed = false;
                    oeChildren[i].GetComponent<Rigidbody>().useGravity = true;
                    oeChildren[i].GetComponent<Rigidbody>().isKinematic = false;
                    Debug.Log("Newling adjusted");
               }
                /*
            else
                Debug.Log("Already filled!");
                */
        }

    }
}