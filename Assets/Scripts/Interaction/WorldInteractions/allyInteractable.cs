using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allyInteractable : MonoBehaviour
{
    public bool activate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void ActivateObject(Collider other)
    {
        activate = true;
    }
    public void OnTriggerEnter(Collider other)
    {
        ActivateObject(other);
    }
}
