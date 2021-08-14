using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MimicSpawner : MonoBehaviour
{
    public Selector selector;
    public SteamVR_Action_Boolean spawnMimic;
    public Transform mimic;
    public Transform playerController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(selector.somethingSelected == true)
        {
            if (spawnMimic.GetStateDown(SteamVR_Input_Sources.Any))
            {
                SpawnTheMimic();
            }
        }
    }
    public void SpawnTheMimic()
    {
        Instantiate(mimic, transform.position, transform.rotation, playerController);
    }
}
