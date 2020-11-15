using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PV : MonoBehaviour
{
    public float pv = 3;
    public bool isDead;

    // DEATHMENU
    public GameObject deathMenu;

    private AudioSource audio;
    private void Start()
    {
        isDead = false;
        audio = this.GetComponent<AudioSource>();
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
                audio.Play();
                pv = pv - 1;
                Destroy(collision.gameObject);
            }
            else if(pv <=0)
            {
                Destroy(collision.gameObject);
                deathMenu.SetActive(true);
            }

            if(deathMenu.activeSelf)
            {
                isDead = true;
            }

            if (isDead == true)
            {
                Destroy(this.gameObject);
            }

        }
    }
}
