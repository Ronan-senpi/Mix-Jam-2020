using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    public GameObject joueur;
    public PV pvJoueur;
    public float test;
    // Start is called before the first frame update
    void Start()
    {
        joueur = GameObject.FindGameObjectWithTag("Player");
        pvJoueur = joueur.GetComponent<PV>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        test = pvJoueur.pv;
        if(pvJoueur.pv <= 0 || pvJoueur ==null)
        {

            DeathMenuUI();
        }
    }

    public void DeathMenuUI()
    {
        gameObject.SetActive(true);
        return;
    }
}
