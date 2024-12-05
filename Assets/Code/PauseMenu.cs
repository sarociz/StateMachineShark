using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    //timer de tres segundos para que el juego no empiece de repente.
    private float timer = 3.0f;
    public TextMeshProUGUI startText;

    public void buttonPause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
    }

    public void buttonPortada()
    {
        SceneManager.LoadScene("Portada");
        Time.timeScale = 1;
        Cursor.visible = true;

    }


    public void buttonResume()
    {
        pauseMenu.SetActive(false);
        startText.gameObject.SetActive(true);
        Time.timeScale = 0; // Pausar el juego
        Cursor.visible = true;

        StartCoroutine(ResumeAfterCountdown());
        timer = 3f; // Reiniciar el temporizador
    }

    IEnumerator ResumeAfterCountdown()//cuenta atrás(3 segundos) para que el juego no empiece de repente.
    {
        while (timer > 0)
        {
            startText.text = timer.ToString("0");
            yield return new WaitForSecondsRealtime(1f); 
            timer -= 1f;
        }

        Time.timeScale = 1;
        Cursor.visible = false;
        startText.gameObject.SetActive(false);
        timer = 3f; // Reiniciar el temporizador
    }


}
