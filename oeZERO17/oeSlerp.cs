using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oeSlerp : MonoBehaviour
{

    public float distance = 0.5f;
    public float minStep = 0.01f;
    private bool posun = false;
    private bool dir = false;
    public bool debugLog = false;
    
    /*public int deltaTime = 1000;
    public bool xR = true;
    public bool yR = false;
    public bool zR = false;
    */
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame    
        /*
        // Rotate the object around its local X axis at 1 degree per second
        if (xR) transform.Rotate(Vector3.up * Time.deltaTime);
        if (yR) transform.Rotate(Vector3.right * Time.deltaTime);
        if (zR) transform.Rotate(Vector3.left * Time.deltaTime);
        */      

    protected void Update()
    {

        if (posun)
            if (Vector3.Distance(transform.position, transform.parent.position + transform.parent.forward * (dir ? 1 : -1)) > minStep)
            {
               transform.position = Vector3.Slerp(transform.position, transform.parent.position + transform.parent.forward * (dir ? 0.2f : -0.2f), Time.deltaTime * distance);
            }
            else
                posun = false;
    }

    public void move(bool direction)
    {
        posun = true;
        dir = direction;
     }

    public void initPos()
    {
        transform.position = transform.parent.position + transform.parent.right * 0.2f;
    }
}
