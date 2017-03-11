using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oeCubePoints : MonoBehaviour
{

    public int horizontal = 5;
    public int vertical = 3;
    //public int size = 1;
    public float scale = 0.1f;

    private Vector3 position;

    // Use this for initialization
    void Start()
    {
        position = Vector3.zero;

        for (int j = 0; j < horizontal; j++)
        {

            for (int i = 0; i < vertical; i++)
            {
                position.x += scale*2;               
                GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                go.name = "oeCubePoints" + j +"." + i;
                go.transform.position = position;
                go.transform.localScale = new Vector3(scale, scale, scale);
                go.transform.SetParent(transform);
            }
            position.x = 0;
            position.y += scale*2;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}

