using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oeCamControls : MonoBehaviour
{
    float rotSpeed = 1.0f; // Rotation speed modifier
    float movSpeed = 50.0f; // Movement speed modifier
    bool revertX = false;
    bool revertY = false;
    float distance;
    public Transform target;

    // Use this for initialization
    void Start()
    {
        transform.LookAt(target);
    }

    // Update is called once per frame
    void Update()
    {
        // rotation

        if (Input.GetKey(KeyCode.LeftControl)) // "Look over the shoulder" movement
        {
            transform.Translate(new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0) * Time.deltaTime * rotSpeed);
        }

        if (Input.GetKey(KeyCode.LeftAlt)) // Rotation around object
        {
            distance = Vector3.Distance(target.position, transform.position);
            transform.Translate(new Vector3(Input.GetAxis("Mouse X") * (revertX ? 1.0f : -1.0f), // If reverse horizontal, multiply by -1
                                            Input.GetAxis("Mouse Y") * (revertY ? 1.0f : -1.0f), // If reverse vertical, multiply by -1
                                            0.0f) * Time.deltaTime * movSpeed);

            transform.LookAt(target);
            transform.Translate(Vector3.forward * (Vector3.Distance(target.position, transform.position) - distance)); //Movement slightly towards the object to negate the offset of sideways motion
        }

        if (Input.GetKey(KeyCode.LeftShift)) // Zooming in and out
        {
            transform.Translate(Vector3.forward * Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * movSpeed);
        }

        if (Input.GetKey(KeyCode.Tab))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, Time.deltaTime * rotSpeed);
            // rotSpeed instead of movSpeed so that the movement would correspond with rotation on the way back
            transform.position = Vector3.Slerp(transform.position, target.position, Time.deltaTime * rotSpeed);
            transform.LookAt(target);
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

    }
}
