using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDestroy : MonoBehaviour
{
    public float delaySeconds;
    public float destroySeconds;
    public GameObject prefab;
    private float fireTime;

    private void Awake()
    {
        delaySeconds += Random.Range(-1f, 1f);
        if (delaySeconds < 0.1f)
        {
            delaySeconds = 0.1f;
        }
    }
    private void Update()
    {
        float timeToFire = fireTime + delaySeconds;
        if (Time.time > timeToFire)
        {
            fireTime = Time.time;
            GameObject spawnedObject = Instantiate(prefab, transform.position, transform.rotation, transform);
            Destroy(spawnedObject, destroySeconds);
        }
    }
}
