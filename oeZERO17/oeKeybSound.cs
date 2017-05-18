using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oeKeybSound : MonoBehaviour
{

    public GameObject snd1;
    public GameObject snd2;
    public GameObject snd3;

    public bool rndSnd2 = false;
    public bool beatSnd3 = false;
    public int everyFPS = 500;
    public int volume3 = 50;

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
            if (debugLog) Debug.Log(cntU + " > P-ok: " + cntKbd);
            cntKbd++;
            play2();
            //snd2.GetComponent<AudioSource>().volume = (float)oeData0 / 100;
        }

        if (rndSnd2)
        {
            if (cntU % 1000 == 0) play2();
        }



        if (beatSnd3)
        {
            if (cntU % everyFPS == 0) play3();
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

    void play2()
    {
        snd2.SetActive(false);
        snd2.SetActive(true); ///sound1.ok 
    }

    void play3()
    {
        snd3.SetActive(false);
        snd3.SetActive(true); ///sound1.ok 
        snd3.GetComponent<AudioSource>().volume = volume3 * 0.01f; //(float)oeData0 / 100;
    }



}
