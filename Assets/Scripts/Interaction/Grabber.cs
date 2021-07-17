using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Grabber : MonoBehaviour
{
    public Transform grabPos;
    public Collider selfCollider;

    public bool debugGrabOut;
    public bool debugGrabIn;
    public bool debugTriggerIn;

    private Grabbable grabbedObject;

    public SteamVR_Action_Boolean grab;
    public SteamVR_Action_Boolean click;

    public Grabbable touchedGrabbable;
    private float minSqrDistance; //a fast way to store the ~distance of the closest gabbable

    private void FixedUpdate()
    {
        if (grab.GetState(SteamVR_Input_Sources.Any) || debugGrabIn)
        {
            Grab();
        }
        else
        {
            grabbedObject = null;
        }
        selfCollider.enabled = !(grab.GetState(SteamVR_Input_Sources.Any) || debugGrabIn);
        touchedGrabbable = null;
    }

    private void Grab()
    {
        if(grabbedObject == null)
        {
            grabbedObject = GetGrabItem();
            if(grabbedObject == null)
            {
                return;
            }
        }
        grabbedObject.transform.position = grabPos.position;
        grabbedObject.transform.rotation = grabPos.rotation;
        grabbedObject.Trigger(click.GetState(SteamVR_Input_Sources.Any) || debugTriggerIn);
        if (click.GetStateUp(SteamVR_Input_Sources.Any)) { grabbedObject.TriggerUp(); }
    }

    private Grabbable GetGrabItem()
    {
        if(touchedGrabbable == null)
        {
            //Debug.Log("No grabbable found.");
            return null;
        }
        else
        {
            return touchedGrabbable;
        }
    }

    void OnTriggerStay(Collider other)
    {
        //Debug.LogError("???");
        float squareDistance = (other.transform.position - transform.position).sqrMagnitude; //finds the x, y, z distances by subtracting, then finds the 
        if (touchedGrabbable == null)                                                       //(squared) length of that vector, meaning distance between start points
        {
            //Debug.Log(other.name + " selected as first grabbable.");
            SelectOther(other, squareDistance);
        }
        if (squareDistance < minSqrDistance)
        {
            //Debug.Log(other.name + " selected as minumum distance grabbable.");
            if (other.gameObject != touchedGrabbable.gameObject) //is the closest different from the previous different object?
            {                                                    //(purely for performance... probably)
                SelectOther(other, squareDistance);
            }
        }

        void SelectOther(Collider other, float sqDistance) //Selects the.. thing. ya know. 
        {
            touchedGrabbable = other.attachedRigidbody.gameObject.GetComponent<Grabbable>();
            //Debug.Log(touchedGrabbable.name);
            minSqrDistance = sqDistance;
        }
    }
}
