using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    public GameObject deleteThisObject;   //added this to use with the deletetool
    public virtual void Trigger(bool triggerState) //a function that can be overwritten, but is guaranteed to be on any grabbable object.
    {

    }

    public virtual void TriggerUp()
    {

    }

    public virtual void TriggerDown()
    {

    }
}
