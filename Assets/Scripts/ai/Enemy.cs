using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : AIMovement
{
    public bool dead;
    // Start is called before the first frame update
   protected override void Start()
    {
        enemyH.enemies.Add(transform);
        StartCoroutine(SearchForTarget());
    }

    // Update is called once per frame
   protected override void Update()
    {
      if(target != null)
      {
        AttackTarget();
      }
      if(target == null)
      {
        combat.firing = false;
      }
      if(!dead & healthPool <= 0)
        {
            Dying();
        }
    }     
    public void Dying()
    {
        enemyH.enemies.Remove(transform);
        dead = true;
    }
}
