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


    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Vector3.up * Time.deltaTime * speed;
        lifepass += Time.deltaTime;
        if (lifepass >= lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.HitSomthing();
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
