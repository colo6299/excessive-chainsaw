using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{

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
