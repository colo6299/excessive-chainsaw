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
    // Start is called before the first frame update
    void Start()
    {
        
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
        moving = false;
    }
   public virtual void RotationOrder(Vector3 position)
    {
        Vector3 direction = (position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotateSens);
    }
    public virtual void FireOrder(bool fireStatus)
    {
        combat.firing = fireStatus;
    }
    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            float distance = Vector3.Distance(positionTarget, transform.position);
            if (distance <= stopDistance)
            {
                FinishMove();
            }
        }
        
    }
}
