using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyHolder enemyH;
    public AllyHolder allyHolder;
    public float tickRate;
    private float leastDistance;
    public Transform target;
    public float radius = 7f;
    public float angle = 100f;
    public float aggroRange;
    public List<Transform> visionList;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;
    // Start is called before the first frame update
    void Start()
    {
        enemyH.enemies.Add(transform);
        StartCoroutine(SearchForTarget());
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    IEnumerator SearchForTarget()
    {
        while (true)
        {
            target = null!;
            CalculateVision();
            CalculateDistance();
            yield return new WaitForSeconds(tickRate);
        }
    }
        
    void CalculateDistance()
    {
        foreach (Transform ally in visionList)
        {
            float distance = (transform.position - ally.position).magnitude;
            if((target == null) & distance < aggroRange)
            {      
                    leastDistance = distance;
                    target = ally;
            }
            else if(distance < leastDistance & distance < aggroRange)
            {
                    leastDistance = distance;
                    target = ally;
            }
        }
    }
    void CalculateVision()
    {
        visionList.Clear();
        foreach (Transform ally in allyHolder.allies)
        {
            Vector3 directionToTarget = (ally.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, ally.position);
                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    visionList.Add(ally);
                }
                else
                    visionList.Remove(ally);
            }
            else
                visionList.Remove(ally);
        }
    }
}
