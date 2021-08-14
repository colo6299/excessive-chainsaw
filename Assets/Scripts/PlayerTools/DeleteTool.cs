using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTool : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.GetComponentInParent<Grabbable>().deleteThisObject);  
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
