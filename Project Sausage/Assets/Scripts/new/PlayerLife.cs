using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public Transform lastCheckpoint;

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("DeadlyPlatform")) {
            Die();
        }
        if (collision.gameObject.CompareTag("Checkpoint")) {
            lastCheckpoint = collision.transform; // Set the last checkpoint to the current one
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