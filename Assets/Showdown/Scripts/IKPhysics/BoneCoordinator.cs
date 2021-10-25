using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneCoordinator : MonoBehaviour
{
    public BoneCoordinator debugSlaver;
    public bool debugCheckSlave;

    private Quaternion[] recentBones;
    public bool targeting = false;
    public BoneData liveBones;   //only public for testing
    public BoneData targetBones; //only public for testing
    /// <summary>
    /// An array of all bone transforms in an avatar. See PositionCoordinator file for detailed* documentation.
    /// </summary>
    public Transform[] boneArray = new Transform[57];
    //https://gyazo.com/3de689bafae96bd89df136492cc46ddb good luck lol
    //and, yes, I am about to use a screenshot in documentation 

    private void Start()
    {
        liveBones = GetOrUpdateBones();
        targetBones = null;
    }

    private void Update()
    {
        GetOrUpdateBones(liveBones);
        SnapBonesToTarget();
        DebugLoop();
    }

    void DebugLoop()
    {
        if (debugCheckSlave)
        {
            debugCheckSlave = false;
            SetBoneTarget(debugSlaver.liveBones);
        }
    }




    /// <summary>
    /// Sets the target of the bone coordinator. Does not move bones on its own.
    /// </summary>
    /// <param name="target"></param>
    public void SetBoneTarget(BoneData target)
    {
        targetBones = target;
        targeting = true;
    }

    /// <summary>
    /// Unsets the bone targets. Safe to use as a 'stop' for targeting motion. 
    /// </summary>
    public void UnsetBoneTarget()
    {
        targetBones = null;
        targeting = false;
    }

    /// <summary>
    /// A target approach type. Instantly snaps bones to target data.
    /// </summary>
    private void SnapBonesToTarget()
    {
        if (targeting == false) { return; }

        int i = 0;
        foreach(Transform bone in boneArray)
        {
            bone.rotation = targetBones.bones[i]; //shloppaay
            i++;
        }
        GetOrUpdateBones(liveBones);
    }

    /// <summary>
    /// Returns a fresh snapshot of bone data.
    /// If BoneData is inserted, its arrays will be updated with the current object's data.
    /// Optionally updates the recentbones array (default true). 
    /// </summary>
    /// <param name="update"></param>
    /// <returns></returns>
    public BoneData GetOrUpdateBones(BoneData bonesOut = null, bool update=true)
    {
        if(bonesOut == null) { bonesOut = new BoneData(); }
        int i = 0;
        foreach(Transform bone in boneArray)
        {
            bonesOut.bones[i] = bone.rotation;
            i++;
        }
        if(update) { recentBones = bonesOut.bones; } //preeeetty sure it's a copy, if there's a cursed bug you know where to look...
        return bonesOut;
    }

    /// <summary>
    /// Returns a *copy* of the recent bone data.
    /// </summary>
    /// <returns></returns>
    public BoneData GetRecentBones()
    {
        return new BoneData(recentBones);
    }

    /// <summary>
    /// Returns the BoneData associated with an object. Updated every frame. Handle with caution.
    /// </summary>
    /// <returns></returns>
    public BoneData GetLiveBones()
    {
        return liveBones;
    }
}
