using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionCoordinator : MonoBehaviour
{
    /// <summary>
    /// An array of all bone transforms in an avatar. See PositionCoordinator file for detailed documentation.
    /// </summary>
    public Transform[] boneArray = new Transform[57];
    /*https://gyazo.com/3de689bafae96bd89df136492cc46ddb good luck lol
    * and, yes, I am about to use a screenshot in documentation     */

    private Quaternion[] recentBones;


    public void CloneBones()
    {

    }

    /// <summary>
    /// Returns a fresh snapshot of bone data. Optionally updates the recentbones array (default true).
    /// </summary>
    /// <param name="update"></param>
    /// <returns></returns>
    public BoneData GetFreshBones(bool update=true)
    {
        BoneData boneClone = new BoneData();
        int i = 0;
        foreach(Transform bone in boneArray)
        {
            boneClone.bones[i] = bone.rotation;
            i++;
        }
        if(update) { recentBones = boneClone.bones; } //preeeetty sure it's a copy, if there's a cursed bug you know where to look...
        return boneClone;
    }

    public BoneData GetRecentBones()
    {
        return new BoneData(recentBones);
    }
}
