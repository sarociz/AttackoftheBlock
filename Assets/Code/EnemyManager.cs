using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    public Rigidbody2D rbObstaculo;
    public float rapidez = 300;
    public Vector2 velocidad;
    private GameManager GameManager;

    public AudioSource auSource;

    public AudioClip enemyAudio;



    private void Start()
    {
        rbObstaculo.velocity = Vector2.zero;
        velocidad.x = Random.Range(-1f, 1f);
        velocidad.y = -1;
        rbObstaculo.AddForce(velocidad.normalized * rapidez);
        GameManager = FindAnyObjectByType<GameManager>();

    }


    void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        // Guardar la velocidad actual del Rigidbody2D
        Vector2 velocidadActual = rbObstaculo.velocity;

        if (!GameManager.invincible && collision.gameObject.CompareTag("Personaje"))
        {
            auSource.clip = enemyAudio;
            auSource.Play();
            GameManager.perderVida();
            GameManager.TimeInvulnerable();
        }

        // Siempre restablecer la velocidad del Rigidbody2D después de todos los cálculos
        rbObstaculo.velocity = velocidadActual;

        velocityFix();
    }



    //Funcion para arreglar la velocidad del rebote del obstáculo.
    private void velocityFix()
    {
        float velocity = 0.5f;
        float minVelocity = 0.2f;
        float maxVelocity = 6f;  // Velocidad máxima        

        // Ajuste de la velocidad en el eje X
        if (Mathf.Abs(rbObstaculo.velocity.x) < minVelocity)
        {
            velocity = Random.value < 0.5f ? velocity : -velocity;
            rbObstaculo.velocity += new Vector2(velocity, 0f);
        }

        // Ajuste de la velocidad en el eje Y
        if (Mathf.Abs(rbObstaculo.velocity.y) < minVelocity)
        {
            velocity = Random.value < 0.5f ? velocity : -velocity;
            rbObstaculo.velocity += new Vector2(velocity, 0f);
        }

        // Limitar la velocidad máxima
        rbObstaculo.velocity = Vector2.ClampMagnitude(rbObstaculo.velocity, maxVelocity);
    }
}
