using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PV : MonoBehaviour
{
    public int pv = 3;
    public bool isDead;

    // DEATHMENU
    public GameObject deathMenu;


    private void Start()
    {
        deathMenu = GameObject.Find("DeathMenu");
        isDead = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="Asteroid")
        {
            if(pv > 0)
            {
                pv = pv - 1;
                Destroy(collision.gameObject);
            }
            else if(pv ==0)
            {
                isDead = true;
                Destroy(collision.gameObject);
            }

            if(isDead == true)
            {
                deathMenu.SetActive(true);
                Destroy(this.gameObject);
            }

        }
    }
}
