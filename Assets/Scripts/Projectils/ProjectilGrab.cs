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

    }

    public Vector2 Origin
    {
        get
        {
            return origin;
        }
        set
        {
            origin = value;
        }
    }
    public float GetGrabForce()
    {
        return grabForce;
    }

}
