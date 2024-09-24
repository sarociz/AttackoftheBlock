using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //Sprite del jugador sigue la posici�n del rat�n constantemente
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);        
        transform.position = mousePosition;
    }

}