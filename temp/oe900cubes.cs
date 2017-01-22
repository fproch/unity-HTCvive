using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oe900cubes : MonoBehaviour {
    //public GameObject[] cubeArr;
    //public GameObject[] cubeMatrix1; //vertikalni
    public GameObject[] cubeMatrix2; //horizontalni
    int numCube = 30;
    int ii = 0;

    //public Renderer rend1;
    public Renderer rend2;
    public Vector3 startMatrix = new Vector3(-20, 0, -20);  //pocatek vykresleni matice

    //==================================================================================
    void Start () {
        Debug.Log("---> oe900cubes.start() > TestCreateMatrix2");
        TestCreateMatrix2();
        //TestCreateMatrix1();

    }
	
	// Update is called once per frame
	void Update () {
        /*
         * if (ii > numCube * numCube - 1) ii = 0;
        float deltaRnd = Mathf.Floor(Random.Range(0, 10));
        cubeMatrix2[ii].transform.localScale = new Vector3(0.8F, (10 / (deltaRnd + 1)) / 10, 0.8F);
        rend1 = cubeMatrix1[ii].GetComponent<Renderer>();
        if (Mathf.Floor(Random.Range(0, 10)) == 1) cubeMatrix1[ii].GetComponent<Renderer>().material.color = Color.red;
        if (deltaRnd == 2) rend1.material.color = Color.black;
        ii++;
        */
    }

    private void TestCreateMatrix2()
    {
        // public GameObject[] cubeArr;
        //int Matrix2x = -20;
        //int Matrix2y = 0;
        //int Matrix2z = -20;
        cubeMatrix2 = new GameObject[numCube * numCube];
        for (int i = 0; i < numCube; i++)
        {
            for (int j = 0; j < numCube; j++)
            {

                cubeMatrix2[i * numCube + j] = (GameObject)Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube),  new Vector3(startMatrix.x + i, startMatrix.y, startMatrix.z+j), Quaternion.identity);
                cubeMatrix2[i * numCube + j].transform.localScale = new Vector3(0.95F, 1F, 0.95F);

                rend2 = cubeMatrix2[i * numCube + j].GetComponent<Renderer>();
                float deltaRnd2 = Mathf.Floor(Random.Range(0, 20));
                if (deltaRnd2 == 1) rend2.material.color = Color.gray;
                if (deltaRnd2 == 2) rend2.material.color = Color.white;
                if (deltaRnd2 > 2) rend2.material.color = Color.black;
            }
        }
    }
}

