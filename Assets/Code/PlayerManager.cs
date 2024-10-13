using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Rigidbody2D rb;
    private GameManager GameManager;

    public AudioSource auSource;

    public AudioClip powerupAudio;

    public float scaleFactor = 0.5f; // Factor de escala (0.5 para hacerlo más pequeño)

    private Vector3 originalScale;

    private List<EnemyManager> enemies; // Lista para almacenar los enemigos
    private float originalEnemySpeed = 1f; // Velocidad original de los enemigos
    public float enemySpeedMultiplier = 2f; // Multiplicador de velocidad de los enemigos


    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        GameManager = FindAnyObjectByType<GameManager>();

        enemies = new List<EnemyManager>(FindObjectsOfType<EnemyManager>());
        if (enemies.Count > 0)
        {
            originalEnemySpeed = enemies[0].rapidez; // Suponemos que todos los enemigos tienen la misma velocidad
        }

    }
    // Update is called once per frame
    void Update()
    {

        // Sprite del jugador sigue la posición del ratón constantemente
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Limitar la posición del jugador dentro de los límites de la cámara
        Vector2 clampedPosition = ClampPositionToCameraBounds(mousePosition);

        rb.MovePosition(clampedPosition);

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


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            auSource.clip = powerupAudio;
            auSource.Play();


            // Guardar la escala original
            originalScale = transform.localScale;

            // Hacer el sprite más pequeño
            transform.localScale = originalScale * scaleFactor;

            // Destruir el PowerUp
            Destroy(other.gameObject);

            // Iniciar la corrutina para volver a la escala original después de 5 segundos
            StartCoroutine(ResetScaleAfterTime(5f));
        }
        if (other.gameObject.CompareTag("PowerDown")) {         

            // Destruir el Powerdown
            Destroy(other.gameObject);

            // Aumentar la velocidad de los enemigos
            SetEnemySpeedMultiplier(enemySpeedMultiplier);

            // Iniciar la corrutina para restablecer la escala y la velocidad después de 5 segundos
            StartCoroutine(ResetEffectsAfterTime(5f));
        }


    }
    private void SetEnemySpeedMultiplier(float multiplier)
    {
        foreach (EnemyManager enemy in enemies)
        {
            enemy.rbObstaculo.AddForce(enemy.velocidad.normalized * enemy.rapidez * multiplier);
        }
    }


    // Corrutina que espera 5 segundos y luego vuelve a la escala original
    private IEnumerator ResetScaleAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        transform.localScale = originalScale;
    }

    private IEnumerator ResetEffectsAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Restablecer la velocidad original de los enemigos
        foreach (EnemyManager enemy in enemies)
        {
            enemy.rapidez = originalEnemySpeed;
        }
    }


}