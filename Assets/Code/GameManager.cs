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

    private IEnumerator InvincibleBlink()
    {
        while (true)
        {
            playerSprite.enabled = !playerSprite.enabled;
            yield return new WaitForSeconds(0.2f); // Ajusta el tiempo de parpadeo según sea necesario
        }
    }
}
