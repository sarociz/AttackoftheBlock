using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    //timer de tres segundos para que el juego no empiece de repente.
    public float timer = 3.0f;
    public TextMeshProUGUI startText;


    void Update()
    {
        timer -= Time.deltaTime;
        startText.text = (timer).ToString("0");
        //cuando el timer llega a 0 empieza el juego
        if (timer < 0)
        {
            SceneManager.LoadScene("Game");
        }
    }

}

