using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class sheath : Grabbable
{
    public SteamVR_Action_Vector2 flickPosition;
    public Grabber sheathGrabber;
    private bool flickReady;
    public bool flickFiring;
    public Transform swordHolder;
    public Transform sword;
    public Transform swordAnimation;
    public bool finishedDraw;
    public float flickDistance;
    public float drawTime = 0.5f;
    public float speed;
    bool runOnce = false;
    public TurnManager tm;
    public float finishDistance = -0.44f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        sheathGrabber = other.GetComponent<Grabber>();
    }
    private void OnTriggerExit(Collider other)
    {
        sheathGrabber = null;
    }
    // Update is called once per frame
    void Update()
    {
        if(sheathGrabber != null)
        {
            if (sheathGrabber.grabbedObject != null)
            {
                if (flickPosition.axis.y <= -0.6f)
                {
                    flickReady = true;
                }
                if (flickReady == true)
                {
                    if (flickPosition.axis.y > 0.4f)
                    {
                        flickFiring = true;
                    }
                }

            }
        }
        if(sheathGrabber == null)
        {
            ResetBools();
        }
        if (!finishedDraw)
        {
            SheathedPosition();
        }
        if (flickFiring == true & finishedDraw == false)
        {
            //swordAnimation.parent = null;
            //swordAnimation.gameObject.GetComponent<Animator>().enabled = true;
            
        }
        //Debug.Log(swordAnimation.position.y);
        if(swordAnimation.localPosition.y <= finishDistance)
        {
            finishedDraw = true;
            swordAnimation.parent = null;
        }
        if(tm.endTurn == true)
        {
            sheathGrabber = null;
        }
    }
    private void ResetBools()
    {
        flickReady = false;
        //flickFiring = false;
    }
    private void SheathedPosition()
    {
        sword.position = swordHolder.position;
        sword.eulerAngles = new Vector3(swordHolder.eulerAngles.x, swordHolder.eulerAngles.y, swordHolder.eulerAngles.z - 180);
        Vector3 currentPosition = swordAnimation.position;
        swordAnimation.localPosition = new Vector3(0, swordAnimation.localPosition.y, 0);
        swordAnimation.localEulerAngles = new Vector3(0, 0, 0);
    }
    private void DrawingPosition()
    {
 
    }
}
