using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector2 respawnPosition;
    private bool checkpointSet = false;

    private void Start()
    {
        // Solo usa la posición inicial si aún no hay un checkpoint
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
        Debug.Log(" Jugador respawneó en: " + respawnPosition);
    }

    public void SetCheckpoint(Vector2 newCheckpoint)
    {
        respawnPosition = newCheckpoint;
        checkpointSet = true; // Marca que ya se usó un checkpoint
        Debug.Log("Checkpoint actualizado a: " + newCheckpoint);
    }
}
