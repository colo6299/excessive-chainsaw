using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionOrder : Order
{
    protected Vector3 storedPos;
    public Transform rayPos;
    public override void Trigger(bool triggerState)
    {
        if (!triggerState) 
        {
            Debug.DrawRay(rayPos.position, rayPos.forward, Color.red);
            return; 
        }
        //Raycast position and store it
        RaycastHit hit;
        Physics.Raycast(rayPos.position, rayPos.forward, out hit, 100f, 1 << 0);
        Debug.DrawRay(hit.point, hit.normal, Color.green);
        Debug.DrawRay(rayPos.position, rayPos.forward, Color.green);
        storedPos = hit.point;
    }
}
