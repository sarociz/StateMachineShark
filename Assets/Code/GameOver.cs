using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void botonRestart()
    {
        Cursor.visible = false;
        SceneManager.LoadScene("Game");
    }

    public void botonPortada()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("Portada");
    }

}
