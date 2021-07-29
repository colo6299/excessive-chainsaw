using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldOrderProperties : MonoBehaviour
{
    public static int maxAlliedUnits = 32;
    /// <summary>
    /// 0 is left 1 is right
    /// </summary>
    public static Transform[] Controllers = new Transform[2];

    private void Awake()
    {
        Controllers[0] = GameObject.FindGameObjectWithTag("LeftController").transform;
        Controllers[1] = GameObject.FindGameObjectWithTag("RightController").transform;
    }
}
