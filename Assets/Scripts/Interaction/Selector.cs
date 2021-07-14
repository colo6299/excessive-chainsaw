using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Selector manages the selection tool.
/// </summary>
public class Selector : MonoBehaviour 
{
    private Selectable touchedSelectable;
    private float minSqrDistance; //a fast way to store the ~distance of the closest selectable
    /// <summary>
    /// When called, returns the object the selector is most happy with selecting. This is the thing you call to get the item/unit you're pointing at
    /// </summary>
    /// <returns></returns>
    public Selectable Select()
    {
        if(touchedSelectable == null)
        {
            //If there is no collectable touching the collider, 
            //raycast to search for a valid selectable.
        }
        else
        {
            return touchedSelectable;
        }
        Debug.Log("No selectable found.");
        return null;
    }

    void OnTriggerStay(Collider other)
    {
        float squareDistance = (other.transform.position - transform.position).sqrMagnitude; //finds the x, y, z distances by subtracting, then finds the 
        if (touchedSelectable == null)                                                       //(squared) length of that vector, meaning distance between start points
        {
            Debug.Log(other.name + " selected as first selectable.");
            SelectOther(other, squareDistance);
        }
        if (squareDistance < minSqrDistance)
        {
            Debug.Log(other.name + " selected as minumum distance selectable.");
            if(other.gameObject != touchedSelectable.gameObject) //is the closest different from the previous different object?
            {
                SelectOther(other, squareDistance);
            }
        }

        void SelectOther(Collider other, float sqDistance) //Selects the.. thing. ya know. 
        {
            touchedSelectable = other.GetComponent<Selectable>();
            minSqrDistance = sqDistance;
        }
    }
}