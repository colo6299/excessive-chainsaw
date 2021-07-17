using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingHole : MonoBehaviour
{
    public Bobber bobber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        bobber = other.gameObject.GetComponent<Bobber>();
        bobber.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        bobber.recall = false;
    }
}
