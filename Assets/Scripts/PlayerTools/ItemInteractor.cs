using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ItemInteractor : MonoBehaviour
{
    public SteamVR_Action_Boolean grab;
    public bool clenched;
    public SteamVR_Action_Boolean clickTrigger;
    public bool click;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (grab.GetState(SteamVR_Input_Sources.Any) == true)
        {
            clenched = true;
        }
        else
        {
            clenched = false;
        }
        if (clickTrigger.GetStateDown(SteamVR_Input_Sources.Any) == true)
        {
            click = true;
        }
        if(clickTrigger.GetStateUp(SteamVR_Input_Sources.Any) == true)
        {
            click = false;
        }
    }
}
