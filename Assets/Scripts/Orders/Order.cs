using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : Grabbable
{
    private bool[] unitFlags = new bool[WorldOrderProperties.maxAlliedUnits];

    private void FixedUpdate()
    {
        //Order all units to comply
        for(int id = 0; id < WorldOrderProperties.maxAlliedUnits; id++)
        {
            if (unitFlags[id] == true)
            {
                SendOrder(AlliedUnit.alliedUnits[id]);
            }
        }
        //reset the valid order state every frame;
        unitFlags = new bool[WorldOrderProperties.maxAlliedUnits];
    }

    protected virtual void SendOrder(AlliedUnit alliedUnit)
    {

    }

    private void OnTriggerStay(Collider other)
    {
        //maybe have mimics handle this half
    }
}
