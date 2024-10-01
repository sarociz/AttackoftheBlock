using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    public Rigidbody2D rbObstaculo;
    public float rapidez = 300;
    private Vector2 velocidad;
    private GameManager GameManager;


    private void Start()
    {
        rbObstaculo.velocity = Vector2.zero;
        velocidad.x = Random.Range(-1f, 1f);
        velocidad.y = -1;
        rbObstaculo.AddForce(velocidad.normalized * rapidez);
        GameManager = FindAnyObjectByType<GameManager>();
    }
   

    

    //Al chocar el personaje con un obsáculo = "game over"
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!GameManager.invincible)
        {
            if (collision.gameObject.CompareTag("Personaje"))
            {
                FindAnyObjectByType<GameManager>().perderVida();
                Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
                GameManager.invincible = true;
            }
        }

        velocityFix();
    }

    //void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Personaje"))
    //    {
    //        FindAnyObjectByType<GameManager>().perderVida();
    //    }

    //    velocityFix();
    //}

    //Funcion para arreglar la velocidad del rebote del obstáculo.
    private void velocityFix()
    {
        float velocity = 0.5f;
        float minVelocity = 0.2f;

        if (Mathf.Abs(rbObstaculo.velocity.x) < minVelocity)
        {
            velocity = Random.value < 0.5f ? velocity : -velocity;
            rbObstaculo.velocity += new Vector2(velocity, 0f);
        }

        if (Mathf.Abs(rbObstaculo.velocity.y) < minVelocity)
        {
            velocity = Random.value < 0.5f ? velocity : -velocity;
            rbObstaculo.velocity += new Vector2(velocity, 0f);
        }
    }
}
