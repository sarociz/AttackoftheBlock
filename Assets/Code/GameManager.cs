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
    public Vector2 minSpawnPosition; // Límite inferior de la posición aleatoria
    public Vector2 maxSpawnPosition; // Límite superior de la posición aleatoria

  

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
                playerSprite.enabled = true; // Asegúrate de que el sprite esté visible al final
            }
        }
    }

    // Método para activar el Power-up
    public void ActivatePowerUp()
    {
        // Generar una posición aleatoria dentro de los límites
        Vector2 spawnPosition = new Vector2(
            Random.Range(minSpawnPosition.x, maxSpawnPosition.x),
            Random.Range(minSpawnPosition.y, maxSpawnPosition.y)
        );
       
        powerUpPrefab.SetActive(true); // Activa el Power-up
    }
  

   

    private IEnumerator InvincibleBlink()
    {
        while (true)
        {
            playerSprite.enabled = !playerSprite.enabled;
            yield return new WaitForSeconds(0.2f); // Ajusta el tiempo de parpadeo según sea necesario
        }
    }
}
