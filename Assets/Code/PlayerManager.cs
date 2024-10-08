using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Rigidbody2D rb;
    private GameManager GameManager;

    public AudioSource auSource;

    public AudioClip powerupAudio;

    public float scaleFactor = 0.5f; // Factor de escala (0.5 para hacerlo m�s peque�o)

    private Vector3 originalScale;


    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        GameManager = FindAnyObjectByType<GameManager>();
       
    }
    // Update is called once per frame
    void Update()    {
        
        // Sprite del jugador sigue la posici�n del rat�n constantemente
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);        

        // Limitar la posici�n del jugador dentro de los l�mites de la c�mara
        Vector2 clampedPosition = ClampPositionToCameraBounds(mousePosition);

        rb.MovePosition(clampedPosition);
        
    }

    // Funci�n para clavar la posici�n dentro de los l�mites de la c�mara
    private Vector2 ClampPositionToCameraBounds(Vector2 position)
    {
        Camera cam = Camera.main;
        Vector2 minBounds = cam.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 maxBounds = cam.ViewportToWorldPoint(new Vector2(1, 1));

        float clampedX = Mathf.Clamp(position.x, minBounds.x, maxBounds.x);
        float clampedY = Mathf.Clamp(position.y, minBounds.y, maxBounds.y);

        return new Vector2(clampedX, clampedY);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            auSource.clip = powerupAudio;
            auSource.Play();          
           

            // Guardar la escala original
            originalScale = transform.localScale;

            // Hacer el sprite m�s peque�o
            transform.localScale = originalScale * scaleFactor;

            // Destruir el PowerUp
            Destroy(other.gameObject);

            // Iniciar la corrutina para volver a la escala original despu�s de 5 segundos
            StartCoroutine(ResetScaleAfterTime(5f));
        }
    }


    // Corrutina que espera 5 segundos y luego vuelve a la escala original
    private IEnumerator ResetScaleAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        transform.localScale = originalScale;
    }


}