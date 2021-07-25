using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingHole : MonoBehaviour
{
    public Bobber bobber;
    public float waitTime = 5f;
    public float catchWindow = 2f;
    public bool missedFish;
    public bool caughtFish;
    public bool fishing;
    private float storedWait;
    private float storedCatchWindow;
    public FishGenerator fg;
    // Start is called before the first frame update
    void Start()
    {
        storedWait = waitTime;
        storedCatchWindow = catchWindow;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        waitTime = storedWait;
        catchWindow = storedCatchWindow;
        missedFish = false;
        caughtFish = false;
        fishing = false;
        bobber = other.gameObject.GetComponent<Bobber>();
        bobber.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        bobber.recall = false;
    }
    private void OnTriggerStay(Collider other)
    {
        FishProtocol();
    }
    void FishProtocol()
    {
        waitTime -= Time.deltaTime;
        if (waitTime > 0f & bobber.yank == true)
        {
            bobber.recall = true;
            missedFish = true;
            return;
        } 
        if (waitTime <= 0f)
        {
            Vector3 bobberPosition = bobber.transform.position;
            bobber.transform.position = new Vector3 (bobberPosition.x, -0.008f, bobberPosition.z);
            catchWindow -= Time.deltaTime;
            if(bobber.yank == true)
            {
                caughtFish = true;
                bobber.recall = true;
                fg.GenerateFish();
                return;
            }
            if(catchWindow <= 0)
            {
                if (caughtFish == false)
                {
                    bobber.transform.position = bobberPosition;
                    missedFish = true;
                    bobber.recall = true;
                }
                else return;
            }
        }
    }
}
