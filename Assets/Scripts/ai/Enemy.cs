using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
    public NavMeshAgent agent;
    public LayerMask targetMask;
    public LayerMask obstructionMask;
    public float rotateSense;
    public Transform gun;
    public AICombat combat;
    public float combatReflex = 0.23f;
    public bool test;

    public bool canSeePlayer;
    // Start is called before the first frame update
    void Start()
    {
        combat = transform.GetComponent<AICombat>();
        agent = GetComponent<NavMeshAgent>();
        enemyH.enemies.Add(transform);
        StartCoroutine(SearchForTarget());
    }

    // Update is called once per frame
    void Update()
    {
       if(test == true)
        {
            AttackPlayer();
        }
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotateSense);
    }
    void AimGun()
    {
        Vector3 direction = (target.position - gun.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        gun.rotation = Quaternion.Slerp(gun.rotation, lookRotation, Time.deltaTime * rotateSense);
    }
    void ChasePlayer()
    {
        agent.SetDestination(target.position);
    }
    void AttackPlayer()
    {
        FaceTarget();
        AimGun();
        combat.firing = true;
    }
    void Patrol()
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
