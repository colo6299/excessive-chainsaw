using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class FishingPole : Grabbable
{
    bool firstPress;
    public Transform bobber;
    public Transform bobberPlaceholder;
    public bool flipBob;
    public bool returnBob;
    public Vector3 bobberPosition;
    public float multiplier = 1f;
    public Rigidbody rigidBob;
    private Vector3 bobberVelocity;
    public Bobber bobberFr;
    public SteamVR_Action_Single pullTrigger;
    public float cooldownTime = 5f;
    public bool cooldown;
    private float storedCooldown;
    // Start is called before the first frame update
    public override void Trigger(bool triggerState)
    {
        
    }
    private void Start()
    {
        storedCooldown = cooldownTime;
    }
    public override void TriggerUp()
    {
        if (!cooldown)
        {
            ReleaseBob();
        }
        if(returnBob == true)
        {
            bobberFr.yank = false;
        }
    }
    public override void TriggerDown()
    {
        
    }
    void ReleaseBob()
    {
        rigidBob.useGravity = true;
        rigidBob.velocity = bobberVelocity;
        returnBob = true;
        bobberFr.BobberRecall();
    }
    public void ReturnFunction()
    {
        cooldown = true;
        rigidBob.isKinematic = false;
        rigidBob.useGravity = false;
        returnBob = false;
    }
    private void FixedUpdate()
    {
        if (!returnBob)
        {
            bobber.position = bobberPlaceholder.position;
        }
        bobberPosition = bobber.position;
    }
    private void Update()
    {
        if(cooldown == true)
        {
            cooldownTime -= Time.deltaTime;
            if(cooldownTime <= 0f)
            {
                cooldown = false;
                cooldownTime = storedCooldown;
            }
        }
        if (pullTrigger.axis >= 0.5f)
        {
            bobberFr.yank = true;
        }
        bobberVelocity = ((bobberPlaceholder.position - bobberPosition) / Time.fixedDeltaTime) * multiplier;
        bobberPosition = bobber.position;
        //Debug.Log(bobberVelocity);
    }
}
