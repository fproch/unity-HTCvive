using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Controls rundown: 
 * overall  - X - reverse X axis movement
 *          - Y - reverse Y axis movement
 *          - C - switch between 1stPerson and 3rdPerson camera; disables motion controls for the duration of the shift
 *
 * 1st person camera    - RMB - look around, currently flawed - also rotates the view slightly around forward axis for some reason
 *                      - TAB - center viewpoint
 *                      
 * 3rd person camera    - LMB - look "over the shoulder" of the object
 *                      - RMB - Rotate the view around object
 *                      - mousewheel - zoom in/out
 *                      - TAB - center viewpoint
 */

// Jan Komínek @01.03.2017 - First version
/* Jan Komínek @15.03.2017 - Modified initial script into two possibilities
 *                         - Now hosting a twoCam and oneCam versions, which is to be used is TBD
 *                         - modified control buttons, switched from ctrl, alt, shift to strictly mouse control
 */
 // Jan Komínek @16.03.2017 - Added rundown of controls into initial comments for easier comprehension

public class oeCamControls : MonoBehaviour
{

    public float rotSpeed, movSpeed;
    public Transform target;

    private bool revertX, revertY;
    private float distance;
    
// ------------------------------------------twoCams-------------------------------------
// ------------------------------------------version-------------------------------------
/*
private GameObject firstPersonCam, thirdPersonCam;

// Use this for initialization
void Start()
{
    revertX = false;
    revertY = false;

    firstPersonCam = new GameObject("1stPersonCamera", typeof(Camera));
    firstPersonCam.transform.parent = target.transform;
    firstPersonCam.GetComponent<Camera>().targetDisplay = 1;

    firstPersonCam.transform.position = target.position;
    firstPersonCam.transform.rotation = target.rotation * Quaternion.Euler(0.0f, 180.0f, 0.0f);

    thirdPersonCam = Instantiate(firstPersonCam, target.transform);
    thirdPersonCam.transform.name = "3rdPersonCamera";
    thirdPersonCam.transform.Translate(target.up * 0.7f + target.forward * -1.0f);
    thirdPersonCam.transform.LookAt(target);

    firstPersonCam.SetActive(false);
    firstPersonCam.AddComponent<oeCameraText>(); //add oeCameraText script as a component
    thirdPersonCam.AddComponent<oeCameraText>(); //and to the 3P camera too, ofc
}

// Update is called once per frame
void Update()
{
    // rotation

    if (Input.GetKey(KeyCode.Mouse0) && thirdPersonCam.activeInHierarchy) // Third person cam - "Look over the shoulder" movement
    {
        thirdPersonCam.transform.Translate(new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0) * Time.deltaTime * rotSpeed);
    }

    if (Input.GetKey(KeyCode.Mouse1))
    {
        if (thirdPersonCam.activeInHierarchy) // Third person cam - Rotation around object
        {
            distance = Vector3.Distance(target.position, thirdPersonCam.transform.position);
            thirdPersonCam.transform.Translate(new Vector3(Input.GetAxis("Mouse X") * (revertX ? 1.0f : -1.0f), // If reverse horizontal, multiply by -1
                                            Input.GetAxis("Mouse Y") * (revertY ? 1.0f : -1.0f), // If reverse vertical, multiply by -1
                                            0.0f) * Time.deltaTime * movSpeed);

            thirdPersonCam.transform.LookAt(target);
            thirdPersonCam.transform.Translate(Vector3.forward * (Vector3.Distance(target.position, thirdPersonCam.transform.position) - distance)); //Movement slightly towards the object to negate the offset of sideways motion
        }
        else // !! rotary movement of mouse causes view to roll around objects Z-axis !! 
            firstPersonCam.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * (revertY ? 1.0f : -1.0f), // If reverse vertical, multiply by -1
                                                    Input.GetAxis("Mouse X") * (revertX ? -1.0f : 1.0f), // If reverse horizontal, multiply by -1
                                                    0.0f) * Time.deltaTime * movSpeed);

    }

    //  Third person cam - zooming in/out
    if (thirdPersonCam.activeInHierarchy)
        thirdPersonCam.transform.Translate(Vector3.forward * Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * movSpeed);

    if (Input.GetKey(KeyCode.Tab))
    { //Reverse back to "default" position
        if (thirdPersonCam.activeInHierarchy)
        {
            thirdPersonCam.transform.rotation = Quaternion.Slerp(thirdPersonCam.transform.rotation, target.rotation * Quaternion.Euler(35.0f, 0.0f, 0.0f), Time.deltaTime * rotSpeed);
            // rotSpeed instead of movSpeed so that the movement would correspond with rotation speed on the way back
            thirdPersonCam.transform.position = Vector3.Slerp(thirdPersonCam.transform.position, target.position + target.up * 0.7f + target.forward * -1.0f, Time.deltaTime * rotSpeed);
            thirdPersonCam.transform.LookAt(target);
        }
        else
            firstPersonCam.transform.rotation = Quaternion.Slerp(firstPersonCam.transform.rotation, target.rotation, Time.deltaTime * rotSpeed);

    }

    //misc
    //note to self: unlike GetKey(), GetKeyDown() doesn't repeat in update until button re-press

    if (Input.GetKeyDown(KeyCode.X)) // Invert X axis movement
    {
        revertX = !revertX;
    }
    if (Input.GetKeyDown(KeyCode.Y)) // Invert Y axis movement
    {
        revertY = !revertY;
    }

    if (Input.GetKeyDown(KeyCode.C)) // Invert Y axis movement
    {
        if (thirdPersonCam.activeInHierarchy)
        {
            thirdPersonCam.transform.position = target.position + target.up * 0.7f + target.forward * -1.0f;
            thirdPersonCam.transform.rotation = target.rotation * Quaternion.Euler(35.0f, 0.0f, 0.0f);
            thirdPersonCam.transform.LookAt(target);
        }
        else
            firstPersonCam.transform.rotation = target.rotation;

        thirdPersonCam.SetActive(firstPersonCam.activeInHierarchy);
        firstPersonCam.SetActive(!firstPersonCam.activeInHierarchy);
    }
}    
*/

// ------------------------------------------oneCam--------------------------------------
// ------------------------------------------version-------------------------------------
//*

