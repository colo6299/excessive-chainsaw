using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyBehavior : MonoBehaviour
{
    public AllyHolder allieHolder;
    // Start is called before the first frame update
    void Start()
    {
        allieHolder.allies.Add(transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
