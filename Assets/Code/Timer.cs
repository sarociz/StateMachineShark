using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public TextMeshProUGUI timer;

    public float currentTime;


    // Update is called once per frame
    void Update()
    {
        // Incrementar el tiempo hacia adelante
        currentTime += Time.deltaTime;

        // Calcular minutos y segundos
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        // Obtener los decimales (milisegundos o décimas de segundo)
        float milliseconds = (currentTime % 1) * 100;  // Para mostrar dos decimales

        // Mostrar el tiempo en formato de minutos:segundos:decimales
        timer.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, Mathf.FloorToInt(milliseconds));

    }
    //void SaveTime(float time)
    //{
    //    // Guardar el tiempo en PlayerPrefs
    //    for (int i = 0; i < 5; i++)
    //    {
    //        if (PlayerPrefs.HasKey("TopTime" + i))
    //        {
    //            // Si existe un valor guardado, continuamos
    //            continue;
    //        }
    //        else
    //        {
    //            // Guardamos el tiempo
    //            PlayerPrefs.SetFloat("TopTime" + i, time);
    //            PlayerPrefs.Save();
    //            return;
    //        }
    //    }
    //}

    public void UpdateTopTimes(float newTime)
    {
        // Cargar los tiempos guardados
        List<float> topTimes = new List<float>();

        for (int i = 0; i < 5; i++)
        {
            if (PlayerPrefs.HasKey("TopTime" + i))
            {
                topTimes.Add(PlayerPrefs.GetFloat("TopTime" + i));
            }
        }

        // Añadir el nuevo tiempo
        topTimes.Add(newTime);

        // Ordenar los tiempos de mayor a menor
        topTimes.Sort((a, b) => b.CompareTo(a));

        // Guardar los 5 mejores tiempos
        for (int i = 0; i < 5; i++)
        {
            if (i < topTimes.Count)
            {
                PlayerPrefs.SetFloat("TopTime" + i, topTimes[i]);
            }
        }

        PlayerPrefs.Save();
    }
}
