using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
   
    private Vector2 startPos;
    private Vector2 endPos;
    private bool movingRight = true;

    public TextMeshProUGUI[] topTimeTexts;


    private RectTransform imageRectTransform;
    public GameObject image;
    private float speed = 350.0f;

    void Start()
    {
        imageRectTransform = image.GetComponent<RectTransform>();
        // Inicializar las posiciones de inicio y fin
        startPos = new Vector2(-Screen.width , imageRectTransform.anchoredPosition.y);
        endPos = new Vector2(Screen.width, imageRectTransform.anchoredPosition.y);

        // Mostrar los 5 mejores tiempos
        for (int i = 0; i < 5; i++)
        {
            if (PlayerPrefs.HasKey("TopTime" + i))
            {
                float time = PlayerPrefs.GetFloat("TopTime" + i);

                int minutes = Mathf.FloorToInt(time / 60);
                int seconds = Mathf.FloorToInt(time % 60);
                float milliseconds = (time % 1) * 100;

                topTimeTexts[i].text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, Mathf.FloorToInt(milliseconds));
            }
            else
            {
                topTimeTexts[i].text = "No Record";
            }
        }
    }

    void Update()
    {
        SharkMovement();
    }
   

    private void SharkMovement()
    {
        // Mover la imagen de un lado a otro
        if (movingRight)
        {
            imageRectTransform.anchoredPosition += Vector2.right * speed * Time.deltaTime;
            imageRectTransform.rotation = Quaternion.Euler(0, 180, 0);
            if (imageRectTransform.anchoredPosition.x >= endPos.x)
            {
                movingRight = false;
            }
        }
        else
        {

            imageRectTransform.anchoredPosition += Vector2.left * speed * Time.deltaTime;
            imageRectTransform.rotation = Quaternion.Euler(0, 0, 0);
            if (imageRectTransform.anchoredPosition.x <= startPos.x)
            {
                movingRight = true;
            }
        }
        //Cursor.visible = false;
    }
    public void ButtonStart()
    {
        SceneManager.LoadScene("Game");
        Cursor.visible = false;
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }
}

