using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FishGenerator : MonoBehaviour
{
    public TextAsset fishlist;
    private string theFileAsString;
    private List<string> eachLine;
    public string fishName;
    // Start is called before the first frame update
    void Start()
    {
        theFileAsString = fishlist.text;

        eachLine = new List<string>();
        eachLine.AddRange(theFileAsString.Split("\n"[0]));
        //size 1 The
        //2-5 size small
        //6-9 size medium
        //10-13 size large
        //15-18 small fish
        //19-22 med fish
        //23-26 large fish
        //27 KingFish
        GenerateFish();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void GenerateFish()
    {
        int sizeNumber = Random.Range(1, 14);
        int rand = Random.Range(1, 11);
        if (sizeNumber == 1)
        {
            fishName = eachLine[0] + " " + eachLine[26];
            return;
        }
        if(sizeNumber > 1 & sizeNumber < 6)
        {           
            if(rand < 8)
            {
                fishName = eachLine[sizeNumber - 1] + " " + eachLine[Random.Range(16, 19)];
                return;
            }
            else 
            {
                fishName = eachLine[sizeNumber -1] + " " + eachLine[Random.Range(20, 26)];
            }
        }
        if(sizeNumber > 5 & sizeNumber < 10)
        {
            if(rand < 7)
            {
                fishName = eachLine[sizeNumber - 1] + " " + eachLine[Random.Range(20, 23)];
                return;
            }
            else
            {
                fishName = eachLine[sizeNumber - 1] + " " + eachLine[Random.Range(16, 27)];
            }

        }
        if (sizeNumber > 9 & sizeNumber < 14)
        {
            if(rand < 8)
            {
                fishName = eachLine[sizeNumber - 1] + " " + eachLine[Random.Range(24, 27)];
                return;
            }
            else
            {
                fishName = eachLine[sizeNumber - 1] + " " + eachLine[Random.Range(16, 27)];
            }
        }
        
    }
}
