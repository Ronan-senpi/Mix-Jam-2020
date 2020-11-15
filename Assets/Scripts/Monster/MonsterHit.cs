using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHit : MonoBehaviour
{
    // HIT JOUEUR
    public GameObject joueur;
    public PV joueurpv;
    public float joueurFloatPv;

    // STATE MONSTER
    public MonsterDeplacement monsterDeplacement;
    public int monsterState;
    // Start is called before the first frame update
    void Start()
    {
        joueur = GameObject.FindGameObjectWithTag("Player");
        joueurpv = joueur.GetComponent<PV>();
        joueurFloatPv = joueurpv.pv;

        monsterDeplacement = this.gameObject.GetComponent<MonsterDeplacement>();
        monsterState = monsterDeplacement.state;
    }

    // Update is called once per frame
    void Update()
    {
        monsterState = monsterDeplacement.state;

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(monsterState >=3)
        {
            if(collision.gameObject.tag =="Player")
            {
                joueurFloatPv = -1;
                joueurpv.pv = joueurFloatPv;
                joueurpv.isDead = true;
                joueurpv.deathMenu.SetActive(true);
                Destroy(collision.gameObject);
            }
        }
    }


}
