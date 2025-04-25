using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector2 respawnPosition;
    private bool checkpointSet = false;

    private void Start()
    {
        // Solo usa la posici�n inicial si a�n no hay un checkpoint
        if (!checkpointSet)
        {
            respawnPosition = transform.position;
            Debug.Log(" Respawn inicial asignado: " + respawnPosition);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Die();
        }
    }

    void Die()
    {
        Respawn();
    }

    void Respawn()
    {
        transform.position = respawnPosition;
        Debug.Log(" Jugador respawne� en: " + respawnPosition);
    }

    public void SetCheckpoint(Vector2 newCheckpoint)
    {
        respawnPosition = newCheckpoint;
        checkpointSet = true; // Marca que ya se us� un checkpoint
        Debug.Log("Checkpoint actualizado a: " + newCheckpoint);
    }
}
