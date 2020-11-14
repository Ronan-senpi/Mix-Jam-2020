using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
  
    public bool on;
    // Start is called before the first frame update
    void Start()
    {
        on = false;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.activeSelf)
        {
            on = true;
        }

        if(on == true)
        {
            //FERMER L UI PRINCIPAL POUR LAISSER L UI DEATH
        }
       
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }


}
