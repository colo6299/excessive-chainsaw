using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiBulletPusher : MonoBehaviour
{
    public ParticleSystem hitExplosion;
    public ParticleSystem explosion;
    public float velocity;
    public float drag;
    public float damage;
    private float velocityY;
    private Vector3 worldVelocity;
    public float gravity = 9.81f;
    public bool payload;
    public LayerMask targetLayer;
    public LayerMask obstructionLayer;
    // Start is called before the first frame update
    void Start()
    {
        worldVelocity = transform.forward * velocity;
        calculateBullet();
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void calculateBullet()
    {
        
        velocityY -= gravity * Time.deltaTime;
        Vector3 currentVelocity = worldVelocity + new Vector3(0,velocityY,0);
        Vector3 newPos = transform.position + (currentVelocity * Time.deltaTime);
        RaycastHit hit;
        Physics.Raycast(transform.position, currentVelocity, out hit, (currentVelocity.magnitude * Time.deltaTime), targetLayer + obstructionLayer, QueryTriggerInteraction.Ignore); //add bitshift in partenthesnes
        if(hit.collider != null)
        {
            if(hit.collider.gameObject.tag == "damagable")
            {
                hit.collider.gameObject.GetComponent<TrueDamageable>().DamageThis(damage);
            }
            transform.position = hit.point;
            if(payload)
            {
                Instantiate(hitExplosion,transform.position,Quaternion.identity);
            }
            Destroy(gameObject);
        }
        transform.position = newPos;
    }
    void FixedUpdate()
    {
        calculateBullet();
    }
}
