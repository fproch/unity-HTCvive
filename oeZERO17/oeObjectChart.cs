using UnityEngine;
using System.IO; //streamReader
using System.Collections; //JSON
using System.Collections.Generic;

//http://answers.unity3d.com/questions/332001/how-to-reset-a-gamev-object-to-its-original-rotati.html


public class oeObjectChart : MonoBehaviour
{
    //příprava
    public int matrixIndex;
    public string label = "label";
    public int sizeX = 50;
    public GameObject[,] objMatrix;
    GameObject go;
    Renderer rend;

    public enum NO { Sphere, Cube, Cylinder }

    public float scaleSize = 0.1f;
    public float distanceDivide = 5;
    public Color mainColor;
    public enum GR { G1, G2, G3, G4, G5 }

    private Vector3 startVector; //stred vykresleni matice
    public Transform strartTransform;
    public NO primitiveType;
    public GR chartType;

    public string nameObj = "dG";
    public bool transformXZ = false;
    public bool transformYZ = false;
    public bool debugList = false;
    public bool doUpdate = false;
    public int everyMilisec = 10;

    int cntU;
    float tempi;


    //================================================================================================
    //start-inicializace
    void Start()
    {
        Debug.Log("oeObjectChart.constructor - newObjects: " + primitiveType);
        startVector = strartTransform.position;


        oeObjChart();
    }
    //------------------------------------------------/start----------------------------------------

    //timer cca60 FPS
    void Update()
    {
        cntU++;
       

        if (cntU % everyMilisec == 0)
        {
            if (doUpdate) oeObjChartUpdate();
        }


       
    }

    //------------------------------------------------------------------------------------------------



    private void oeObjChart()
    {
        objMatrix = new GameObject[sizeX, sizeX];

        int ii = 0;
        for (int y = 0; y < sizeX; y++)
        {
            for (int x = 0; x < sizeX; x++) {
                switch (primitiveType.ToString())
                {
                    case "Cube":                       
                        objMatrix[x, y] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        break;
                    case "Sphere":
                        objMatrix[x, y] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        break;
                    case "Cylinder":
                        objMatrix[x, y] = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                        break;


                    default:
                        objMatrix[x, y] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        break;
                }
                //objMatrix[x, y] = go;                

                //Rigidbody gameObjectsRigidBody = go.AddComponent<Rigidbody>(); // Add the rigidbody.
                //gameObjectsRigidBody.mass = oeMass; // Set the GO's mass to 5 via the Rigidbod
                //go.GetComponent<Rigidbody>().useGravity = true;
                objMatrix[x, y].name = nameObj + matrixIndex+"." + ii;
                //cubeMatrix2[i, j]

                float xi = x/ distanceDivide;
                float yi = y/ distanceDivide;
                float zi = 0;

                switch (chartType.ToString())
                {
                    case "G1":
                        zi = (10) / distanceDivide;
                        break;
                    case "G2":
                        zi = (x + y) / distanceDivide;
                        break;
                    case "G3":
                        //zi = (Mathf.Sin(x/10) * Mathf.Cos(y/10)) / distanceDivide*5;
                        zi = (Mathf.Sin((float)x / 10) * Mathf.Cos((float)y / 10)) / distanceDivide * 5;
                        break;

                    case "G4":
                        //zi = (Mathf.Sin(x/10) * Mathf.Cos(y/10)) / distanceDivide*5;
                        zi = (Mathf.Sin((float)x / 10) * Mathf.Cos((float)y / 10)) / distanceDivide * 5;
                        break;
                    case "G5":
                        //zi = (Mathf.Sin(x/10) * Mathf.Cos(y/10)) / distanceDivide*5;
                        zi = (Mathf.Sin((float)x / 10) * Mathf.Cos((float)y / 10)) / distanceDivide * 5;
                        break;

                    default:
                        zi = (x + y) / distanceDivide;
                        break;
                }

                if (transformXZ) { float tempi = zi; zi = xi; xi = tempi; }
                if (transformYZ) { tempi = zi; zi = yi; yi = tempi; }

                if (debugList) Debug.Log(objMatrix[x, y].name+": " + xi + ", " + yi + ", " + zi);
                objMatrix[x, y].transform.position = new Vector3(startVector.x+xi, startVector.y+yi, startVector.z+zi);
                objMatrix[x, y].transform.localScale = new Vector3(scaleSize, scaleSize, scaleSize);

                //}
                //catch {  Debug.Log("Err: try Parse...");  }
                rend = objMatrix[x, y].GetComponent<Renderer>();
                rend.material.color = mainColor;               
            }
            ii++;
        }
    }



    private void oeObjChartUpdate()
    {
        //objMatrix = new GameObject[sizeX, sizeX];
        startVector = strartTransform.position;

        int ii = 0;
        for (int y = 0; y < sizeX; y++)
        {
            for (int x = 0; x < sizeX; x++)
            {

                //objMatrix[x, y] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                //objMatrix[x, y] = go;                

                //Rigidbody gameObjectsRigidBody = go.AddComponent<Rigidbody>(); // Add the rigidbody.
                //gameObjectsRigidBody.mass = oeMass; // Set the GO's mass to 5 via the Rigidbod
                //go.GetComponent<Rigidbody>().useGravity = true;
                //objMatrix[x, y].name = nameObj + matrixIndex + "." + ii;
                //cubeMatrix2[i, j]

                float xi = x / distanceDivide;
                float yi = y / distanceDivide;
                float zi = 0;

                switch (chartType.ToString())
                {
                    case "G1":
                        zi = (10) / distanceDivide;
                        break;
                    case "G2":
                        zi = (x + y) / distanceDivide;
                        break;
                    case "G3":
                        //zi = (Mathf.Sin(x/10) * Mathf.Cos(y/10)) / distanceDivide*5;
                        zi = (Mathf.Sin((float)x / 10) * Mathf.Cos((float)y / 10)) / distanceDivide * 5;
                        break;

                    case "G4":
                        //zi = (Mathf.Sin(x/10) * Mathf.Cos(y/10)) / distanceDivide*5;
                        zi = (Mathf.Sin((float)x / 10) * Mathf.Cos((float)y / 10)) / distanceDivide * 5;
                        break;
                    case "G5":
                        //zi = (Mathf.Sin(x/10) * Mathf.Cos(y/10)) / distanceDivide*5;
                        zi = (Mathf.Sin((float)x / 10) * Mathf.Cos((float)y / 10)) / distanceDivide * 5;
                        break;

                    default:
                        zi = (x + y) / distanceDivide;
                        break;
                }

                if (transformXZ) {  tempi = zi; zi = xi; xi = tempi; }
                if (transformYZ) {  tempi = zi; zi = yi; yi = tempi; }

                //if (debugList) Debug.Log(objMatrix[x, y].name + ": " + xi + ", " + yi + ", " + zi);
                objMatrix[x, y].transform.position = new Vector3(startVector.x + xi, startVector.y + yi, startVector.z + zi);
                //objMatrix[x, y].transform.localScale = new Vector3(scaleSize, scaleSize, scaleSize);

                //}
                //catch {  Debug.Log("Err: try Parse...");  }
                //rend = objMatrix[x, y].GetComponent<Renderer>();
                //rend.material.color = mainColor;
            }
            ii++;
        }
    }

}
      


