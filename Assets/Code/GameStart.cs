using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    //timer de tres segundos para que el juego no empiece de repente.
    //private float timer = 3.0f;
   // public TextMeshProUGUI startText;
    private Vector2 startPos;
    private Vector2 endPos;
    private bool movingRight = true;


    private RectTransform imageRectTransform;
    public GameObject image;
    private float speed = 350.0f;

    void Start()
    {
        imageRectTransform = image.GetComponent<RectTransform>();
        // Inicializar las posiciones de inicio y fin
        startPos = new Vector2(-Screen.width , imageRectTransform.anchoredPosition.y);
        endPos = new Vector2(Screen.width, imageRectTransform.anchoredPosition.y);
        
       
    }

    void Update()
    {
        SharkMovement();
    }

    //void Update()
    //{
    //    timer -= Time.deltaTime;
    //    startText.text = (timer).ToString("0");
    //    //cuando el timer llega a 0 empieza el juego
    //    if (timer < 0)
    //    {
    //        SceneManager.LoadScene("Game");
    //    }
    //}

    private void SharkMovement()
    {
        // Mover la imagen de un lado a otro
        if (movingRight)
        {
            imageRectTransform.anchoredPosition += Vector2.right * speed * Time.deltaTime;
            imageRectTransform.rotation = Quaternion.Euler(0, 180, 0);
            if (imageRectTransform.anchoredPosition.x >= endPos.x)
            {
                movingRight = false;
            }
        }
        else
        {

            imageRectTransform.anchoredPosition += Vector2.left * speed * Time.deltaTime;
            imageRectTransform.rotation = Quaternion.Euler(0, 0, 0);
            if (imageRectTransform.anchoredPosition.x <= startPos.x)
            {
                movingRight = true;
            }
        }
        //Cursor.visible = false;
    }
    public void ButtonStart()
    {
        SceneManager.LoadScene("Game");
        Cursor.visible = false;
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }
}

