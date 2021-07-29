using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyBehavior : AIMovement
{
    public AllyHolder allieHolder;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SearchForTarget());
        allieHolder.allies.Add(transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            AttackTarget();
        }
        if (target == null)
        {
            combat.firing = false;
        }
    }
}


