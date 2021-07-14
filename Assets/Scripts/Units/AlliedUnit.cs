using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The subclass of BaseUnit corresponding to allied units. 
/// </summary>
public class AlliedUnit : BaseUnit
{
    public static AlliedUnit[] alliedUnits = new AlliedUnit[32]; //hard cap on allied units. Based? Based on what?\
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
}
