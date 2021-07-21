using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgradeFollower : MonoBehaviour
{
    private Rigidbody rbody;

    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        transform.forward = rbody.velocity.normalized;
    }
}
