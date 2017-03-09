using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oeCubesWall1 : MonoBehaviour
{
    //(1)
    public GameObject[,] cubeMatrix2;

    public int numCube = 15; //30x30=900 //public se objeví v Extending Editoru!
    public bool onlyBlack = true; //
    public bool existBlack = true; //
    public bool destroyAll = true; //
    public int numRandom = 10;
    public int deltaZet = 9;
    //--------------------------------

    int ii = 0;

    public Renderer rend2;
    public Vector3 startMatrix; //stred vykresleni matice
    //==================================================================================
    void Start()
    {
        Debug.Log("oeCubes.start() > TestCreate cubeMatrix2");

        startMatrix = new Vector3(-numCube / 2, -0.5f, -numCube / 2+ deltaZet);  //pocatek vykresleni matice
        TestCreateMatrix2();
    }

    void Update()
    {
    }
    //==================================================================================
    private void TestCreateMatrix2()
    {
        cubeMatrix2 = new GameObject[numCube, numCube];

        for (int i = 0; i < numCube; i++)
        {
            for (int j = 0; j < numCube; j++)
            {
                ///Debug.Log("i->" + i.ToString() + "j->" + j.ToString());

                // Tento riadok vytvori dve kocky - 1. biela so suradnicami (0,0,0), 2. KOPIA so suradnicami (startMatrix.x + i, startMatrix.y, startMatrix.z + j)
                // Cize chybou nebolo preblikavanie ale vytvaranie kopii
                // Metoda (GameObject)Instantiate je lepsie pouzit na existujuci objekt s viacerimi parametrami
                // v tomto pripade, ked vzdy vytvarame novu kocku to nie je potrebne
                //cubeMatrix2[i ,j] = (GameObject)Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube),  new Vector3(startMatrix.x + i, startMatrix.y, startMatrix.z+j), Quaternion.identity);

                cubeMatrix2[i, j] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cubeMatrix2[i, j].name = "cube" + i.ToString() + j.ToString();

                cubeMatrix2[i, j].transform.localScale = new Vector3(0.95F, 0.95F, 0.95F);
                cubeMatrix2[i, j].transform.localPosition = new Vector3(startMatrix.x + i, startMatrix.y+j, startMatrix.z);

                rend2 = cubeMatrix2[i, j].GetComponent<Renderer>();
                if (onlyBlack)
                {
                    rend2.material.color = Color.black;
                    cubeMatrix2[i, j].tag = "removable";
                }
                else
                {
                    float deltaRnd2 = Mathf.Floor(Random.Range(0, numRandom));
                    var randomA = Random.Range(200, 300);
                    if (destroyAll) Destroy(cubeMatrix2[i, j], (float)randomA/10);

                    if (deltaRnd2 == 1) rend2.material.color = Color.gray;
                    if (deltaRnd2 == 2) rend2.material.color = Color.white;
                    if (deltaRnd2 > 2)
                    {
                        rend2.material.color = Color.black;
                        if (existBlack)
                        {
                            cubeMatrix2[i, j].tag = "removable";
                        }
                        else
                        {
                            var randomD = Random.Range(150, 200);
                            Destroy(cubeMatrix2[i, j], (float)randomD /10);
                        }

                    }

                }

            }
        }
    }
}