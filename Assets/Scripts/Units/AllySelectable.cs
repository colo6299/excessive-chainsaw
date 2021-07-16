using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllySelectable : Selectable
{
    protected AlliedUnit unit;

    private void Awake()
    {
        unit = GetComponent<AlliedUnit>();
    }
    public override int SelectableID()
    {
        return unit.GetID();
    }
}
