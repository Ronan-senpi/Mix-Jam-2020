using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitable : MonoBehaviour
{
    [SerializeField]
    private LayerMask hitableMask;

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

    private void Kill()
    {
        Destroy(gameObject);
    }
    private void Grab(Vector2 origin, float grabForce)
    {
        Rigidbody2D rb;
        if (transform.TryGetComponent(out rb))
        {
            rb.AddForce(origin * grabForce);
        }
    }
}
