using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{

    public float timer = 3.0f;
     public TextMeshProUGUI startText;


    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        startText.text = (timer).ToString("0");
        if (timer < 0)
        {
            SceneManager.LoadScene("Game");
        }
    }

}

