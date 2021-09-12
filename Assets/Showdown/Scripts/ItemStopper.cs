using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStopper : MonoBehaviour
{
    public TurnManager tm;
    bool freeze;
    bool unfreeze;
    public GameObject leftGrabber;
    public GameObject rightGrabber;
    public Grabbable disableGrab;
    public Collider disableCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (tm.endTurn == true & freeze == false)
        {
            FreezeItems();
        }
        if (tm.startTurn == true & unfreeze == false)
        {
            UnfreezeItems();
        }
    }
    void FreezeItems()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        disableGrab.enabled = false;
        disableCollider.enabled = false;

        leftGrabber.SetActive(false);
        rightGrabber.SetActive(false);

        freeze = true;
        unfreeze = false;
    }
    void UnfreezeItems()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        disableGrab.enabled = true;
        disableCollider.enabled = true;
        freeze = false;
        unfreeze = true;
    }
}
