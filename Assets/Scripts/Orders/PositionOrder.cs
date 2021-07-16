using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionOrder : Order
{
    protected Vector3 storedPos;
    public override void Trigger(bool triggerState)
    {
        if (!triggerState) 
        {
            Debug.DrawRay(transform.position, transform.forward, Color.red);
            return; 
        }
        //Raycast position and store it
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, 100f, 1 << 0);
        Debug.DrawRay(transform.position, transform.forward, Color.green);
        storedPos = hit.point;
    }
}
