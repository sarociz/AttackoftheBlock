using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void botonRestart()
    {
        SceneManager.LoadScene("Game");
    }

    public void botonPortada()
    {
        SceneManager.LoadScene("Portada");
    }

}
