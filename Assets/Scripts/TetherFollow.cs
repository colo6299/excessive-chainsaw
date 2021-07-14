using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TetherFollow : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform followThis;
    public float followDistance = 1f;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(followThis.position);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(followThis.position, transform.position);
        if (distance <= followDistance)
        {
            agent.SetDestination(agent.transform.position);
        }
        else
        {
            agent.SetDestination(followThis.position);
        }
    }
}
