using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Hearts = 3;
    public List<GameObject> HeartList;
    private Coroutine coroutine;
    private float timeTrans;
    public bool invincible = false;
    public SpriteRenderer playerSprite;

    public GameObject powerUpPrefab; // El prefab del Power-up
    public Vector2 minSpawnPosition; // L�mite inferior de la posici�n aleatoria
    public Vector2 maxSpawnPosition; // L�mite superior de la posici�n aleatoria



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


            if (Hearts == 1)
            {
                ActivatePowerUp();
            }
        }
    }

    public void TimeInvulnerable()
    {
        if (!invincible) // Solo empezar el parpadeo si no estamos invulnerables
        {
            invincible = true;
            coroutine = StartCoroutine(InvincibleBlink());
        }

    }

    // Corrutina que maneja el parpadeo y la invulnerabilidad
    private IEnumerator InvincibleBlink()
    {
        float invincibleDuration = 3f;
        float timeTrans = 0f;

        while (invincibleDuration > timeTrans)
        {
            // Parpadea el sprite (lo enciende y apaga)
            playerSprite.enabled = !playerSprite.enabled;

            yield return new WaitForSeconds(0.2f);
            invincibleDuration  -= 0.2f;  // Duraci�n de cada parpadeo
            
        }

        // Al final del tiempo de invulnerabilidad
        playerSprite.enabled = true;  // Aseg�rate de que el sprite est� visible
        invincible = false;  // Desactiva la invulnerabilidad
        coroutine = null;    // Limpia la corrutina


    }

    // M�todo para activar el Power-up
    public void ActivatePowerUp()
    {
        // Generar una posici�n aleatoria dentro de los l�mites
        Vector2 spawnPosition = new Vector2(
            Random.Range(minSpawnPosition.x, maxSpawnPosition.x),
            Random.Range(minSpawnPosition.y, maxSpawnPosition.y)
        );

        powerUpPrefab.SetActive(true); // Activa el Power-up
    }
}
