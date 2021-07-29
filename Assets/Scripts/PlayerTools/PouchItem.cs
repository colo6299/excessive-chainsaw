using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouchItem : Tool
{
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0)
        {
            SearchForController();
            CalculateInteraction();
        }
    }
}
