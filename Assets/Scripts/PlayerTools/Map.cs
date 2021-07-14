using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    /// <summary>
    /// the size of the handheld map.
    /// </summary>
    public float mapSize;
    
    /// <summary>
    /// the area the map is displaying.
    /// </summary>
    public float mapScope;
    void Start()
    {
        foreach(AlliedUnit ally in AlliedUnit.alliedUnits)
        {
            if(ally != null)
            {

            }
        }
    }

    void Update()
    {
        
    }
}
