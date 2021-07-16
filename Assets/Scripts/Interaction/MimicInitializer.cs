using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicInitializer : MonoBehaviour
{
    public Selectable targetSelectable;
    public Mimic mimicToInitialize;

    private void Start()
    {
        mimicToInitialize.SetProperties(targetSelectable);
    }
}
