using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform target;
    public Transform target2;
    public float stopDistance = 1f;
    public float rotateSens = 1.5f;
    public bool rotateCommand;
    public bool moveCommand;
    public AICombat AICombat;
    public bool fireCommand;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        AICombat = GetComponent<AICombat>();
    }

    public void MoveOrder(Vector3 position)
    {
        agent.SetDestination(position);
    }
    void FinishMove() 
    {
        agent.ResetPath();
    }
   public void RotationOrder(Vector3 position)
    {
        Vector3 direction = (position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotateSens);
    }
    public void FireOrder(bool fireStatus)
    {
        AICombat.firing = fireStatus;
    }
    // Update is called once per frame
    void Update()
    {
        /*if (fireCommand == true)
        {
            FireOrder();
        }
        if (!fireCommand)
        {
            AICombat.firing = false;
        }
        if (rotateCommand == true)
        {
            RotationOrder();
        }
        if (moveCommand == true)
        {
            rotateCommand = false;
            MoveOrder();
            moveCommand = false;
        }*/
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= stopDistance)
        {
            FinishMove();
        }
    }
}
