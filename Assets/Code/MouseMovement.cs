using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //Sprite del jugador sigue la posición del ratón constantemente
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);        
        transform.position = mousePosition;
    }

}