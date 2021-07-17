using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobber : MonoBehaviour
{
    public bool recall = true;
    public FishingPole rod;
    public float searchTime = 5f;
    public bool primedRecall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(primedRecall & recall == true)
        {
            rod.ReturnFunction();
            primedRecall = false;
            recall = false;
        }
    }
    public void BobberRecall()
    {
        StartCoroutine(SearchForPuddle());
    }
    IEnumerator SearchForPuddle()
    {
        yield return new WaitForSeconds(searchTime);
        if (recall == false)
        {
            primedRecall = true;
        }
        else if (recall == true)
        {
            rod.ReturnFunction();
        } 
    }
}
