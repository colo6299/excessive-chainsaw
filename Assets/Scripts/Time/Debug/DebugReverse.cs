using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugReverse : MonoBehaviour
{
    public bool reverse;
    void Update()
    {
        Timeline.reversing = reverse;
    }
}
