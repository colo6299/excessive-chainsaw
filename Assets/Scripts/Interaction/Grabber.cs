using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Grabber : MonoBehaviour
{
    public Transform grabPos;

    private Grabbable grabbedObject;

    public SteamVR_Action_Boolean grab;
    public SteamVR_Action_Boolean click;

    private Grabbable touchedGrabbable;
    private float minSqrDistance; //a fast way to store the ~distance of the closest gabbable

    private void Update()
    {
        if (grab.GetState(SteamVR_Input_Sources.Any))
        {
            Grab();
        }
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
        grabbedObject.Trigger(click.GetState(SteamVR_Input_Sources.Any));
    }

    private Grabbable GetGrabItem()
    {
        if(touchedGrabbable == null)
        {
            Debug.Log("No grabbable found.");
            return null;
        }
        else
        {
            return touchedGrabbable;
        }
    }

    void OnTriggerStay(Collider other)
    {
        float squareDistance = (other.transform.position - transform.position).sqrMagnitude; //finds the x, y, z distances by subtracting, then finds the 
        if (touchedGrabbable == null)                                                       //(squared) length of that vector, meaning distance between start points
        {
            Debug.Log(other.name + " selected as first grabbable.");
            SelectOther(other, squareDistance);
        }
        if (squareDistance < minSqrDistance)
        {
            Debug.Log(other.name + " selected as minumum distance grabbable.");
            if (other.gameObject != touchedGrabbable.gameObject) //is the closest different from the previous different object?
            {                                                    //(purely for performance... probably)
                SelectOther(other, squareDistance);
            }
        }

        void SelectOther(Collider other, float sqDistance) //Selects the.. thing. ya know. 
        {
            touchedGrabbable = other.GetComponent<Grabbable>();
            minSqrDistance = sqDistance;
        }
    }
}
