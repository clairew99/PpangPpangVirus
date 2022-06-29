using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VrMap
{
    public Transform vrTarget;
    public Transform rigTarget;
    public Vector3 trackingPositionOffset;
    public Vector3 trackingRoatationOffset;

    public void Map()
    {
        rigTarget.position=vrTarget.TransformPoint(trackingPositionOffset);
        rigTarget.rotation=vrTarget.rotation *  Quaternion.Euler(trackingRoatationOffset);
    }
}
public class vrRig : MonoBehaviour
{
    public VrMap head;
    public VrMap lefthand;
    public VrMap righthand;

    public Transform headConstraint;
    public Vector3 headBodyoffset;
    void Start()
    {
        headBodyoffset=transform.position - headConstraint.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position=headConstraint.position + headBodyoffset;
        transform.forward=Vector3.ProjectOnPlane(headConstraint.up,Vector3.up).normalized;

        head.Map();
        lefthand.Map();
        righthand.Map();
    }
}
