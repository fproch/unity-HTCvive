using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oeTexture1 : MonoBehaviour {
   
    /*public Color colorN;
    public Color colorN2;
    public Color colorN3;
    public bool Fractal1 = true;
    public bool Noise1 = true;
    public bool Noise2 = true;
    public bool Noise3 = false;

    public bool StartNoise1 = true;
    public bool StartNoise2 = true;
    public bool StartFrame = false;
    public bool StartLines = false;
    public bool StartCircle = false;
    public int radius = 50;

    private Texture2D texture = new Texture2D(128, 128); //128
    Color colorRed = Color.red;

    // Use this for initialization
    void Start () {
        GetComponent<Renderer>().material.mainTexture = texture;

        if (StartNoise1)
        {
            for (int x = 0; x < texture.width; x++)
            {

                int y = Random.Range(0, texture.height);
                texture.SetPixel(x, y, colorN);
            }
        }

        if (StartNoise2)
        {
            for (int x = 0; x < texture.width; x++)
            {

                int y = Random.Range(0, texture.height);
                texture.SetPixel(x, y, colorN);
                int y2 = Random.Range(0, texture.height);
                texture.SetPixel(x, y2, colorN2);
            }
        }

        if (StartFrame)
        {
            for (int x = 0; x < texture.width; x++)
            {

                texture.SetPixel(x, 1, colorN);
                texture.SetPixel(x, texture.height-1, colorN);

            }
        }

        if (StartLines)
        {
            for (int x = 0; x < texture.width; x++)
            {
                for (int y = 0; y < texture.width/10+1; y++)  texture.SetPixel(x, y*10, colorN2);
               // texture.SetPixel(x, texture.height - 1, colorN);

            }
        }

        if (StartCircle)
        {
            int r = radius; // radius
            int ox = texture.height/2, oy = texture.width/2; // origin

            for (int x = -r; x < r; x++)
            {
                int height = (int)Mathf.Sqrt(r * r - x * x);

                for (int y = -height; y < height; y++)
                    texture.SetPixel(x + ox, y + oy, colorN3);
            }
        }


    }
	
	// Update is called once per frame
	void Update () {

        if (Fractal1)
        {
            for (int y = 0; y < texture.height; y++)
            {
                for (int x = 0; x < texture.width; x++)
                {
                    Color color = ((x & y) != 0 ? Color.white : Color.gray);
                    texture.SetPixel(x, y, color);
                }
            }
        }

        if (Noise1)
        {
            for (int x = 0; x < texture.width; x++)
            {

                int y = Random.Range(0, texture.height);
                texture.SetPixel(x, y, colorN);
            }
        }

        if (Noise2)
        {
            for (int x = 0; x < texture.width; x++)
            {

                int y = Random.Range(0, texture.height);
                texture.SetPixel(x, y, colorN);
                int y2 = Random.Range(0, texture.height);
                texture.SetPixel(x, y2, colorN2);
            }
        }

        if (Noise3)
        {
            for (int x = 0; x < texture.width-1; x++)
            {

                int y = Random.Range(0, texture.height-1);
                texture.SetPixel(x, y, colorN);
                texture.SetPixel(x+1, y, colorN);
                texture.SetPixel(x, y+1, colorN);
                texture.SetPixel(x+1, y+1, colorN);
            }
        }





        texture.Apply();

    }
    */
   
}
