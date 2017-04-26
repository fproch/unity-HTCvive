using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Sample for reading using polling by yourself. In case you are fond of that.

public class oeSerialRead : MonoBehaviour
{
    public int indexData = 7;
    public bool debugLog = false;

    public SerialController serialController;




    // Initialization
    void Start()
    {
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
    }

    // Executed each frame
    void Update()
    {
        string message = serialController.ReadSerialMessage();

        if (message == null)
            return;

        // Check if the message is plain data or a connect/disconnect event.
        if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_CONNECTED))
            Debug.Log("Connection established");
        else if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_DISCONNECTED))
            Debug.Log("Connection attempt failed or disconnection detected");
        else           
        {
            //if (debugLog) Debug.Log("Message arrived: " + message);
            string selector = message[0].ToString();
            int num = System.Int32.Parse(message.Substring(1));
            if (debugLog) Debug.Log("Message arrived: " + selector + " > " + num.ToString());

            if (selector == "U") oeCommonDataContainer.setArrInt(indexData, num);
            if (selector == "L") oeCommonDataContainer.setArrInt(indexData+1, num);
            if (selector == "T") oeCommonDataContainer.setArrInt(indexData + 2, num);
        }
    }
}
