using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueDamageable : MonoBehaviour
{
    // Start is called before the first frame update
    public AIClass topLevel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DamageThis(float number)
    {
        topLevel.healthPool -= number;
    }
}
