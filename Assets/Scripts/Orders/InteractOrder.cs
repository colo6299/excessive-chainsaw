using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractOrder : MoveOrder
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    protected override void SendOrder(AlliedUnit alliedUnit)
    {
        alliedUnit.Interact(storedPos);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
