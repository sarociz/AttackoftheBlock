using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Rigidbody2D rb;
    private GameManager GameManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameManager = FindAnyObjectByType<GameManager>();
    }
    // Update is called once per frame
    void Update()    {
        
        
       // rb.MovePosition(mousePosition);
       

        // Sprite del jugador sigue la posición del ratón constantemente
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Limitar la posición del jugador dentro de los límites de la cámara
        Vector2 clampedPosition = ClampPositionToCameraBounds(mousePosition);

        rb.MovePosition(clampedPosition);
        GameManager.TimeInvulnerable();
    }

    // Función para clavar la posición dentro de los límites de la cámara
    private Vector2 ClampPositionToCameraBounds(Vector2 position)
    {
        Camera cam = Camera.main;
        Vector2 minBounds = cam.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 maxBounds = cam.ViewportToWorldPoint(new Vector2(1, 1));

        float clampedX = Mathf.Clamp(position.x, minBounds.x, maxBounds.x);
        float clampedY = Mathf.Clamp(position.y, minBounds.y, maxBounds.y);

        return new Vector2(clampedX, clampedY);
    }
}