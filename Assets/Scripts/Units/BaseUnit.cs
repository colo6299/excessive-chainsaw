using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : Damagable
{
    public virtual Transform UnitPosition()
    {
        return transform;
    }
}
