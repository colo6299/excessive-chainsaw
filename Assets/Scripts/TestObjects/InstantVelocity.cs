using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantVelocity : MonoBehaviour
{
    public float speed;
    private Rigidbody rbody;
    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
        rbody.velocity = transform.forward * speed;
    }
}
