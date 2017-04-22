using UnityEngine;
using System.Collections;

// Initial script found at http://answers.unity3d.com/questions/223906/textmesh-wordwrap.html
// All claims go to shopguy  http://answers.unity3d.com/users/81406/shopguy.html who made that script
// Script modified to suit the needs

// Jan Komínek @16.03.2017 - First version


[RequireComponent(typeof(TextMesh))]
public class TextWrap : MonoBehaviour
{
    public float MaxWidth;

    private TextMesh TheMesh;

    void Start()
    {
        TheMesh = GetComponent<TextMesh>();

        MaxWidth = 0.48f * transform.parent.localScale.x;
    }
    
    // 
    string BreakPartIfNeeded(string part)
    {
        string saveText = TheMesh.text;
        TheMesh.text = part;

        if (TheMesh.GetComponent<Renderer>().bounds.extents.x > MaxWidth)
        {
            string remaining = part;
            part = "";

            while (true)
            {
                int len;
                for (len = 2; len <= remaining.Length; len++)
                {
                    TheMesh.text = remaining.Substring(0, len);
                    if (TheMesh.GetComponent<Renderer>().bounds.extents.x > MaxWidth)
                    {
                        len--;
                        break;
                    }
                }
                if (len >= remaining.Length)
                {
                    part += remaining;
                    break;
                }
                part += remaining.Substring(0, len) + System.Environment.NewLine;
                remaining = remaining.Substring(len);
            }

            part = part.TrimEnd();
        }

        TheMesh.text = saveText;

        return part;
    }

    // segments input string into lines to fit into set width
    public void addWrappedText(string UnwrappedText)
    {
        if (MaxWidth == 0)
        {
            TheMesh.text = UnwrappedText;
            return;
        }

        string builder = "";
        string text = UnwrappedText;

        string[] parts = text.Split(' ');

        for (int i = 0; i < parts.Length; i++)
        {
            string part = BreakPartIfNeeded(parts[i]);
            TheMesh.text += part + " ";

            if (TheMesh.GetComponent<Renderer>().bounds.extents.x > MaxWidth)
            {
                TheMesh.text = builder.TrimEnd() + System.Environment.NewLine + part + " ";
            }
            builder = TheMesh.text;
        }
    }
}