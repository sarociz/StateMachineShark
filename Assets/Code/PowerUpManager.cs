using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public GameObject powerUpPrefab;
    public GameObject powerdownPrefab;
    public Vector2 minSpawnPosition; // Límite inferior de la posición aleatoria
    public Vector2 maxSpawnPosition; // Límite superior de la posición aleatoria
    private bool powerUpActive = false;
    private bool powerUpDown = false;

    private void Start()
    {
        DeactivatePowerUp();
    }

    // Método para activar el Power-up
    public void ActivatePowerUp()
    {
        powerUpPrefab.SetActive(true); // Activa el Power-up
        powerUpActive = true; // Marca el Power-up como activo
    }

    // Método para desactivar el Power-up
    private void DeactivatePowerUp()
    {
        powerUpPrefab.SetActive(false); // Desactiva el Power-up
        powerUpActive = false; // Marca el Power-up como inactivo
    }

    public void ActivatePowerDown()
    {
        powerdownPrefab.SetActive(true); // Activa el PowerDown
        powerUpDown = true; // Marca el PowerDown como activo
    }

    // Método para desactivar el Power-up
    private void DeactivatePowerDown()
    {
        powerdownPrefab.SetActive(false); // Desactiva el Power-down
        powerUpDown = false; // Marca el Power-down como inactivo
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Personaje") & this.gameObject.CompareTag("PowerUp"))
        {
            // Lógica para lo que hace el Power-up al ser recogido
            DeactivatePowerUp(); // Desactiva el Power-up al ser recogido
            Destroy(gameObject); // Destruye el Power-up
        }
        else if (other.gameObject.CompareTag("Personaje") & this.gameObject.CompareTag("PowerDown"))
        {
            // Lógica para lo que hace el Power-down al ser recogido
            DeactivatePowerDown(); // Desactiva el Power-up al ser recogido
            Destroy(gameObject); // Destruye el Power-up
        }
    }
}
