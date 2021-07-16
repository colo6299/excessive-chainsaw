using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderMimic : Mimic
{
    private GameObject recentOrderObject;
    private Order recentOrder;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject != recentOrderObject)
        {
            if (other.tag == "Order")
            {
                recentOrderObject = other.gameObject;
                recentOrder = other.gameObject.GetComponent<Order>();
            }
            else
            {
                return;
            }
        }
        recentOrder.RegisterSelf(GetSelectable().SelectableID()); 
    }
}
