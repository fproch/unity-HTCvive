
namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class oeVRTK8select : VRTK_InteractableObject
    {

        private int num = 0;
        public int indexData = 0;
        private bool stav = false;

        //private GameObject bullet;
        //public GameObject goA;
        //public GameObject goB;
        //private float bulletSpeed = 1000f;
        //private float bulletLife = 5f;

        //public bool slerp = true;
        //public bool scale = false;

        GameObject go0;
        GameObject go1;
        GameObject go2;
        GameObject go3; //object_3 = main white
        GameObject go4;
        GameObject go5;
        GameObject go6;
        GameObject go7;
        GameObject goHO1;

        public GameObject g1;
        public GameObject g2;
        public GameObject g3;

        TextMesh toStatus; //beeTextStatus
        TextMesh to1;
        Renderer rendHoney;
        public int index8selector = 1;
        public bool arrVisible = false;

        public Color upColor;

        [Tooltip("For debuging or testing")]
        public bool debugLog = false;

        public override void StartUsing(GameObject usingObject)
        {
            base.StartUsing(usingObject);
            //FireBullet();
           SelectNext();
        }

        protected void Start()
        {
            string parentName = transform.root.gameObject.name;
            if (debugLog) Debug.Log("-------------------- oeVRTK8select --- " + parentName);

            //parent(gameobject)->child(gameobject)--->child(gameobject)
            //gameObject.transform.parent.gameObject.transform.parent.gameObject
            go0 = getChildGameObject(transform.root.gameObject, "s0");
            go1 = getChildGameObject(transform.root.gameObject, "s1");
            go2 = getChildGameObject(transform.root.gameObject, "s2");
            go3 = getChildGameObject(transform.root.gameObject, "s3");
            go4 = getChildGameObject(transform.root.gameObject, "s4");
            go5 = getChildGameObject(transform.root.gameObject, "s5");
            go6 = getChildGameObject(transform.root.gameObject, "s6");
            go7 = getChildGameObject(transform.root.gameObject, "s7");
            goHO1 = getChildGameObject(transform.root.gameObject, "7skruze1");

            if (!arrVisible)
            {
                setAllInactive();
            }



            //bullet = transform.Find("Bullet").gameObject;
            //bullet.SetActive(false);
            //goA = GameObject.Find("hyperA");
            //goB = GameObject.Find("hyperB");
            //goA.SetActive(stav);
            //goB.SetActive(stav);
        }

        //----------------------------------

        private void setAllInactive()
        {
            go0.SetActive(false);
            go1.SetActive(false);
            go2.SetActive(false);
            go3.SetActive(false);
            go4.SetActive(false);
            go5.SetActive(false);
            go6.SetActive(false);
            go7.SetActive(false);

            g1.SetActive(false);
            g2.SetActive(false);
            g3.SetActive(false);
        }


        private void SelectNext()
        {
            //oeLabel
            if (debugLog) Debug.Log(num.ToString());
            gameObject.GetComponent<oeLabel>().labelTxt = " > "+ num.ToString();

            num++;
            if (num == 8) num = 0;

            oeCommonDataContainer.setArrInt(indexData, num);

            setAllInactive();
            goHO1.transform.localScale = new Vector3(0.5f*num, 0.5f * num,0.5f * num);

            switch (num)
            {
                case 0:
                    go0.SetActive(true);
                    break;
                case 1:
                    go1.SetActive(true);
                    g1.SetActive(true);
                    break;
                case 2:
                    go2.SetActive(true);
                    g2.SetActive(true);
                    break;
                case 3:
                    go3.SetActive(true);
                    g3.SetActive(true);
                    break;
                case 4:
                    go4.SetActive(true);
                    break;
                case 5:
                    go5.SetActive(true);
                    break;
                case 6:
                    go6.SetActive(true);
                    break;
                case 7:
                    go7.SetActive(true);
                    g1.SetActive(true);
                    g2.SetActive(true);
                    g3.SetActive(true);
                    break;

                default:
                    //go0.SetActive(true);
                    break;
            }






            //oeCommonDataContainer.setArrInt(indexData + 1, System.Convert.ToInt32(stav));
            //stav = !stav;

            //goA.GetComponent<oeSlerp>().useObject(slerp, scale, 0);
            //goB.GetComponent<oeSlerp>().useObject(slerp, scale, 1);

            // if (stav) posun = true;
        }

        /*private void FireBullet()
        {
            GameObject bulletClone = Instantiate(bullet, bullet.transform.position, bullet.transform.rotation) as GameObject;
            bulletClone.SetActive(true);
            Rigidbody rb = bulletClone.GetComponent<Rigidbody>();
            rb.AddForce(-bullet.transform.forward * bulletSpeed);
            Destroy(bulletClone, bulletLife);
        }
        */

        static public GameObject getChildGameObject(GameObject fromGameObject, string withName)
        {
            //How to find a Child Gameobject by name?
            //Transform[] ts = fromGameObject.transform.GetComponentsInChildren();
            Transform[] ts = fromGameObject.transform.GetComponentsInChildren<Transform>(true);
            foreach (Transform t in ts) if (t.gameObject.name == withName) return t.gameObject;
            return null;
        }
    }
}






