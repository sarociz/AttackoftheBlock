using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    public Rigidbody2D rbObstaculo;
    public float rapidez = 300;
    private Vector2 velocidad;
    private void Start()
    {
        rbObstaculo.velocity = Vector2.zero;
        velocidad.x = Random.Range(-1f, 1f);
        velocidad.y = -1;
        rbObstaculo.AddForce(velocidad.normalized * rapidez);
    }

    //Al chocar el personaje con un obsáculo = "game over"
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Personaje"))
        {
            SceneManager.LoadScene("GameOver");            
        }
        velocityFix();
    }

    //Funcion para arreglar la velocidad y la direccion del rebote del obstáculo.
    private void velocityFix()
    {
        float velocityDelta = 0.5f;
        float minVelocity = 0.2f;

        if (Mathf.Abs(rbObstaculo.velocity.x) < minVelocity)
        {
            velocityDelta = Random.value < 0.5f ? velocityDelta : -velocityDelta;
            rbObstaculo.velocity += new Vector2(velocityDelta, 0f);
        }

        if (Mathf.Abs(rbObstaculo.velocity.y) < minVelocity)
        {
            velocityDelta = Random.value < 0.5f ? velocityDelta : -velocityDelta;
            rbObstaculo.velocity += new Vector2(velocityDelta, 0f);
        }
    }
}
