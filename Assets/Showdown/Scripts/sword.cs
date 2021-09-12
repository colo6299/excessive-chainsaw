using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : Grabbable
{
    public Grabber swordGrabber;
    public sheath sheathScript;
    private bool runOnce;
    public float startTime;
    public TurnManager tm;
    private float countUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    { 
        swordGrabber = other.GetComponent<Grabber>();
        if(swordGrabber.grabbedObject != null)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        //gameObject.GetComponent<Rigidbody>().isKinematic = false;
        swordGrabber = null;
    }
    // Update is called once per frame
    void Update()
    {
        if (sheathScript.finishedDraw == true & runOnce == false)
        {
            DrawTimer();
        }
        if(tm.endTurn == true)
        {
            swordGrabber = null;
        }
    }
    void DrawTimer()
    {
        countUp += Time.deltaTime;
        if(countUp >= startTime)
        {
            runOnce = true;
            tm.endTurn = true;  
        }
    }
}
