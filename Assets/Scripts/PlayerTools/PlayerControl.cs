using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerControl : MonoBehaviour
{
    public SteamVR_Action_Boolean teleportPress;
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
    }
    void PlayerTeleport()
    {
        Selector.mainSelectorTool.GetSelected().GetComponent<TetherDistance>().Teleport();
    }
}
