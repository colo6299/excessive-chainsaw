using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The subclass of BaseUnit corresponding to allied units. 
/// </summary>
public class AlliedUnit : BaseUnit
{
    public static AlliedUnit[] alliedUnits = new AlliedUnit[WorldOrderProperties.maxAlliedUnits]; //hard cap on allied units. Based? Based on what?\
    public static int allyCount = 0;
    private int id = -1;
    private void Awake()
    {
        if(id == -1)
        {
            id = allyCount;
            alliedUnits[id] = this;
            allyCount++;
        }
    }

    public int GetID()
    {
        return id;
    }

    //setup order states to allow for order cancellation
    public void MoveTo(Vector3 position)
    {
        
    }

    public void LookTowards(Vector3 position)
    {

    }

    public void ThrowGrenade(Vector3 position)
    {

    }
    public void OpenFire(bool fire)
    {

    }
}
