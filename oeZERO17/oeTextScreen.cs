using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TF
{ Upper_left, Upper, Upper_right, Left, Center, Right, Bottom_left, Bottom, Bottom_right }

public class oeTextScreen : MonoBehaviour {

    public Font newFont;
    public TF textFormat; 

    private bool showPopUp;
    public string textInput = "Input text";
    public float oeCharSize = 0.5f;
    private GameObject textScreen;

    private Color objectColor;
    
    void Start ()
    {
        showPopUp = false;       
        objectColor = transform.GetComponent<Renderer>().material.color;

        textScreen = new GameObject("TextScreen");

        textScreen.transform.parent = transform;

        //Choosing text alignment
        switch(textFormat)
        {
            case TF.Upper_left:
                textScreen.transform.position = transform.position
                                            - transform.right * transform.localScale.x * 0.48f
                                            + transform.up * transform.localScale.y * 0.48f;
                textScreen.GetComponent<TextMesh>().anchor = TextAnchor.UpperLeft;
                break;

            case TF.Upper:
                textScreen.transform.position = transform.position
                                            + transform.up * transform.localScale.y * 0.48f;
                textScreen.GetComponent<TextMesh>().anchor = TextAnchor.UpperCenter;
                break;

            case TF.Upper_right:
                textScreen.transform.position = transform.position
                                            + transform.right * transform.localScale.x * 0.48f
                                            + transform.up * transform.localScale.y * 0.48f;
                textScreen.GetComponent<TextMesh>().anchor = TextAnchor.UpperRight;
                break;

            case TF.Left:
                textScreen.transform.position = transform.position
                                            - transform.right * transform.localScale.x * 0.48f;
                textScreen.GetComponent<TextMesh>().anchor = TextAnchor.MiddleLeft;
                break;

            case TF.Center:
                textScreen.transform.position = transform.position;
                textScreen.GetComponent<TextMesh>().anchor = TextAnchor.MiddleCenter;
                break;

            case TF.Right:
                textScreen.transform.position = transform.position
                                            + transform.right * transform.localScale.x * 0.48f;
                textScreen.GetComponent<TextMesh>().anchor = TextAnchor.MiddleRight;
                break;

            case TF.Bottom_left:
                textScreen.transform.position = transform.position
                                            - transform.right * transform.localScale.x * 0.48f
                                            - transform.up * transform.localScale.y * 0.48f;
                textScreen.GetComponent<TextMesh>().anchor = TextAnchor.LowerLeft;
                break;

            case TF.Bottom:
                textScreen.transform.position = transform.position
                                            - transform.up * transform.localScale.y * 0.48f;
                textScreen.GetComponent<TextMesh>().anchor = TextAnchor.LowerCenter;
                break;

            case TF.Bottom_right:
                textScreen.transform.position = transform.position
                                            + transform.right * transform.localScale.x * 0.48f
                                            - transform.up * transform.localScale.y * 0.48f;
                textScreen.GetComponent<TextMesh>().anchor = TextAnchor.LowerRight;
                break;
        }
        textScreen.transform.rotation = transform.rotation;
        textScreen.transform.localScale = new Vector3(0.02f, 0.02f, 1.0f);

        textScreen.AddComponent<TextMesh>();
        textScreen.GetComponent<TextMesh>().characterSize = oeCharSize * gameObject.transform.localScale.x; // This is to ensure
        textScreen.GetComponent<TextMesh>().fontSize = 20;       // that the text is not blurry

        textScreen.GetComponent<TextMesh>().color = InvertColor(objectColor); //sets color opposite to that of the parent object
            //royal purple = 0.4f, 0.2f, 0.6f

        textScreen.GetComponent<TextMesh>().text = ">\toeZERO\t<\npreAlpha Build\n\tverze 17";
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.T)) // Show text input window
        {
            showPopUp = true;
        }

        if(Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            if(showPopUp)
                enterText();
            else
                showPopUp = true;
        }

        if(transform.GetComponent<Renderer>().material.color != objectColor)
        {
            objectColor = transform.GetComponent<Renderer>().material.color;
            textScreen.GetComponent<TextMesh>().color = InvertColor(objectColor);
        }

        if (newFont != null && textScreen.GetComponent<TextMesh>().font != newFont)
        {
            textScreen.GetComponent<TextMesh>().font = newFont;
            Debug.Log("New font: " + textScreen.GetComponent<TextMesh>().font.name);
        }
    }

    void OnGUI()
    {
        if (showPopUp)
            GUI.Window(0, new Rect((Screen.width / 2) - 150, (Screen.height / 2) - 75 , 300, 50), ShowGUI, "Type message to show: ");
    }

    void ShowGUI(int windowID)
    {
        textInput = GUI.TextField(new Rect(10, 20, 245, 20), textInput, 60);

        if (GUI.Button(new Rect(259, 22, 30, 16), "OK"))
            enterText();

    }
    void enterText()
    {
        if(!textInput.Equals(""))
        {
            if (!textScreen.GetComponent<TextMesh>().text.Equals("") && !textScreen.GetComponent<TextMesh>().text.EndsWith(System.Environment.NewLine))
                        textScreen.GetComponent<TextMesh>().text += "\n";
            textScreen.GetComponent<TextMesh>().text += textInput;
        }
        showPopUp = false; //Hide text input window
        textInput = "Input text";
    }

    Color InvertColor(Color oldColor)
    {
        return new Color(1.0f - oldColor.r, 1.0f - oldColor.g, 1.0f - oldColor.b);
    }
}
