using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("DeadlyPlatform")) {
            Die();
        }
    }

    void Die() {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer!= null) {
            meshRenderer.enabled = false;
        }
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (rigidbody!= null) {
            rigidbody.isKinematic = true;
        }
        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        if (playerMovement!= null) {
            playerMovement.enabled = false;
        }
        Invoke(nameof(ReloadLevel), 0.1f);
    }

    void ReloadLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
