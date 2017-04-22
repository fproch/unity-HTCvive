using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Jan Komínek @09.03.2017 - First version
// Jan Komínek @16.03.2017 - Added wrapping script. Now text will not overspan the object it's attached to.

// enumeration of text alignment possibilities for manual choice in the inspector
public enum TF
{ UpperLeft, UpperCenter, UpperRight, MiddleLeft, MiddleCenter, MiddleRight, LowerLeft, LowerCenter, LowerRight }

public class oeTextScreen : MonoBehaviour {

    public Font newFont;
    public TF textFormat;
    public bool alignment;

    private bool showPopUp; //show/hide text input window
    private string textInput; //temporary storage for text input from user
    private GameObject textScreen;
    private Color objectColor; //control indicator of color change of the parent object
    
    void Start ()
    {
        showPopUp = false;
        objectColor = transform.GetComponent<Renderer>().material.color;

        textScreen = new GameObject("TextScreen");
        textScreen.AddComponent<TextMesh>();

        textScreen.transform.parent = transform;

        //Choosing text alignment
        alignText();
        
        textScreen.transform.rotation = transform.rotation;
        //textScreen.transform.localScale = new Vector3(0.02f, 0.02f, 1.0f);
        textScreen.GetComponent<TextMesh>().characterSize = 0.01f * gameObject.transform.localScale.x;   // This is to ensure
        textScreen.GetComponent<TextMesh>().fontSize = 20;                                              // that the text is not blurry
        // textScreen.GetComponent<TextMesh>().font = Resources.Load("ALGER.ttf") as Font; //Have yet to find why font doesn't load properly on a non-manual font change
                                                                                           // note: component <Font Material> ?
        textScreen.GetComponent<TextMesh>().font.material.color = InvertColor(objectColor); // sets color opposite to that of the parent object, 
                                                                                            // but allows hue modification through .font.color

        textScreen.GetComponent<TextMesh>().text = ">\toeZERO\t<\npreAlpha Build\n\tverze 17";

        textScreen.AddComponent<TextWrap>(); //script for inputing text wrapped to the objects dimensions
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.T)) // Show text input window
            openTextInput();

        if(Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            if (showPopUp)
                enterText();
            else
                openTextInput();
        }

        if (newFont != null && textScreen.GetComponent<TextMesh>().font != newFont)
        {
            textScreen.GetComponent<TextMesh>().font = newFont;
            Debug.Log("New font: " + textScreen.GetComponent<TextMesh>().font);
        }

        if (transform.GetComponent<Renderer>().material.color != objectColor)
        {
            objectColor = transform.GetComponent<Renderer>().material.color;
            textScreen.GetComponent<TextMesh>().font.material.color = InvertColor(objectColor);
        }

        // alignText(); //remnants of testing the positioning of text alignment
    }

    // creation of the input window
    void OnGUI()
    { //note: I'm unsure if this doesn't cause memory leak due to Rects being created over and over again...
        if (showPopUp)
            GUI.Window(0, new Rect((Screen.width / 2) - 150, (Screen.height / 2) - 75 , 300, 50), ShowGUI, "Type message to show: ");
    }

    // content of the Input window - an input textfield and OK button
    void ShowGUI(int windowID)
    {
        textInput = GUI.TextField(new Rect(10, 20, 245, 20), textInput, 200);

        if (GUI.Button(new Rect(259, 22, 30, 16), "OK"))
            enterText();

    }

    // initiation of the input window
    void openTextInput()
    {
        textInput = "Input text";
        showPopUp = true;
    }

    // takes input from input window and if aplicable, adds it, wrapped, to the screen
    void enterText()
    {
        if(!textInput.Equals("")) //if input window has no text, no need to add an empty line
        {
            if (!textScreen.GetComponent<TextMesh>().text.Equals("") && !textScreen.GetComponent<TextMesh>().text.EndsWith(System.Environment.NewLine))
                        textScreen.GetComponent<TextMesh>().text += "\n";

            textScreen.GetComponent<TextWrap>().addWrappedText(textInput);
        }
        showPopUp = false; //Hide text input window
    }

    // returns a color on the other end of color spectrum
    Color InvertColor(Color oldColor)
    {
        return new Color(1.0f - oldColor.r, 1.0f - oldColor.g, 1.0f - oldColor.b);
    }

    // aligns and positions text based on choise from public variable chosen in inspector
    void alignText()
    {
        switch (textFormat)
        {
            case TF.UpperLeft:
                //center position of the text object
                textScreen.transform.position = transform.position
                                            - transform.right * transform.localScale.x * 0.48f
                                            + transform.up * transform.localScale.y * 0.48f;
                //position of the text on the object
                textScreen.GetComponent<TextMesh>().anchor = TextAnchor.UpperLeft;
                //horizontal alignment of the text
                textScreen.GetComponent<TextMesh>().alignment = TextAlignment.Left;

                break;

            case TF.UpperCenter:
                textScreen.transform.position = transform.position
                                            + transform.up * transform.localScale.y * 0.48f;

                textScreen.GetComponent<TextMesh>().anchor = TextAnchor.UpperCenter;
                if (alignment)
                    textScreen.GetComponent<TextMesh>().alignment = TextAlignment.Center;
                else
                    textScreen.GetComponent<TextMesh>().alignment = TextAlignment.Left;
                break;

            case TF.UpperRight:
                textScreen.transform.position = transform.position
                                            + transform.right * transform.localScale.x * 0.48f
                                            + transform.up * transform.localScale.y * 0.48f;

                textScreen.GetComponent<TextMesh>().anchor = TextAnchor.UpperRight;

                if (alignment)
                    textScreen.GetComponent<TextMesh>().alignment = TextAlignment.Right;
                else
                    textScreen.GetComponent<TextMesh>().alignment = TextAlignment.Left;

                break;

            case TF.MiddleLeft:
                textScreen.transform.position = transform.position
                                            - transform.right * transform.localScale.x * 0.48f;

                textScreen.GetComponent<TextMesh>().anchor = TextAnchor.MiddleLeft;

                textScreen.GetComponent<TextMesh>().alignment = TextAlignment.Left;

                break;

            case TF.MiddleCenter:
                textScreen.transform.position = transform.position;

                textScreen.GetComponent<TextMesh>().anchor = TextAnchor.MiddleCenter;

                if (alignment)
                    textScreen.GetComponent<TextMesh>().alignment = TextAlignment.Center;
                else
                    textScreen.GetComponent<TextMesh>().alignment = TextAlignment.Left;

                break;

            case TF.MiddleRight:
                textScreen.transform.position = transform.position
                                            + transform.right * transform.localScale.x * 0.48f;

                textScreen.GetComponent<TextMesh>().anchor = TextAnchor.MiddleRight;

                if (alignment)
                    textScreen.GetComponent<TextMesh>().alignment = TextAlignment.Right;
                else
                    textScreen.GetComponent<TextMesh>().alignment = TextAlignment.Left;

                break;

            case TF.LowerLeft:
                textScreen.transform.position = transform.position
                                            - transform.right * transform.localScale.x * 0.48f
                                            - transform.up * transform.localScale.y * 0.48f;

                textScreen.GetComponent<TextMesh>().anchor = TextAnchor.LowerLeft;

                textScreen.GetComponent<TextMesh>().alignment = TextAlignment.Left;

                break;

            case TF.LowerCenter:
                textScreen.transform.position = transform.position
                                            - transform.up * transform.localScale.y * 0.48f;

                textScreen.GetComponent<TextMesh>().anchor = TextAnchor.LowerCenter;

                if (alignment)
                    textScreen.GetComponent<TextMesh>().alignment = TextAlignment.Center;
                else
                    textScreen.GetComponent<TextMesh>().alignment = TextAlignment.Left;

                break;

            case TF.LowerRight:
                textScreen.transform.position = transform.position
                                            + transform.right * transform.localScale.x * 0.48f
                                            - transform.up * transform.localScale.y * 0.48f;

                textScreen.GetComponent<TextMesh>().anchor = TextAnchor.LowerRight;

                if (alignment)
                    textScreen.GetComponent<TextMesh>().alignment = TextAlignment.Right;
                else
                    textScreen.GetComponent<TextMesh>().alignment = TextAlignment.Left;

                break;

            default:
                Debug.Log("Text alignment err404!");
                break;
        }
    }
}
