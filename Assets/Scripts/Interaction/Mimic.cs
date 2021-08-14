using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Pretends to be a different selectable object, overrides GetSelectable.
/// </summary>
public class Mimic : Selectable
{
    protected Selectable mimickedObject;
    public void SetProperties(Selectable mimicTarget)
    {
        //cant get this to work so ima hack it
        mimickedObject = mimicTarget;
    }
    private void Start()
    {
        //mimickedObject = WorldOrderProperties.selectorPrime.selectedObject;
    }

    public override Selectable GetSelectable()
    {
        return mimickedObject;
    }

}
