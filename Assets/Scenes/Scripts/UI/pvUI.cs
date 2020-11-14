using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pvUI : MonoBehaviour
{
    GameObject joueur;
    public float currentHealth;
    public PV pvJoueur;
    public Text currentHealthText;
    // Start is called before the first frame update
    void Start()
    {
        joueur = GameObject.FindGameObjectWithTag("Player");
        pvJoueur = joueur.GetComponent<PV>();
        currentHealth = pvJoueur.pv;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = pvJoueur.pv +1;
        currentHealthText.text = currentHealth.ToString();

        if(currentHealth <=0)
        {
            this.gameObject.SetActive(false);
        }

        if(pvJoueur == null)
        {
            this.gameObject.SetActive(false);
        }
    }
}
