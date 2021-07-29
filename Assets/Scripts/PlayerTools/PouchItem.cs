using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouchItem : Tool
{
   public Transform spawnedItem = null;
   private bool flip;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0)
        {
            SearchForController();
            CalculateInteraction();
        }
        if(interact != null)
        {
            if (interact.click == false)
            {
                flip = false;
            }
            if (interact.click == true)
            {
                SpawnItem();
            }
        }
    }
    public void SpawnItem()
    {
        if (!flip)
        {
            Instantiate(spawnedItem, interact.transform.position, interact.transform.rotation);
            flip = true;
        }
        else return;
    }

}
