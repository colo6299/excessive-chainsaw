using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TurnManager : MonoBehaviour
{
    public bool endTurn;
    public bool startTurn;
    public GameObject leftHandPos;
    public GameObject rightHandPos;
    public GameObject playerLeftHand;
    public GameObject playerRightHand;
    public GameObject rightOffset;
    public GameObject leftOffset;
    private bool runOnce;
    private float startTime;
    public float travelTime = 5f;
    private Transform startPositionRight;
    private Transform endPositionRight;
    private float journeyLength;
    private float distCovered;
    private Quaternion startRotationRight;
    private Quaternion endRotationRight;
    public SteamVR_Action_Single trigger;
    public bool triggerUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(trigger.axis < 0.2)
        {
            triggerUp = true;
        }
        TurnSwitcher();
        if (endTurn == true)
        {
            if (!runOnce)
            {
                SetPositions();
            }
        }
        if(startTurn == true)
        {
            runOnce = false;
        }
    }
    void SetPositions()
    {
        startPositionRight = rightHandPos.transform;
        endPositionRight = playerRightHand.transform;

        startRotationRight = rightHandPos.transform.rotation;
        endRotationRight = playerRightHand.transform.rotation;

        journeyLength = travelTime;
        distCovered = Time.deltaTime + distCovered;
        float fractionOfJourney = distCovered / journeyLength;
        rightHandPos.transform.position = Vector3.Lerp(startPositionRight.position, endPositionRight.position, fractionOfJourney);
        //leftHandPos.transform.position = playerLeftHand.transform.position;
        //leftHandPos.transform.rotation = playerLeftHand.transform.rotation;
        //rightHandPos.transform.position = playerRightHand.transform.position;
        rightHandPos.transform.rotation = Quaternion.Lerp(startRotationRight, endRotationRight, fractionOfJourney);
        // rightHandPos.transform.rotation = playerRightHand.transform.rotation;
        if (fractionOfJourney >= 1)
        {
            runOnce = true;
            endTurn = false;
            startTurn = true;
        }
    }
    void TurnSwitcher()
    {
        /*if(endTurn == true)
        {
            if(trigger.axis >= 0.7f & triggerUp == true)
            {
                endTurn = false;
                startTurn = true;
                triggerUp = false;
            }
        }*/
        if(startTurn == true)
        {
            if(trigger.axis > 0.7f & triggerUp == true)
            {
                distCovered = 0;
                endTurn = true;
                startTurn = false;
                triggerUp = false;
            }
        }
    }
}
