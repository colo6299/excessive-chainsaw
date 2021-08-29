using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyBehavior : AIMovement
{
    public AllyHolder allieHolder;
    private bool dead;
    private AlliedUnit allyScript;
    // Start is called before the first frame update
    
    protected override void Start()
    {
        base.Start();
        StartCoroutine(SearchForTarget());
        allieHolder.allies.Add(transform);
    }
    void Awake()
    {
        allyScript = transform.GetComponent<AlliedUnit>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (target != null)
        {
            AttackTarget();
        }
        if (target == null)
        {
            combat.firing = false;
        }
        if (!dead & healthPool <= 0)
        {
            Dying();
        }
    }
    public void Dying()
    {
        allyScript.KillUnit();
        dead = true;
    }
}


