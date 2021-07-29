using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ToolHolder : MonoBehaviour
{
    public Transform selectorSpot;
    public Transform attackOrderSpot;
    public Transform moveOrderSpot;
    public Transform rotateOrderSpot;
    public Transform grenadeOrderSpot;
    public Transform selector;
    public Transform attackOrder;
    public Transform moveOrder;
    public Transform rotateOrder;
    public Transform grenadeOrder;
    public Transform clockPosition;
    public Transform headPos;
    public float offsetHeight;
    // Start is called before the first frame update
    void Start()
    {
        headPos = SteamVR_Render.Top().head;
    }

    // Update is called once per frame
    void Update()
    {
        VestRotation();
        VestPosition();
    }
    void VestRotation()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, headPos.eulerAngles.y, transform.eulerAngles.z);
    }
    void VestPosition()
    {
        transform.position = new Vector3(headPos.position.x, headPos.position.y - offsetHeight, headPos.position.z);
    }
}
