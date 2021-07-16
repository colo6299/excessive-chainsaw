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
        mimickedObject = mimicTarget;
    }

    public override Selectable GetSelectable()
    {
        return mimickedObject;
    }

}
