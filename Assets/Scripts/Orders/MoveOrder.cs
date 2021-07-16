using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOrder : PositionOrder
{
    public override void Trigger(bool triggerState)
    {
        base.Trigger(triggerState);

    }

    protected override void SendOrder(AlliedUnit alliedUnit)
    {
        alliedUnit.MoveTo(storedPos);
    }
}
