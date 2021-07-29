using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIClass : MonoBehaviour
{
    public AICombat combat;
    public NavMeshAgent agent;
    public List<Transform> visionList;
    public EnemyHolder enemyH;
    public AllyHolder allyHolder;
    public float tickRate;
    private float leastDistance;
    public Transform target;
    public float radius = 7f;
    public float angle = 100f;
    public float aggroRange;
    public LayerMask targetMask;
    public LayerMask obstructionMask;
    public float rotateSense;
    public Transform gun;
    public float combatReflex = 0.23f;
    public bool test;
    public bool enemyTeam;
    public bool alliedTeam;

    public bool canSeePlayer;
    // Start is called before the first frame update
    void Start()
    {
        combat = transform.GetComponent<AICombat>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void Patrol()
    {

    }
    public IEnumerator SearchForTarget()
    {
        while (true)
        {
            target = null!;
            if (alliedTeam)
            {
                CalculateVisionForAlly();
                CalculateDistanceForAlly();
            }
            if (enemyTeam)
            {
                CalculateVisionForEnemy();
                CalculateDistanceForEnemy();
            }            
            yield return new WaitForSeconds(tickRate);
        }
    }
    public virtual void CalculateDistanceForAlly()
    {
        foreach (Transform enemy in visionList)
        {
            float distance = (transform.position - enemy.position).magnitude;
            if ((target == null) & distance < aggroRange)
            {
                leastDistance = distance;
                target = enemy;
            }
            else if (distance < leastDistance & distance < aggroRange)
            {
                leastDistance = distance;
                target = enemy;
            }
        }
    }
    public virtual void CalculateDistanceForEnemy()
    {
        foreach (Transform ally in visionList)
        {
            float distance = (transform.position - ally.position).magnitude;
            if ((target == null) & distance < aggroRange)
            {
                leastDistance = distance;
                target = ally;
            }
            else if (distance < leastDistance & distance < aggroRange)
            {
                leastDistance = distance;
                target = ally;
            }
        }
    }
    public virtual void CalculateVisionForEnemy()
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
    public virtual void CalculateVisionForAlly()
    {
        visionList.Clear();
        foreach (Transform enemy in enemyH.enemies)
        {
            Vector3 directionToTarget = (enemy.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, enemy.position);
                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    visionList.Add(enemy);
                }
                else
                    visionList.Remove(enemy);
            }
            else
                visionList.Remove(enemy);
        }
    }
   public virtual void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotateSense);
    }
   public virtual void AttackTarget()
    {
        FaceTarget();
        AimGun();
        //Don't like the way the firing is set up but w/e it'll stay for now
        combat.firing = true;
    }
   public virtual void ChaseTarget()
    {
        agent.SetDestination(target.position);
    }
   public virtual void AimGun()
    {
        Vector3 direction = (target.position - gun.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        gun.rotation = Quaternion.Slerp(gun.rotation, lookRotation, Time.deltaTime * rotateSense);
    }
}
