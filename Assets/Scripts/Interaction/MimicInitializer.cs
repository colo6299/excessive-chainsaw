using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicInitializer : MonoBehaviour
{
    public Selectable targetSelectable;

    private void Start()
    {
        //maybe not the *most* performant, but ehhh
        gameObject.GetComponent<Mimic>().SetProperties(targetSelectable);
    }
}
