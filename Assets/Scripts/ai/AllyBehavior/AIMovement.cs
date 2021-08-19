using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : AIClass
{
    public float stopDistance = 1f;
    public float rotateSens = 1.5f;
    public bool fireCommand;
    public Vector3 positionTarget;
    public bool moving;
    public bool rotating;
    public bool interacting;
    public Collider interactor;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        interactor.enabled = false;
    }

    public virtual void MoveOrder(Vector3 position)
    {
        moving = true;
        agent.SetDestination(position);
        positionTarget = position; 
    }
    public virtual void FinishMove() 
    {
        agent.ResetPath();
        //agent.SetDestination(transform.position);
        moving = false;
    }
   public virtual void RotationOrder(Vector3 position)
    {
        rotating = true;
        Vector3 direction = (position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotateSens);
    }
    public virtual void InteractOrder(Vector3 position)
    {
        moving = false;
        interacting = true;
        agent.SetDestination(position);
        interactor.enabled = true;
    }
    public virtual void FinishInteracting()
    {
        agent.ResetPath();
        interactor.enabled = false;
        interacting = false;
    }
    public virtual void FireOrder(bool fireStatus)
    {
        combat.firing = fireStatus;
    }
    // Update is called once per frame
    protected override void Update()
    {
        if (moving == true)
        {
            float distance = Vector3.Distance(positionTarget, transform.position);
            if (distance <= stopDistance)
            {
                FinishMove();
            }
        }
        if(moving == false)
        {
            FinishMove();
        }
        if(rotating == false)
        {
            transform.rotation = transform.rotation;
        }
        if(interacting == false)
        {
            FinishInteracting();
        }
        rotating = false;
        moving = false;
        interacting = false;
    }
}
