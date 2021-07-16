using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerControl : MonoBehaviour
{
    public SteamVR_Action_Boolean teleportPress;
    public SteamVR_Action_Boolean timeStopPress;
    public bool switchTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (teleportPress.GetStateDown(SteamVR_Input_Sources.Any))
        {
            PlayerTeleport();
        }
        if (timeStopPress.GetStateDown(SteamVR_Input_Sources.Any))
        {
            StopTime();
        }
    }
    void PlayerTeleport()
    {
        Selector.mainSelectorTool.GetSelected().GetComponent<TetherDistance>().Teleport();
    }
    void StopTime()
    {
        if(switchTime == false)
        {
            Time.timeScale = 0;
            switchTime = true;
            return;
        }
        if(switchTime == true)
        {
            Time.timeScale = 1;
            switchTime = false;
            return;
        }
        
    }
}
