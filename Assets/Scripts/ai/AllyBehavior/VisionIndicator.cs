using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionIndicator : MonoBehaviour
{
    public Material spotted;
    public Material attacking;
    public Material chasing;
    private Renderer thisObject;
    public AIClass unit;
    // Start is called before the first frame update
    void Start()
    {
        thisObject = transform.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(unit.visionList.Count >= 1 & unit.target == null)
        {
            thisObject.enabled = true;
            thisObject.material = spotted;
            return;
        }
        if(unit.visionList.Count >= 1 & unit.target != null)
        {
            thisObject.enabled = true;
            thisObject.material = attacking;
        }
        else
        {
            thisObject.enabled = false;
        }
    }
}
