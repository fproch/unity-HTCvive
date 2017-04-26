using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.IO.Ports;




public class oeUart : MonoBehaviour {
    /*

    public int num = 5;
    public string myPort = "COM4";
    private SerialPort port = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
    bool zapisuj = false;
    string data = "nic";

    /// <summary>
    /// Enable notification of data as it arrives
    /// Sends OnSerialData(string data) message
    /// </summary>
    public bool NotifyData = false;

    /// <summary>
    /// Enable line detection and notification on received data.
    /// Message OnSerialLine(string line) is sent for every received line
    /// </summary>
    public bool NotifyLines = false;

    /// <summary>
    /// Maximum number of lines to remember. Get them with GetLines() or GetLastLine()
    /// </summary>
    public int RememberLines = 0;

    /// <summary>
    /// Enable lines detection, values separation and notification.
    /// Each line is split with the value separator (TAB by default)
    /// Sends Message OnSerialValues(string [] values)
    /// </summary>
    public bool NotifyValues = false;

    /// <summary>
    /// The values separator.
    /// </summary>
    public char ValuesSeparator = '\t';

    //string serialOut = "";
    private List<string> linesIn = new List<string>();

    /// <summary>
    /// Gets the received bytes count.
    /// </summary>
    /// <value>The received bytes count.</value>
    public int ReceivedBytesCount { get { return BufferIn.Length; } }

    /// <summary>
    /// Gets the received bytes.
    /// </summary>
    /// <value>The received bytes.</value>
    public string ReceivedBytes { get { return BufferIn; } }

    /// <summary>
    /// Clears the received bytes. 
    /// Warning: This prevents line detection and notification. 
    /// To be used when no \n is expected to avoid keeping unnecessary big amount of data in memory
    /// You should normally not call this function if \n are expected.
    /// </summary>
    public void ClearReceivedBytes()
    {
        BufferIn = "";
    }

    /// <summary>
    /// Gets the lines count.
    /// </summary>
    /// <value>The lines count.</value>
    public int linesCount { get { return linesIn.Count; } }

    #region Private vars

    // buffer data as they arrive, until a new line is received
    private string BufferIn = "";

    // flag to detect whether coroutine is still running to workaround coroutine being stopped after saving scripts while running in Unity
    private int nCoroutineRunning = 0;
    #endregion

    #region Static vars

    // Only one serial port shared among all instances and living after all instances have been destroyed
    private static SerialPort s_serial;

    private static List<Serial> s_instances = new List<Serial>();



    // Use this for initialization
    void Start () {
        Debug.Log("----------------------------------test.UART");

        for (int i = 0; i < num; i++)
        {
            Debug.Log("*******************************************" + i.ToString());
            Delay(100);
        }
        ListCOMPorts();
        
        Debug.Log("open: ");
        port.Open();
        port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived); // Begin communications  
        
        Debug.Log("open.ok ");



       
    }
	
	// Update is called once per frame
	void Update () {
        //StartCoroutine(ReadSerialLoop());


        //Debug.Log(data);




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


    //uart - Honza Do.

    private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        string dataPort = port.ReadExisting();
        data = data + dataPort;

        /* if (dataPort.Length == 5)
         {
             //string data = port.ReadExisting();
             //richTextBox1.AppendText(data + "=" + data.Length);
             string dataNum = "";

             data = dataPort.Substring(1, 3);
             Debug.Log(data);


         }
         else
         {
             if (zapisuj == true)
             {
                 if (dataPort == ",")
                 {

                     data = "";
                     zapisuj = false;
                     return;
                 }
                 data = data + dataPort;

             }

             if (dataPort == "*") zapisuj = true;
         }*/




}