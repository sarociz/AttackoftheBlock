using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Hearts = 3;
    public List<GameObject> HeartList;
    private Coroutine coroutine;
    public int time;
    private float timeTrans;
    public bool invincible = false;
    public SpriteRenderer playerSprite;

    public GameObject powerUpPrefab; // El prefab del Power-up
    public Vector2 minSpawnPosition; // L�mite inferior de la posici�n aleatoria
    public Vector2 maxSpawnPosition; // L�mite superior de la posici�n aleatoria

    private void Start()
    {
        // Deactivamos el Power-up al iniciar
        DeactivatePowerUp();
    }

    public void perderVida()
    {
        Hearts--;

        if (Hearts <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            if (HeartList.Count > 0)
            {
                GameObject corazon = HeartList[HeartList.Count - 1];
                HeartList.RemoveAt(HeartList.Count - 1);
                corazon.SetActive(false);
            }

            // Activar Power-up al perder una vida
            if (Hearts == 1) // Si pierdes la segunda vida
            {
                ActivatePowerUp();
            }
        }
    }

    public void TimeInvulnerable()
    {
        if (invincible)
        {
            if (coroutine == null)
            {
                coroutine = StartCoroutine(InvincibleBlink());
            }
            timeTrans += Time.deltaTime;
            time = Mathf.RoundToInt(timeTrans);

            if (time == 3)
            {
                invincible = false;
                timeTrans = 0;
                time = 0;
                StopCoroutine(coroutine);
                coroutine = null;
                playerSprite.enabled = true; // Aseg�rate de que el sprite est� visible al final
            }
        }
    }

    // M�todo para activar el Power-up
    public void ActivatePowerUp()
    {
        // Generar una posici�n aleatoria dentro de los l�mites
        Vector2 spawnPosition = new Vector2(
            Random.Range(minSpawnPosition.x, maxSpawnPosition.x),
            Random.Range(minSpawnPosition.y, maxSpawnPosition.y)
        );

        // Instanciar el Power-up en la posici�n aleatoria
        GameObject powerUpInstance = Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity);
        powerUpInstance.SetActive(true); // Activa el Power-up
    }

    // M�todo para desactivar el Power-up
    private void DeactivatePowerUp()
    {
        // Aqu� puedes desactivar el prefab en la escena si lo has colocado en la misma
        // En este caso no es necesario, porque el Power-up se crea cuando se activa.
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Personaje"))
        {
            powerUpPrefab.SetActive(false); // Desactiva el Power-up
            Destroy(gameObject); // Destruye el Power-up
        }
    }

    private IEnumerator InvincibleBlink()
    {
        while (true)
        {
            playerSprite.enabled = !playerSprite.enabled;
            yield return new WaitForSeconds(0.2f); // Ajusta el tiempo de parpadeo seg�n sea necesario
        }
    }
}
