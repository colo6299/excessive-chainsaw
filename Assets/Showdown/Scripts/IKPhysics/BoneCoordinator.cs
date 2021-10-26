using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneCoordinator : MonoBehaviour
{
    public BoneCoordinator debugSlaver;
    public bool debugCheckSlave;
    public float debugSlerpFloat = 1;
    public float debugForceFloat = 1;
    public bool smoothSnap = false;

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
    public Rigidbody[] rbodyArray;

    private void Start()
    {
        liveBones = GetOrUpdateBones();
        targetBones = null;
        BuildRBodyArray();
        RBodySettings();
    }

    private void FixedUpdate()
    {
        GetOrUpdateBones(liveBones);
        //SlerpBonesToTarget();
        TwistBonesTowardsTarget();
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

    private void BuildRBodyArray()
    {
        rbodyArray = new Rigidbody[57];
        int i = 0;
        foreach(Transform bone in boneArray)
        {
            if (bone.gameObject.GetComponent<Rigidbody>() == null)
            {
                Debug.LogWarning(bone.gameObject.name + " has no rigidbody.");
            }
            rbodyArray[i] = bone.gameObject.GetComponent<Rigidbody>();
            i++;
        }
    }

    private void RBodySettings()
    {
        foreach(Rigidbody bone in rbodyArray)
        {
            if (bone != null)
            {
                bone.angularDrag = 100;
                bone.useGravity = false;
                bone.drag = 0;
                bone.interpolation = RigidbodyInterpolation.Extrapolate;
                bone.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
            }
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


    private void SmoothSnap(int boneID)
    {
        if (boneArray[boneID] == null) { Debug.LogError(boneID + " invalid."); }
        boneArray[boneID].rotation = Quaternion.Slerp(recentBones[boneID], targetBones.bones[boneID], 0.5f);
    }


    private void SnapBone(int boneID)
    {
        Transform bone = boneArray[boneID];
        bone.rotation = targetBones.bones[boneID];
        Debug.Log(boneID);
    }

    private void TwistBone(int boneID)
    {
        Rigidbody boneRigidbody = rbodyArray[boneID];
        Transform boneTransform = boneArray[boneID];
        Quaternion targetBone = targetBones.bones[boneID];

        if(boneRigidbody == null)
        {
            //FALLBACK TO BONE SNAP
            Debug.LogWarning("Fallback to bone snapping on " + boneTransform.name);
            SnapBone(boneID);
            return;
        }
      
        Vector3 boneDelta = targetBone.eulerAngles - boneTransform.eulerAngles;
        Debug.Log(boneID);
        //boneRigidbody.angularVelocity = boneDelta * debugForceFloat;
        float angleBetween = Quaternion.Angle(boneTransform.rotation, targetBone);
        boneTransform.rotation = Quaternion.Lerp(boneTransform.rotation, targetBone, debugForceFloat / angleBetween);
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
            SnapBone(i);
            i++;
        }
        GetOrUpdateBones(liveBones);
    }

    /// <summary>
    /// A target approach type. Uses rigidbody physics to move joints towards target angles.
    /// </summary>
    private void TwistBonesTowardsTarget()
    {
        if (targeting == false) { return; }

        for(int i=0; i < 57; i++)
        {
            if (smoothSnap)
            {
                SmoothSnap(i);
            }
            else
            {
                TwistBone(i);
            }
        }
        GetOrUpdateBones(liveBones);
    }

    /// <summary>
    /// A target approach type. Slerps quaternion rotation values by a fixed ratio.
    /// </summary>
    private void SlerpBonesToTarget()
    {
        if (targeting == false) { return; }

        int i = 0;
        foreach (Transform bone in boneArray)
        {
            bone.localRotation = Quaternion.Slerp(bone.rotation, targetBones.bones[i], debugSlerpFloat);
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
