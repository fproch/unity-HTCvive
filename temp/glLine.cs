using UnityEngine;
using System.Collections;

public class glLine : MonoBehaviour
{	

	// s pouzitim OpenGL
	// asset priradit na kameru v scene
	// malo by byt rychlejsie ako LineRenderer
	// na Macu trva spracovanie velmi dlho, podla Google by malo ist na vykonnejsom PC ok
	//DrawGLline (Vector3.zero, new Vector3 (0, 100, 0), Color.green);

	void DrawGLline (Vector3 start, Vector3 end, Color color)
	{
		GL.PushMatrix();
		GL.LoadOrtho();
		GL.Begin(GL.LINES);
		GL.Color(color);
		GL.Vertex(start);
		GL.Vertex(end);
		GL.End();
		GL.PopMatrix();
	}

	// pri OpenGL metode by sa mal volat tento event - funguje to len v nom
	// !!! tento asset musí byť priradený ku kamere !!!
	// https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnPostRender.html
	void OnPostRender() {
		DrawGLline (Vector3.zero, new Vector3 (0, 100, 0), Color.green);
	}

}