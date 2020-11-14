using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectil : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float lifeTime;
    float lifepass = 0;

    [SerializeField]
    ProjectilType projectilType;

    [SerializeField]
    private LayerMask hitableMask;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(0, Time.deltaTime * speed, 0);
        pos += transform.rotation * velocity;
        transform.position = pos;

        lifepass += Time.deltaTime;
        if (lifepass >= lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((hitableMask.value & (1 << collision.gameObject.layer)) > 0)
        {
            this.HitSomthing();
        }
    }

    private void HitSomthing()
    {
        Destroy(gameObject);
    }
    public ProjectilType GetProjectilType()
    {
        return projectilType;
    }

}
