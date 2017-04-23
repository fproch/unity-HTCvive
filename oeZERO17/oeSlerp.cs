using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oeSlerp : MonoBehaviour
{

    public float oneStep = 2.0f;
    public float minStep = 0.01f;
    private bool posun = false;
    private bool scaleActive = false;
    private bool activity = false;
    public int objectID;
    public bool debugLog = false;
    private Vector3 initScale;
    
    /*public int deltaTime = 1000;
    public bool xR = true;
    public bool yR = false;
    public bool zR = false;
    */
    // Use this for initialization
    void Start()
    {
        initScale = transform.localScale;
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
        if (scaleActive)
        {
            if (activity)
                transform.localScale = Vector3.Slerp(transform.localScale, new Vector3(0.0f, 0.0f, 0.0f), Time.deltaTime * oneStep);
            else
                transform.localScale = Vector3.Slerp(transform.localScale, initScale, Time.deltaTime * oneStep);
        }

        if (posun)
        {
            Vector3 pos = getNewPos(objectID);

            if (Vector3.Distance(transform.position, pos) > minStep)
            {
                transform.position = Vector3.Slerp(transform.position, pos, Time.deltaTime * oneStep);
                //transform.localScale = 1/ new Vector3()
            }
            else
            {
                if (!activity)
                    gameObject.SetActive(false);
                posun = false;
            }
        }
           
    }

    private Vector3 getNewPos(int objID)
    {
        switch (objectID)
        {
            case 0:
                if (activity)
                    return transform.parent.position + transform.parent.forward * 0.25f;
                else
                    return transform.parent.position + transform.parent.right * 0.01f;
            case 1:
                if (activity)
                    return transform.parent.position + transform.parent.forward * -0.25f;
                else
                    return transform.parent.position + transform.parent.right * 0.02f;
            case 2:
                if (activity)
                    return transform.parent.position + transform.parent.right;
                else
                    return transform.parent.position + transform.parent.right * 0.03f;
            default:
                return transform.parent.position;
        }
    }

    public void useObject(bool slerp, bool scale, int objID)
    {
            if (!gameObject.activeInHierarchy)
                gameObject.SetActive(true);

            objectID = objID;
            activity = !activity;
        if (slerp)
        {
            posun = true;
        }

        if (scale)
        {
            scaleActive = true;
        }







    }
}
