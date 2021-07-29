using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    public ItemInteractor interact;
    public bool hasLeft;
    public float interactRadius;
    protected float squaredRadius;
    private float minimumDistance;
    // Start is called before the first frame update
    void Start()
    {
        squaredRadius = interactRadius * interactRadius;
    }
    public virtual void OnTriggerEnter(Collider other)
    {
        hasLeft = false;
        interact = other.GetComponent<ItemInteractor>();
    }
    public virtual void OnTriggerExit(Collider other)
    {
        hasLeft = true;
        interact = null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
    public virtual void CalculateInteraction()
    {
        if(interact != null)
        {
            if(transform.position.magnitude - interact.transform.position.magnitude >= interactRadius)
            {
                hasLeft = true;
            }
            else
            {
                hasLeft = false;
            }
        }
    }
    public virtual void SearchForController()
    {
        foreach(Transform controller in WorldOrderProperties.Controllers)
        {
            float calculatedDistance = (controller.position - transform.position).sqrMagnitude;
            if(calculatedDistance <= squaredRadius)
            {
                interact = controller.GetComponent<ItemInteractor>();
                hasLeft = false;
                return;
            }
            /*if(calculatedDistance <= squaredRadius & calculatedDistance <= minimumDistance)
            {
                minimumDistance = calculatedDistance;
                interact = controller.GetComponent<ItemInteractor>();
                return;
            }*/
            else
            {
                hasLeft = true;
                interact = null;
            }
            
        }
    }
}
