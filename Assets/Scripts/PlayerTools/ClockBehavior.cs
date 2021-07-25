using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockBehavior : MonoBehaviour
{
    public bool switchTime;
    public ItemInteractor interact;
    public Collider storedCollider;
    public LayerMask interactLayer;
    public float interactRadius;
    public bool hasLeft;
   


    //remember to set collide with hand only layer
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        hasLeft = false;
        interact = other.GetComponent<ItemInteractor>();
        if (interact.clenched == true & switchTime == false)
        {
            StopTime();
            switchTime = true;
            return;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        //reverse interaction goes here
    }
    
    private void OnTriggerExit(Collider other)
    {
        switchTime = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (switchTime == true)
        {
            Collider[] accessThis = Physics.OverlapSphere(transform.position, interactRadius, interactLayer);
            Debug.Log(accessThis.Length);
            if (accessThis.Length == 0)
            {
                Debug.Log("detectleaving");
                hasLeft = true;
            }
            if (hasLeft == false)
            {
               return;
            }
            if (hasLeft == true & interact.clenched == true & interact.click == true)
            {
                StartTime();
                storedCollider = null;
                interact = null;
            }
        }*/
        if(transform.position.magnitude - interact.transform.position.magnitude >= interactRadius)
        {
            hasLeft = true;
        }
        if(transform.position.magnitude - interact.transform.position.magnitude <= interactRadius & hasLeft == true & interact.clenched == true & interact.click == true) 
        {
            StartTime();
        }
    }
    void StopTime()
    {
        Time.timeScale = 0;
        switchTime = true;
    }
    void StartTime()
    {
        Time.timeScale = 1;
        switchTime = false;
    }
}
