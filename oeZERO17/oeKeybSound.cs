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
    public bool beatSnd3pattern = false;
    public bool pattFade3 = false;


    public int everyFPS = 500;
    public int volume3 = 50;

    public bool debugLog = false;
    int pi = 0;
    int cntU = 0;
    int cntKbd = 0;
    int vol3 = 10; // temp volume % 0-100


    int[] pattern1 = new int[8] { 1,0,1,0,1,1,1,0 };




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
            if (cntU % everyFPS == 0) play3(volume3);
        }

        if (beatSnd3pattern)
        {
            if (cntU % everyFPS == 0)
            {
                if (pi > pattern1.Length-1) pi = 0;
                if (pattFade3) vol3 =volume3;
                else vol3 = volume3;

                if (pattern1[pi] == 1) play3(100-(pi+1)*10);              
                
                pi++;
            }
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

    void play3(int vol)
    {
        snd3.SetActive(false);
        snd3.SetActive(true); ///sound1.ok 
        snd3.GetComponent<AudioSource>().volume = vol * 0.01f; //(float)oeData0 / 100;
    }



}
