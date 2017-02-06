namespace VRTK.Examples
{
    using UnityEngine;

    public class oeLaser : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("oeLaser()");

        if (GetComponent<VRTK_SimplePointer>() == null)
        {
            Debug.LogError("VRTK_ControllerPointerEvents_ListenerExample is required to be attached to a Controller that has the VRTK_SimplePointer script attached to it");
            return;
        }

        //Setup controller event listeners
        GetComponent<VRTK_SimplePointer>().DestinationMarkerEnter += new DestinationMarkerEventHandler(DoPointerIn);
        GetComponent<VRTK_SimplePointer>().DestinationMarkerExit += new DestinationMarkerEventHandler(DoPointerOut);
        GetComponent<VRTK_SimplePointer>().DestinationMarkerSet += new DestinationMarkerEventHandler(DoPointerDestinationSet);
    }

    private void DebugLogger(uint index, string action, Transform target, RaycastHit raycastHit, float distance, Vector3 tipPosition)
    {
        string targetName = (target ? target.name : "<NO VALID TARGET>");
        string colliderName = (raycastHit.collider ? raycastHit.collider.name : "<NO VALID COLLIDER>");
        Debug.Log("Controller on index '" + index + "' is " + action + " at a distance of " + distance + " on object named [" + targetName + "] on the collider named [" + colliderName + "] - the pointer tip position is/was: " + tipPosition);
    }

    private void DoPointerIn(object sender, DestinationMarkerEventArgs e)
    {
        DebugLogger(e.controllerIndex, "POINTER IN", e.target, e.raycastHit, e.distance, e.destinationPosition);
        CollisionAction(e);
    }

    private void DoPointerOut(object sender, DestinationMarkerEventArgs e)
    {
        DebugLogger(e.controllerIndex, "POINTER OUT", e.target, e.raycastHit, e.distance, e.destinationPosition);
        CollisionAction(e);
    }

    private void DoPointerDestinationSet(object sender, DestinationMarkerEventArgs e)
    {
        DebugLogger(e.controllerIndex, "POINTER DESTINATION", e.target, e.raycastHit, e.distance, e.destinationPosition);
    }

    private void CollisionAction(DestinationMarkerEventArgs e)
    {
        GameObject go = GameObject.Find(e.target.name);
        
            if (go.tag == "removable")
            {
                go.GetComponent<ParticleSystem>().Play();
                Destroy(go, 1.5f);
                Debug.Log("Collided obj: " + name + "destroyed");
            }

            //ParticleSystem pe = go.AddComponent<ParticleSystem>();
            //pe.name = "dfdf";
            //Debug.Log(pe.name);
    }
}
}