using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetherCheck : MonoBehaviour
{
    public float returnDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(TetherDistance.minimumDistance >= returnDistance)
        {
            TetherDistance.soldier.Teleport();
        }
        else
        {
            TetherDistance.soldier = null;
        }
    }
}
