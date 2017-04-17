using UnityEngine;
using System.Collections;

public class oeMesh : MonoBehaviour
{


    public Vector3[] Vertices;
    public Vector2[] UV;
    public int[] Triangles;

    void MeshSetup()
    {
        Vertices = new Vector3[] { new Vector3(-1, 0, 1), new Vector3(1, 0, 1), new Vector3(1, 0, -1), new Vector3(-1, 0, -1) };
        UV = new Vector2[] { new Vector2(0, 256), new Vector2(256, 256), new Vector2(256, 0), new Vector2(0, 0) };
        Triangles = new int[] { 0, 1, 2, 0, 2, 3 };

    }


    void Start()
    {
         MeshSetup();
         Mesh stuff = new Mesh();
         gameObject.AddComponent<MeshFilter>().mesh = stuff;
         stuff.vertices = Vertices;
         stuff.triangles = Triangles;
         stuff.uv = UV;

       /* var m : Mesh = new Mesh();
        m.name = "Scripted_Plane_New_Mesh";
        m.vertices = [Vector3(-size, -size, 0.01), Vector3(size, -size, 0.01), Vector3(size, size, 0.01), Vector3(-size, size, 0.01)];
        m.uv = [Vector2(0, 0), Vector2(0, 1), Vector2(1, 1), Vector2(1, 0)];
        m.triangles = [0, 1, 2, 0, 2, 3];
        m.RecalculateNormals();
        var obj : GameObject = new GameObject("New_Plane_Fom_Script", MeshRenderer, MeshFilter, MeshCollider);
        obj.GetComponent(MeshFilter).mesh = m;*/


    }
}