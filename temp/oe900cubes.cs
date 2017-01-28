using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oe900cubes : MonoBehaviour {
    //(1)
    public GameObject[,] cubeMatrix2;
    public int numCube = 8; //30x30=900 //public se objeví v Extending Editoru!
    int ii = 0;

    public Renderer rend2;
    public Vector3 startMatrix; //stred vykresleni matice
    //==================================================================================
    void Start () {
        Debug.Log("---> oe900cubes.start() > TestCreateMatrix2");

        startMatrix = new Vector3(-numCube/2, 0, -numCube/2);  //pocatek vykresleni matice
        TestCreateMatrix2();
    }

	void Update () {
    }
    //==================================================================================
    private void TestCreateMatrix2()
    {
        cubeMatrix2 = new GameObject[numCube , numCube];

        for (int i = 0; i < numCube; i++)
        {
            for (int j = 0; j < numCube; j++)
            {
                Debug.Log("i->"+i.ToString()+"j->" + j.ToString());

				// Tento riadok vytvori dve kocky - 1. biela so suradnicami (0,0,0), 2. KOPIA so suradnicami (startMatrix.x + i, startMatrix.y, startMatrix.z + j)
				// Cize chybou nebolo preblikavanie ale vytvaranie kopii
				// Metoda (GameObject)Instantiate je lepsie pouzit na existujuci objekt s viacerimi parametrami
				// v tomto pripade, ked vzdy vytvarame novu kocku to nie je potrebne
                //cubeMatrix2[i ,j] = (GameObject)Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube),  new Vector3(startMatrix.x + i, startMatrix.y, startMatrix.z+j), Quaternion.identity);

				cubeMatrix2[i, j] = GameObject.CreatePrimitive(PrimitiveType.Cube);
				cubeMatrix2[i, j].transform.localScale = new Vector3(0.95F, 1F, 0.95F);
				cubeMatrix2[i, j].transform.localPosition = new Vector3(startMatrix.x + i, startMatrix.y, startMatrix.z + j);

                rend2 = cubeMatrix2[i, j].GetComponent<Renderer>();
                //float deltaRnd2 = Mathf.Floor(Random.Range(0, 20));
                //if (deltaRnd2 == 1) rend2.material.color = Color.gray;
                //if (deltaRnd2 == 2) rend2.material.color = Color.white;
                //if (deltaRnd2 > 2) rend2.material.color = Color.black;
                rend2.material.color = Color.black;
            }
        }
    }
}
