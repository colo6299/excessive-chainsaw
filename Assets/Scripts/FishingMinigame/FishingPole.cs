using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    public override void Trigger(bool triggerState)
    {
        
    }
    public override void TriggerUp()
    {
        ReleaseBob();
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
        bobberVelocity = ((bobberPlaceholder.position - bobberPosition) / Time.fixedDeltaTime) * multiplier;
        bobberPosition = bobber.position;
        //Debug.Log(bobberVelocity);
    }
}
