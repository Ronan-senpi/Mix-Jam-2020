using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBase : MonoBehaviour
{
    [SerializeField]
    float cooldown = 0.25f;
    float cooddownPass = 0;

    [Header("Kill shoot")]
    [SerializeField]
    GameObject projectileKillPrefab;
    [SerializeField]
    KeyCode keyKill;

    [Header("Grab shoot")]
    [SerializeField]
    GameObject projectileGrabPrefab;
    [SerializeField]
    KeyCode keyGrab;

    // Update is called once per frame
    void Update()
    {
        cooddownPass += Time.deltaTime;
        if (Input.GetKey(keyKill) && cooddownPass > cooldown)
        {
            Instantiate(projectileKillPrefab, transform.position, transform.rotation, transform);
            cooddownPass = 0;
        }


        if (Input.GetKey(keyGrab) && cooddownPass > cooldown)
        {
            Instantiate(projectileGrabPrefab, transform.position, transform.rotation, transform);
            cooddownPass = 0;
        }
    }
}