    public float shiftPrecision = 0.05f;

    private bool cam1P, shiftView;
    private GameObject followCam;

    // Use this for initialization
    void Start()
    {
        revertX = false;
        revertY = false;
        cam1P = false; //reminder of whether the cam is in 1st person view
        shiftView = false;

        followCam = new GameObject("FollowCamera", typeof(Camera));
        followCam.transform.parent = target.transform;
        followCam.GetComponent<Camera>().targetDisplay = 1;

        followCam.transform.position = target.position + target.up * 0.7f + target.forward * -1.0f;
        followCam.transform.rotation = target.rotation * Quaternion.Euler(35.0f, 0.0f, 0.0f);
        //followCam.transform.rotation = target.transform.rotation * Quaternion.Euler(35.0f, 180.0f, 0.0f);  -původně kvuli pohybu kostky dozadu místo dopředu a vice versa

        followCam.AddComponent<oeCameraText>(); //add oeCameraText script as a component
    }

    // Update is called once per frame
    void Update()
    {
        // rotation

        if (Input.GetKey(KeyCode.Mouse0) && !cam1P && !shiftView) // Third person cam - "Look over the shoulder" movement
        {
            followCam.transform.Translate(new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0) * Time.deltaTime * rotSpeed);
        }

        if (Input.GetKey(KeyCode.Mouse1) && !shiftView)
        {
            /* remnants of motion being available while shifting views
            if (shiftView)
            { //if View is being shifted, this is to make sure you don't end up in 1stPC controls in 3rdPC view
                shiftView = false;

                if (cam1P)
                    cam1P = false;
            }
            */

            if (cam1P) //First person cam - Looking around
                followCam.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * (revertY ? 1.0f : -1.0f), // If reverse vertical, multiply by -1
                                                    Input.GetAxis("Mouse X") * (revertX ? -1.0f : 1.0f), // If reverse horizontal, multiply by -1
                                                    0.0f) * Time.deltaTime * movSpeed);

            else // Third person cam - Rotation around object
            {
                distance = Vector3.Distance(target.position, followCam.transform.position);
                followCam.transform.Translate(new Vector3(Input.GetAxis("Mouse X") * (revertX ? 1.0f : -1.0f), // If reverse horizontal, multiply by -1
                                                Input.GetAxis("Mouse Y") * (revertY ? 1.0f : -1.0f), // If reverse vertical, multiply by -1
                                                0.0f) * Time.deltaTime * movSpeed);

                followCam.transform.LookAt(target);
                followCam.transform.Translate(Vector3.forward * (Vector3.Distance(target.position, followCam.transform.position) - distance)); //Movement slightly towards the object to negate the offset of sideways motion
            }
        }

        //  Third person cam - zooming in/out
        if (!cam1P && !shiftView)
            followCam.transform.Translate(Vector3.forward * Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * movSpeed);

        if (Input.GetKey(KeyCode.Tab) && !shiftView)
        { //Center camera back to "default" position
            if (!cam1P)//if in 3rd person, initiate the if(shiftview)
                shiftView = true;
            else
                followCam.transform.rotation = Quaternion.Slerp(followCam.transform.rotation, target.rotation, Time.deltaTime * rotSpeed);
        }

        //misc
        //note to self: unlike GetKey(), GetKeyDown() doesn't repeat in update until button re-press

        if (Input.GetKeyDown(KeyCode.X)) // Invert X axis movement
        {
            revertX = !revertX;
        }
        if (Input.GetKeyDown(KeyCode.Y)) // Invert Y axis movement
        {
            revertY = !revertY;
        }

        if (Input.GetKeyDown(KeyCode.C)) // Invert Y axis movement
        {
            cam1P = !cam1P;
            shiftView = true;
        }

        // "cinematic" shift between 1st person and 3rd person camera; initiated by other means
        if (shiftView) 
        {
            if (cam1P)
            {
                if (Vector3.Distance(followCam.transform.position, target.transform.position) > shiftPrecision)
                {
                    followCam.transform.position = Vector3.Slerp(followCam.transform.position, target.position, Time.deltaTime * rotSpeed);
                    followCam.transform.rotation = Quaternion.Slerp(followCam.transform.rotation, target.rotation, Time.deltaTime * rotSpeed);
                }
                else
                    shiftView = false;
            }
            else
            {
                if (Vector3.Distance(followCam.transform.position, target.position + target.up * 0.7f + target.forward * -1.0f) > shiftPrecision)
                { //shifts the position and rotation continually until it reaches near equal position
                    followCam.transform.rotation = Quaternion.Slerp(followCam.transform.rotation, target.rotation * Quaternion.Euler(35.0f, 0.0f, 0.0f), Time.deltaTime * rotSpeed);
                    followCam.transform.position = Vector3.Slerp(followCam.transform.position, target.position + target.up * 0.7f + target.forward * -1.0f, Time.deltaTime * rotSpeed);
                }
                else
                    shiftView = false;
            }

        }
    }
//*/
}
