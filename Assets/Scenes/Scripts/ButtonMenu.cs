using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonMenu : MonoBehaviour
{
   public void PlayGame()
    {
        SceneManager.LoadScene("Scene 1");
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
