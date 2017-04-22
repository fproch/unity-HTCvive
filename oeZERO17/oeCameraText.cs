using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Jan Komínek @15.03.2017 - first version
/* Jan Komínek @16.03.2017 - removed few parts I forgot through deriving this from oeTextScreen
 *                         - removed public font variable and associated font change function, no need for it anymore
 */

public class oeCameraText : MonoBehaviour {
    
    private int cameraWidth; //control indicator for camera width change
    private GameObject InputUI;

    void Start()
    {
        cameraWidth = gameObject.GetComponent<Camera>().pixelWidth;

        InputUI = new GameObject("InputUI");

        InputUI.transform.parent = transform;
        InputUI.transform.position = transform.position
                                        + transform.forward * 0.32f                     // moving it in front of the cam so that it can be seen at all
                                        + transform.right * cameraWidth * -0.000215f    // positioning to the bottom-left of the screen
                                        + transform.up * -0.17f;                        // if the camera dimensions change - text stays on bottom, but shifts side-wise
                                                                                        //      -> first if in Update()
        InputUI.transform.rotation = transform.rotation;
        InputUI.transform.localScale = new Vector3(0.02f, 0.02f, 1.0f);

        InputUI.AddComponent<TextMesh>();
        InputUI.GetComponent<TextMesh>().characterSize = 0.15f; // This is to ensure
        InputUI.GetComponent<TextMesh>().fontSize = 20;       // that the text is not blurry
        InputUI.GetComponent<TextMesh>().anchor = TextAnchor.LowerLeft;

        InputUI.GetComponent<TextMesh>().text = ">\toeZERO\t<\npreAlpha Build\n\tverze 17";
    }

    // Update is called once per frame
    void Update ()
    {
        if (cameraWidth != gameObject.GetComponent<Camera>().pixelWidth) // in case the width of camera would change, move the object accordingly
        {
            InputUI.transform.position += transform.right * (gameObject.GetComponent<Camera>().pixelWidth - cameraWidth) * -0.000215f;
            cameraWidth = gameObject.GetComponent<Camera>().pixelWidth;
        }
    }
}
