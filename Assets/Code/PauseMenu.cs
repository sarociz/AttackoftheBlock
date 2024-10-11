using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void buttonPause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void buttonPortada()
    {
        SceneManager.LoadScene("Portada");
        Time.timeScale = 1;


    }
    public void buttonResume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

  
}
