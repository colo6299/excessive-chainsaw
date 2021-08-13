using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : allyInteractable
{
    public allyInteractable generator;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public override void ActivateObject(Collider Other)
    {
        if(generator.activate == true)
        {
            transform.gameObject.SetActive(false);
        }
        else
        {
            return;
        }
    }

}
