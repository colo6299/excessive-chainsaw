using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetherDistance : MonoBehaviour
{
    public static float minimumDistance;
    public static TetherDistance soldier;
    public static Transform player;
    public Transform tetherLocation;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float Distance = (player.position - transform.position).magnitude;
        if(soldier == null)
        {
            minimumDistance = Distance;
            soldier = this;
        }
        if (Distance < minimumDistance)
        {
            minimumDistance = Distance;
            soldier = this;
        }
    }
    public void Teleport()
    {
        player.position = tetherLocation.position;
    }
}
