using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oeKeybSound : MonoBehaviour
{

    public GameObject snd1;
    public GameObject snd2;
    public GameObject snd3;
    
    public bool debugLog = false;
    int cntU = 0;
    int cntKbd = 0;

    // Use this for initialization
    void Start () {
        if (debugLog) Debug.Log("oeKeybSound.Start");
    }
	
	// Update is called once per frame
	void Update () {
        cntU++;

        if (Input.GetKey(KeyCode.A))
        {
            snd1.SetActive(true);
        }

        if (Input.GetKey(KeyCode.D))
        {
            snd1.SetActive(false);
        }
        
        if (Input.GetKey(KeyCode.P))
        {
            cntKbd++;
            if (debugLog) Debug.Log(cntU + " > P-ok: "+ cntKbd);
        }    


        // movement
        /*
        if (Input.GetKey(KeyCode.RightArrow))
        {            transform.Translate(new Vector3(-moveStrength, 0, 0));        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {            transform.Translate(new Vector3(moveStrength, 0, 0));        }
        if (Input.GetKey(KeyCode.DownArrow))
        {            transform.Translate(new Vector3(0, 0, moveStrength));        }
        if (Input.GetKey(KeyCode.UpArrow))
        {            transform.Translate(new Vector3(0, 0, -moveStrength));
        }
        */
        }
}
