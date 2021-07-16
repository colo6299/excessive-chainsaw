using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAbilities : MonoBehaviour
{
    public Rigidbody grenade;
    public Transform targetPoint;
    public Transform throwOrigin;
    public bool throwGrenade;
    private Vector3 throwVelocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
    }
    public void ThrowGrenade(Vector3 position)
    {
        throwVelocity = CalculateVelocity(position, throwOrigin.position, 1.5f);
        throwOrigin.rotation = Quaternion.LookRotation(throwVelocity);
        Rigidbody obj = Instantiate(grenade, throwOrigin.position, Quaternion.identity);
        obj.velocity = throwVelocity;
        throwGrenade = false;
    }
    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time) 
    {
        Vector3 distance = target - origin;
        Vector3 distance_x_z = distance;
        distance_x_z.Normalize();
        distance_x_z.y = 0;

        float sy = distance.y;
        float sxz = distance.magnitude;

        float Vxz = sxz / time;
        float Vy = sy / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

        Vector3 result = distance_x_z * Vxz;
        result.y = Vy;

        return result;
    }

}
