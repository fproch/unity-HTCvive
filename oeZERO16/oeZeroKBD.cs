using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class oeZeroKBD : MonoBehaviour
{
    public float moveStrength = 0.05f;
    public float rotateStrength = 0.5f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // movement
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(-moveStrength, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(moveStrength, 0, 0));
            
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0, 0, moveStrength));
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0, 0, -moveStrength));           
        }
        // rotation
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, rotateStrength, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -rotateStrength, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(new Vector3(rotateStrength, 0, 0));
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(new Vector3(-rotateStrength, 0, 0));
        }
    }
}