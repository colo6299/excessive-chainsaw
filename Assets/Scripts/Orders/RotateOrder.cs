using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOrder : PositionOrder
{
    // Start is called before the first frame update
    protected override void SendOrder(AlliedUnit alliedUnit)
    {
        alliedUnit.LookTowards(storedPos);
    }
}
