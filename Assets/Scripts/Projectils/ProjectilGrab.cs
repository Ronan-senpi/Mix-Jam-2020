using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilGrab : Projectil
{
    [SerializeField]
    float grabForce;
    Vector2 origin;
    private void Start()
    {
        origin = transform.parent.transform.position;
    }

 

    public Vector2 GetOrigin()
    {
        return origin;
    }

    public float GetGrabForce()
    {
        return grabForce;
    }
}
