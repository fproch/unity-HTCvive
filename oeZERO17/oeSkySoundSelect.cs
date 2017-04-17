using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class oeSkySoundSelect : MonoBehaviour
{

    GameObject goCudl1;
    GameObject oeAudio0;
    GameObject oeAudio1;
    GameObject oeAudio2;
    GameObject oeAudio3;
    GameObject oeAudio4;
    GameObject oeAudio5;

    GameObject oeBezier;
    GameObject oeWall1;
    GameObject Octopus1;
    Light oeLight1;
    Light oeLightA;

    TextMesh textObject1;
    TextMesh textObject2A;
    TextMesh textObject2B;
    public string selObj = "nic";


    //string mat1 = Application.dataPath + "/_sky/Skybox.mat";

    // Use this for initialization
    void Start()
    {
        //Debug.Log("oeLightSelect.Start()"); 
        //Debug.Log(mat1);
        //oeLightA = GameObject.Find("SpotlightA").GetComponent<Light>(); //oeLight1
        oeLight1 = GameObject.Find("oeLight1").GetComponent<Light>();
        oeAudio0 = GameObject.Find("oeAudio0");
        oeAudio1 = GameObject.Find("oeAudio1");
        oeAudio2 = GameObject.Find("oeAudio2");
        oeAudio3 = GameObject.Find("oeAudio3");
        oeAudio4 = GameObject.Find("oeAudio4");
        //oeBezier = GameObject.Find("oeBezier");
        //oeWall1 = GameObject.Find("oeWall1");
        //Octopus1 = GameObject.Find("Octopus1");

        oeAudioMute();
        oeAudio0.active = true;
        //oeAudio5.active = false;
        //oeBezier.active = false;

        //AudioSource source = gameObject.GetComponent<AudioSource>();
        //source.clip = Resources.Load("gravit.mp3", typeof(AudioClip)) as AudioClip;
        //source.Play();


        //goCudl1 = GameObject.Find("cudl1");
        ///textObject = GameObject.Find("label2").GetComponent<TextMesh>();
        //textObject1 = GameObject.Find("textINFO1A").GetComponent<TextMesh>();
        //textObject2A = GameObject.Find("textINFO2A").GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //============================================================================================================
    void oeAudioMute()
    {
        oeAudio0.active = false;
        oeAudio1.active = false;
        oeAudio2.active = false;
        oeAudio3.active = false;
        oeAudio4.active = false;
    }
    

    void OnCollisionEnter(Collision colSel)
    {
        //Debug.Log();
        //if (col.gameObject.name == "prop_powerCube")        {            Destroy(col.gameObject);        }
        //https://unity3d.com/learn/tutorials/topics/physics/detecting-collisions-oncollisionenter
        //rigid body
        selObj = colSel.collider.name;
        Debug.Log("oeSelector-Light: " + selObj);
        ///textObject.text = selObj;
        ///textObject2A.text = "sceneSelector: " + selObj;
        //Debug.Log();

        if (selObj == "sel1") //red
        {
            //oeLightA.enabled = true; oeLight1.enabled = true;
            //Octopus1.active = true;
            Material newMat = Resources.Load("OverCast2Sky", typeof(Material)) as Material;
            RenderSettings.skybox = newMat;
            oeAudioMute();
            oeAudio1.active = true;

        }
        if (selObj == "sel2") //ora
        {
            //Material levelMat = new Material(Application.dataPath + "/Materials/chec" + levelCount + ".mat");

            //Texture texture = Resources.Load("oe-bw") as Texture;
            //Material levelMat = new Material(mat1);
            //Shader sdr = Resources.Load("Diffuse"); renderer.sharedMaterial.shader = sdr;

            //var levelMat = new Material(Shader.Find("SimpleUnlitGradient/Shaders/imageShader"));
            //RenderSettings.skybox = levelMat;
            Material newMat = Resources.Load("SkyboxFire", typeof(Material)) as Material;
            RenderSettings.skybox = newMat;
            oeAudioMute();
            oeAudio2.active = true;


        }
        //SceneManager.LoadScene("oePracovna");
        // if (selObj == "sel4") SceneManager.LoadScene("oeData");
        if (selObj == "sel3") //yel
        {
            Material newMat = Resources.Load("SkyMorning", typeof(Material)) as Material;
            RenderSettings.skybox = newMat;
            oeAudioMute();
            oeAudio3.active = true;
           
        }

        if (selObj == "sel4") //gre
        {
            Material newMat = Resources.Load("PurpleNebula", typeof(Material)) as Material;
            RenderSettings.skybox = newMat;
            oeAudioMute();
            oeAudio4.active = true;
        }


        if (selObj == "sel5") //blu
        {
            Material newMat = Resources.Load("SkyNight", typeof(Material)) as Material;
            RenderSettings.skybox = newMat;
            oeAudioMute();
            oeAudio0.active = true;
        }
        //============================================================================================================   
    }
}


//************
