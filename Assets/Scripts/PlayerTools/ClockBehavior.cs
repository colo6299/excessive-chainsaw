using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ClockBehavior : Tool
{
    public SteamVR_Action_Boolean rewindButton;
    public bool switchTime;
    //public ItemInteractor interact;
    public Collider storedCollider;
    public LayerMask interactLayer;

    //remember to set collide with hand only layer
    void Start()
    {
        
    }
    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (interact.clenched == true & switchTime == false)
        {
            StopTime();
            switchTime = true;
            return;
        }

    }
    public override void OnTriggerExit(Collider other)
    {
        switchTime = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(interact != null)
        {
            RewindTime();
        }
        if(interact == null)
        {
            Timeline.reversing = false;
        }
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
        if(interact != null)
        {
            if (transform.position.magnitude - interact.transform.position.magnitude >= interactRadius)
            {
                hasLeft = true;
            }
            if (transform.position.magnitude - interact.transform.position.magnitude <= interactRadius & hasLeft == true & interact.clenched == true & interact.click == true)
            {
                StartTime();
            }
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
    void RewindTime()
    {
        if(Timeline.reversing == true)
        {
            Time.timeScale = 1; 
        }
        Timeline.reversing = rewindButton.GetState(SteamVR_Input_Sources.Any);
    }
}
