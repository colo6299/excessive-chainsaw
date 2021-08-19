using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Pretends to be a different selectable object, overrides GetSelectable.
/// </summary>
public class Mimic : Selectable
{
    protected Selectable mimickedObject;
    public string unitName;
    public Text proName;
    public void SetProperties(Selectable mimicTarget)
    {
        //cant get this to work so ima hack it
        mimickedObject = mimicTarget;
    }
    void Start()
    {
        Debug.Log("TriflingSlimyDontTryme");
        proName.text = unitName;
        //mimickedObject = WorldOrderProperties.selectorPrime.selectedObject;
    }

    public override Selectable GetSelectable()
    {
        return mimickedObject;
    }

}
