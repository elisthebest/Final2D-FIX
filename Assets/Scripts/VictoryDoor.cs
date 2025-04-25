using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryDoor : MonoBehaviour
{
    public AudioClip winSFX;
    public GameObject winUI;

    private bool gameEnded = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameEnded) return;

        if (collision.CompareTag("Player"))
        {
            gameEnded = true;

            // Sonido de victoria
            if (winSFX != null)
            {
                AudioSource.PlayClipAtPoint(winSFX, transform.position);
            }

            // Mostrar UI
            if (winUI != null)
                winUI.SetActive(true);

            // Pausar juego
            Time.timeScale = 0f;

            // Opcional: Log
            Debug.Log("¡Victoria!");
        }
    }

    // Botones desde la UI llaman estas funciones
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Time.timeScale = 1f;
        
        EditorApplication.isPlaying = false; // Detener la aplicaci .isPlaying = false; // Detener la aplicacio
        Application .Quit(); // Salir de la aplicacion
    
    }
}
