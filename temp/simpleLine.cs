using UnityEngine;
using UnityEditor;
using System.Collections;

public class simpleLine : MonoBehaviour
{	

	private Material mat;

	void Start()
	{
		// Vykreslenie priamok
		// asset priradit na prazdny GameObject
		// Do uvahy pripadaju len metody LineRenderer a OpenGl (mozno dalsie ak rozbehame),
		// ostatne sa vykresluje len v Scene view


		// s pouzitim LineRenderer
		DrawRendererLine (Vector3.zero, new Vector3 (100, 0, 0), Color.red);

		// s pouzitim OpenGL
		// vid asset glLine.cs

		// s pouzitim Graphics
		// opat by malo byt rychlejsie ako LineRenderer
		//Graphics.???
		// nenasiel som ziadny kod, ktory to riesi, len odporucania a nefunkcne referencie

		// dalsi sposob je pouzitim cylindrickej meshe, pre kruhovy a krajsie zobrazenie priamky
		// http://gamedev.stackexchange.com/questions/96964/how-to-correctly-draw-a-line-in-unity

		// ----------------------------------------------------------------------------------
		// Ostatne metody funguje len pri zobrazeni v Scene view!

		// s pouzitim Gizmos
		// vykresluje sa len pri metodach OnDrawGizmos alebo OnDrawGizmosSelected
		// https://docs.unity3d.com/ScriptReference/Gizmos.html
		// priamka sa zobrazuje len v Scene view! a musi byt oznaceny GameObject!
		// vola sa v metode OnDrawGizmosSelected, vid kod

		// s pouzitim Handles
		// takisto sa vykresluje len v Scene view, navyse treba sa viac pohrat s vykreslenim,
		// nefungovalo takto jednoducho, viac info:
		// https://docs.unity3d.com/ScriptReference/Handles.html
		// https://docs.unity3d.com/ScriptReference/Handles.DrawLine.html
		//Handles.color = Color.cyan;
		//Handles.DrawLine (Vector3.zero, new Vector3 (100, 100, 0));

		// s pouzitim Debug
		// priamka sa zobrazuje len v Scene view!
		Debug.DrawLine(Vector3.zero, new Vector3 (100, 0, 100), Color.yellow, float.MaxValue);
	}

	void DrawRendererLine (Vector3 start, Vector3 end, Color color, float width = 0.02f)
	{
		GameObject myLine = new GameObject ();
		myLine.transform.position = start;
		myLine.AddComponent<LineRenderer> ();
		LineRenderer lr = myLine.GetComponent<LineRenderer> ();
		lr.material = new Material (Shader.Find ("Particles/Alpha Blended Premultiply"));
		lr.SetColors (color, color);
		lr.SetWidth (width, width);
		lr.SetPosition (0, start);
		lr.SetPosition (1, end);
		//GameObject.Destroy (myLine, duration);
	}
		
	void OnDrawGizmosSelected() 
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawLine (Vector3.zero, new Vector3 (0, 0, 100));
	}
}