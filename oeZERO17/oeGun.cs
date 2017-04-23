namespace VRTK.Examples
{
    using UnityEngine;
    

    public class oeGun : VRTK_InteractableObject
    {    
       
      

        private int num = 0;
        public int indexData = 0;
        private bool stav = false;

        private GameObject bullet;
        public GameObject goA;
        public GameObject goB;
        private float bulletSpeed = 1000f;
        private float bulletLife = 5f;

        public bool debugLog = false;

        public override void StartUsing(GameObject usingObject)
        {
            base.StartUsing(usingObject);
            //FireBullet();
            SlerpTest();
        }

        protected void Start()
        {
            //bullet = transform.Find("Bullet").gameObject;
            //bullet.SetActive(false);
            //goA = GameObject.Find("hyperA");
            //goB = GameObject.Find("hyperB");
            goA.SetActive(stav);
            goB.SetActive(stav);
        }

      


        //----------------------------------

        private void SlerpTest()
        {
            //oeLabel
            if (debugLog) Debug.Log(num.ToString());
            gameObject.GetComponent<oeLabel>().labelTxt = num.ToString();
            num++;
            oeCommonDataContainer.setArrInt(indexData, num);
            oeCommonDataContainer.setArrInt(indexData+1, System.Convert.ToInt32(stav));
            stav = !stav;
            goA.SetActive(stav);
            goB.SetActive(stav);
           
          
            if (stav)
            {
                goA.GetComponent<oeSlerp>().move(false);
                //goB.GetComponent<oeSlerp>().move(true);
            }
          
            else
            {
                goA.GetComponent<oeSlerp>().initPos();
                //goB.GetComponent<oeSlerp>().initPos();
            }
        
         
               
            // if (stav) posun = true;


        }
       
        private void FireBullet()
        {           

           GameObject bulletClone = Instantiate(bullet, bullet.transform.position, bullet.transform.rotation) as GameObject;
            bulletClone.SetActive(true);
            Rigidbody rb = bulletClone.GetComponent<Rigidbody>();
            rb.AddForce(-bullet.transform.forward * bulletSpeed);
            Destroy(bulletClone, bulletLife);
        }
      
    }
}