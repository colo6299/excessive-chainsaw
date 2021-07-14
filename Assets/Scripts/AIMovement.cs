using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform target;
    public float stopDistance = 1f;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        MoveOrder();
    }

    void MoveOrder()
    {
        agent.SetDestination(target.position);
    }
    void FinishMove() 
    {
        agent.SetDestination(agent.transform.position);
    }
    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= stopDistance)
        {
            FinishMove();
        }
    }
}
