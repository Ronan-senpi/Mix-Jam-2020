﻿using Assets.Scripts;
using Assets.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitable : MonoBehaviour
{
    [SerializeField]
    private LayerMask hitableMask;

    private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((hitableMask.value & (1 << collision.gameObject.layer)) > 0)
        {
            Projectil projectil;
            if (collision.transform.TryGetComponent<Projectil>(out projectil))
            {
                switch (projectil.GetProjectilType())
                {
                    case ProjectilType.Grab:
                        ProjectilGrab pGrab = ((ProjectilGrab)projectil);
                        Grab(pGrab.Origin, pGrab.GetGrabForce());
                        break;
                    case ProjectilType.Kill:
                        Kill();
                        break;
                }
            }
        }
    }

    protected virtual void Kill()
    {
        audio.Play();
        this.gameObject.SetActive(false);
        Destroy(gameObject);
    }
    protected virtual void Grab(Vector2 origin, float grabForce)
    {
        Rigidbody2D rb;
        if (transform.TryGetComponent(out rb))
        {
            rb.AddForce(origin-new Vector2(transform.position.x, transform.position.y) * grabForce);
        }
    }
}
