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
                recentOrder = other.attachedRigidbody.GetComponent<Order>();
            }
            else
            {
                return;
            }
        }
        Debug.Log(other.name + "Deklt");
        recentOrder.RegisterSelf(GetSelectable().SelectableID()); 
    }
}
