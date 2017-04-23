using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.IO.Ports;


public class oeUart : MonoBehaviour {

    public int num = 5;

	// Use this for initialization
	void Start () {

        for (int i = 0; i < num; i++)
        {
            Debug.Log("*******************************************"+i.ToString());
            Delay(100);
        }
        ListCOMPorts();


    }
	
	// Update is called once per frame
	void Update () {
       


    }
    //----------------------------------------------------------------

    // List COM Ports
    private void ListCOMPorts()
    {
        foreach (string s in SerialPort.GetPortNames())
        {
            Debug.Log(s);
        }   
    }



    //---zpoždění v setinách sec. 1s = 100 - blokuje celý proces!!!
    public void Delay(int ds) { System.Threading.Thread.Sleep(ds); }

}
