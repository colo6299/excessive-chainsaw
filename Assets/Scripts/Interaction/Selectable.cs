using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    /// <summary>
    /// Whenever you have a selectable and are unsure if it's a mimic, call this to get the original
    /// </summary>
    /// <returns></returns>
    public virtual Selectable GetSelectable()
    {
        return this;
    }
}
