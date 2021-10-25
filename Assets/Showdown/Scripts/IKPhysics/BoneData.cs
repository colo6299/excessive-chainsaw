using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BoneData
{
    public Quaternion[] bones;


    public BoneData()
    {
        bones = new Quaternion[57];
    }
    public BoneData(Quaternion[] boneArray)
    {
        bones = boneArray;
    }
}
