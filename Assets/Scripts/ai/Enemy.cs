using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : AIMovement
{
    // Start is called before the first frame update
    void Start()
    {
        enemyH.enemies.Add(transform);
        StartCoroutine(SearchForTarget());
    }

    // Update is called once per frame
    void Update()
    {
      if(target != null)
      {
        AttackTarget();
      }
      if(target == null)
      {
        combat.firing = false;
      }
    }     
    
}
