using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicInitializer : MonoBehaviour
{
    //public Selectable targetSelectable;

    private void Start()
    {
        //changed target selectable to selectedobject but idk how public statics work so lets find out
        //maybe not the *most* performant, but ehhh
        //gameObject.GetComponent<Mimic>().SetProperties(WorldOrderProperties.selectorPrime.selectedObject);
    }
}
