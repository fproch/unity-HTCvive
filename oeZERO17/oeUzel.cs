namespace VRTK.Examples
{
    using UnityEngine;

    public class oeUzel : VRTK_InteractableObject
    {
        public float scale = 0.1f;
        public int quantity = 0;
        public int childrenCreated = 0;
        private GameObject[] oeChildren;
        private Vector3 spawnPosition;

        [Tooltip("For debuging or testing")]
        public bool debugList = false;


        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            base.StartUsing(usingObject);
            //oeCreateChildren();
        }

        /*
        protected void Start()
        {

        }*/

        /*
        public virtual void Ungrabbed(VRTK_InteractGrab previousGrabbingObject = null)
        {

        }
        */
        /*
        public void oeCreateChildren()
        {
            oeChildren = new GameObject[number];
            Vector3 spawnPosition = transform.position + transform.up * 2f * scale; //* 0.48f;
            if (number % 2 == 1)
                spawnPosition += transform.right * -scale * 2f * (number / 2 - 1);
            else
                spawnPosition += transform.right * -scale * 2f * number / 2;

            if (oeChildren[0] == null)
                for (int i = 0; i < number; i++)
                {
                    ///oeChildren[i] = new GameObject("Main" + i.ToString());
                    Debug.Log("Newling created");

                    oeChildren[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    oeChildren[i].transform.position = spawnPosition;
                    oeChildren[i].transform.localScale = new Vector3(scale, scale, scale);
                    spawnPosition += new Vector3(scale * 2f, 0, 0);
                    Debug.Log("Newling positioned");

                    oeChildren[i].transform.parent = transform;
                    Debug.Log("Parent set");

                    //oeChildren[i].AddComponent<VRTK.GrabAttachMechanics.VRTK_FixedJointGrabAttach>();
                    //oeChildren[i].AddComponent<VRTK.SecondaryControllerGrabActions.VRTK_SwapControllerGrabAction>();
                    oeChildren[i].AddComponent<oeUzel>();
                    oeChildren[i].AddComponent<Rigidbody>();
                    oeChildren[i].AddComponent<oeNodelLine>();


                    oeChildren[i].SetActive(true);
                    oeChildren[i].name = (gameObject.name + "." + i.ToString());
                    //oeChildren[i].GetComponent<oeUzel>().scale = 0.1f;
                    oeChildren[i].GetComponent<oeUzel>().enabled = true;
                    oeChildren[i].GetComponent<oeUzel>().disableWhenIdle = false;
                    oeChildren[i].GetComponent<oeUzel>().number = 5;
                    oeChildren[i].GetComponent<oeUzel>().grabAttachMechanicScript = GameObject.Find("Uzel0-Gun").GetComponent<VRTK.GrabAttachMechanics.VRTK_FixedJointGrabAttach>();
                    oeChildren[i].GetComponent<oeUzel>().secondaryGrabActionScript = GameObject.Find("Uzel0-Gun").GetComponent<VRTK.SecondaryControllerGrabActions.VRTK_SwapControllerGrabAction>();
                    oeChildren[i].GetComponent<oeUzel>().isGrabbable = true;
                    oeChildren[i].GetComponent<oeUzel>().isUsable = true;
                    oeChildren[i].GetComponent<oeUzel>().holdButtonToGrab = false;
                    oeChildren[i].GetComponent<oeUzel>().holdButtonToUse = false;
                    oeChildren[i].GetComponent<oeUzel>().useOnlyIfGrabbed = false;
                    oeChildren[i].GetComponent<Rigidbody>().useGravity = false;
                    oeChildren[i].GetComponent<Rigidbody>().isKinematic = false;
                    oeChildren[i].GetComponent<Rigidbody>().drag = 15f;
                    oeChildren[i].GetComponent<Rigidbody>().angularDrag = 15f;
                    Debug.Log("Newling adjusted");
                }
            else
                Debug.Log("Already filled!");
        }
        */

        public void oeInitChildren()
        {
            oeChildren = new GameObject[quantity];

            spawnPosition = transform.position + transform.up * 3f * scale; //* 0.48f;
            if (quantity % 2 == 1)
                spawnPosition += transform.right * -scale * 3f * ((quantity-1) / 2);
            else
                spawnPosition += transform.right * -scale * 3f * (quantity / 2);
        }

        public void oeCreateChild(string name, int childrenQuantity)
        {
            if (childrenCreated < quantity)
            {
                oeChildren[childrenCreated] = GameObject.CreatePrimitive(PrimitiveType.Cube);

                if (debugList)
                    Debug.Log(name + ": Created");

                oeChildren[childrenCreated].transform.position = spawnPosition;
                oeChildren[childrenCreated].transform.localScale = new Vector3(scale, scale, scale);
                spawnPosition += new Vector3(scale * 3f, 0, 0);
                if (debugList)
                    Debug.Log(name + ": Positioned");

                oeChildren[childrenCreated].transform.parent = transform;
                if (debugList)
                    Debug.Log(name + ": Parent set");

                oeChildren[childrenCreated].AddComponent<oeUzel>();
                oeChildren[childrenCreated].AddComponent<oeLabel>();
                oeChildren[childrenCreated].AddComponent<Rigidbody>();
                oeChildren[childrenCreated].AddComponent<oeNodelLine>();
                if (debugList)
                    Debug.Log(name + ": Components added");

                oeChildren[childrenCreated].SetActive(true);
                if (debugList)
                    Debug.Log("name should be: " + name);
                oeChildren[childrenCreated].name = name;
                oeChildren[childrenCreated].GetComponent<oeUzel>().enabled = true;
                oeChildren[childrenCreated].GetComponent<oeUzel>().disableWhenIdle = false;
                oeChildren[childrenCreated].GetComponent<oeUzel>().quantity = childrenQuantity;
                oeChildren[childrenCreated].GetComponent<oeUzel>().grabAttachMechanicScript = GameObject.Find("UzelStrom").GetComponent<VRTK.GrabAttachMechanics.VRTK_FixedJointGrabAttach>();
                oeChildren[childrenCreated].GetComponent<oeUzel>().secondaryGrabActionScript = GameObject.Find("UzelStrom").GetComponent<VRTK.SecondaryControllerGrabActions.VRTK_SwapControllerGrabAction>();
                oeChildren[childrenCreated].GetComponent<oeUzel>().isGrabbable = true;
                oeChildren[childrenCreated].GetComponent<oeUzel>().isUsable = true;
                oeChildren[childrenCreated].GetComponent<oeUzel>().holdButtonToGrab = false;
                oeChildren[childrenCreated].GetComponent<oeUzel>().holdButtonToUse = false;
                oeChildren[childrenCreated].GetComponent<oeUzel>().useOnlyIfGrabbed = false;
                //oeChildren[childrenCreated].GetComponent<oeLabel>().labelTxt = gameObject.name;

                oeChildren[childrenCreated].GetComponent<oeUzel>().scale = scale * 0.7f;
                oeChildren[childrenCreated].GetComponent<oeUzel>().debugList = true;

                oeChildren[childrenCreated].GetComponent<oeLabel>().labelObjName1 = true;
                oeChildren[childrenCreated].GetComponent<oeLabel>().startTransform = oeChildren[childrenCreated].transform;
                oeChildren[childrenCreated].GetComponent<Rigidbody>().useGravity = false;
                oeChildren[childrenCreated].GetComponent<Rigidbody>().isKinematic = false;
                oeChildren[childrenCreated].GetComponent<Rigidbody>().drag = 15f;
                oeChildren[childrenCreated].GetComponent<Rigidbody>().angularDrag = 15f;
                if (debugList)
                    Debug.Log(name + ": Adjusted");

                childrenCreated++;
            }
            else
                Debug.Log(gameObject.name + " is already filled!");
        }

        /*
        private void oeNullDrag(bool gripped)
        {
            foreach (GameObject child in oeChildren)
            {
                oeNullDrag(gripped);

                if(gripped)
                {
                    child.GetComponent<Rigidbody>().drag = 0f;
                    child.GetComponent<Rigidbody>().angularDrag = 0f;
                }
                else
                {
                    child.GetComponent<Rigidbody>().drag = 15f;
                    child.GetComponent<Rigidbody>().angularDrag = 15f;
                }
            }
        }*/
    }  
}