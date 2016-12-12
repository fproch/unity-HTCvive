using UnityEngine;
using System.Collections;

public class oeMain : MonoBehaviour {
    
    GameObject goCube1;
    //goCube1 = GameObject.Find("Cube");

    public Material[] materials;
    public Renderer rend;
    public Renderer rend1;
    public Renderer rend2;
    // Assigns a material named "Assets/Resources/DEV_Orange" to the object.
    //Material matSil = Resources.Load("oeSilver", typeof(Material)) as Material; //load nejde
    //Material matOra = Resources.Load("oeOra", typeof(Material)) as Material;
    //Material matRed = Resources.Load("oeRed", typeof(Material)) as Material;
    //gameObject.renderer.material = newMat;


    public GameObject[] cubeArr;
    public GameObject[] cubeMatrix1;
    public GameObject[] cubeMatrix2;

    public GameObject[][] cubeMatrix;
    int numCube = 10;
    int ii = 0;


    private void TestCreateCubes()
    {
        // public GameObject[] cubeArr;
        cubeArr = new GameObject[numCube];
        for (int c = 0; c < numCube; c++)
        {
            //Instantiate(MyObjects[3]); // instantiates 4th object
            cubeArr[c] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            float deltaRnd = Mathf.Floor(Random.Range(0, 10));
            cubeArr[c].transform.position = new Vector3(c, 0.5F+ deltaRnd/10, 5 - c / 2);
            cubeArr[c].transform.localScale = new Vector3(0.5F, 0.5F, 0.5F);

            //GameObject go = GameObject.CreatePrimitive(PrimitiveType.Plane);



            rend = cubeArr[c].GetComponent<Renderer>();
            if (c % 2 == 0)
            {
                //cubeArr[c].active = false; 
                //cubeArr[c].renderer.material = matRed;
                //cubeArr[c].renderer.materials[0].color = defaultColor;


                //rend.material.mainTexture = Resources.Load("oeRed.mat") as Texture;
                //rend.material = Resources.Load("oeRed") as Material;
                rend.material.color = Color.red;
            }
            else
            {
                //rend.material = Resources.Load("Blue") as Material;
            }


        }
    }


    private void TestCreateMatrix1()
    {
        // public GameObject[] cubeArr;
        int Matrix1x = 10;
        int Matrix1z = 2;
        cubeMatrix1 = new GameObject[numCube * numCube];
        for (int i = 0; i < numCube; i++)
        {
            for (int j = 0; j < numCube; j++)
            {

                cubeMatrix1[i* numCube + j] = (GameObject)Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube), new Vector2(i+ Matrix1x, j+ Matrix1z), Quaternion.identity);
                cubeMatrix1[i * numCube + j].transform.localScale = new Vector3(0.8F, 0.5F, 0.8F);

                rend1 = cubeMatrix1[i * numCube + j].GetComponent<Renderer>();
                float deltaRnd1 = Mathf.Floor(Random.Range(0, 10));
                if (deltaRnd1==1) rend1.material.color = Color.red;
                if (deltaRnd1 == 2) rend1.material.color = Color.blue;
                if (deltaRnd1 == 3) rend1.material.color = Color.black;


            }

        }
    }


    private void TestCreateMatrix2()
    {
        // public GameObject[] cubeArr;
        int Matrix2x = 20;
        int Matrix2z = -25;
        cubeMatrix2 = new GameObject[numCube * numCube];
        for (int i = 0; i < numCube; i++)
        {
            for (int j = 0; j < numCube; j++)
            {

                cubeMatrix2[i * numCube + j] = (GameObject)Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube), new Vector3(i + Matrix2x, -5, j + Matrix2z), Quaternion.identity);
                cubeMatrix2[i * numCube + j].transform.localScale = new Vector3(0.8F, 0.5F, 0.8F);

                rend2 = cubeMatrix2[i * numCube + j].GetComponent<Renderer>();
                float deltaRnd2 = Mathf.Floor(Random.Range(0, 10));
                if (deltaRnd2 == 1) rend2.material.color = Color.red;
                //if (deltaRnd1 == 2) rend1.material.color = Color.blue;
                if (deltaRnd2 == 3) rend2.material.color = Color.black;
            }
        }
    }

    private void TestCreateMatrix()
    {
        // public GameObject[] cubeArr;
        int mm = 6;
        cubeMatrix = new GameObject[mm][]; //only rows?
        for (int i = 0; i < mm; i++)
        {
            for (int j = 0; j < mm; j++)
            {
                Debug.Log(i.ToString() + "/"+j.ToString());
                //Instantiate(MyObjects[3]); // instantiates 4th object
                cubeMatrix[i][j] = (GameObject)Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube), new Vector2(i, j), Quaternion.identity);

                //cubeMatrix[i][j] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cubeMatrix[i][j].transform.position = new Vector3(i, 0.5F, 5 - j / 2);
                //cubeMatrix[i][j].transform.localScale = new Vector3(0.5F, 0.5F, 0.5F);
            }            
        }
    }   

//---------------------------------------------------------------------------------------------------------------
    // Use this for initialization
    void Start () {
        //rend = GetComponent<Renderer>();
        //rend.enabled = true;

        goCube1 = GameObject.Find("Cube");
        //goCube1.renderer.material = matRed;

        TestCreateCubes();
        //TestCreateMatrix();
        TestCreateMatrix1();
        TestCreateMatrix2();
    }
	
	// Update is called once per frame
	void Update () {
        if (ii > numCube* numCube-1) ii = 0; 
        
        float deltaRnd = Mathf.Floor(Random.Range(0, 10));

        cubeMatrix2[ii].transform.localScale = new Vector3(0.8F, (10/(deltaRnd + 1))/10, 0.8F);

        rend1 = cubeMatrix1[ii].GetComponent<Renderer>();
        if (Mathf.Floor(Random.Range(0, 10)) == 1) cubeMatrix1[ii].GetComponent<Renderer>().material.color = Color.red;
        if (deltaRnd == 2) rend1.material.color = Color.black;
        ii++;
        

    }
}
