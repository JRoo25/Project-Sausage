using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    AudioManager audioManager;
    public Transform lastCheckpoint;
    // Static dictionary to track if the checkpoint sound has been played for each checkpoint
    private static Dictionary<string, bool> checkpointSoundsPlayed = new Dictionary<string, bool>();

    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("DeadlyPlatform")) {
            Die();
        }
        if (collision.gameObject.CompareTag("Checkpoint")) {
            lastCheckpoint = collision.transform;
            // Get the checkpoint identifier (e.g., name or index)
            string checkpointId = collision.gameObject.name; // Assuming the checkpoint GameObject has a unique name
            // Play the checkpoint sound effect if it hasn't been played yet for this checkpoint
            if (!checkpointSoundsPlayed.ContainsKey(checkpointId) ||!checkpointSoundsPlayed[checkpointId]) {
                audioManager.PlaySFX(audioManager.checkpoint);
                // Mark the checkpoint sound as played for this checkpoint
                checkpointSoundsPlayed[checkpointId] = true;
            }
        }
    }

    void Die() {
        if (lastCheckpoint != null) {
            Vector3 spawnPosition = lastCheckpoint.position + new Vector3(0, 2f, 0);
            transform.position = spawnPosition;
            transform.rotation = lastCheckpoint.rotation;

            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null) {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        } else {
            // If there's no checkpoint, reload the level
            ReloadLevel();
        }
    }

    void ReloadLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}