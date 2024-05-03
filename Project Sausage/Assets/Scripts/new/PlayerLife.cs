using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Vector3 checkpointPosition;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DeadlyPlatform"))
        {
            TeleportToCheckpoint();
        }
    }

    void TeleportToCheckpoint()
    {
        if (checkpointPosition != Vector3.zero)
        {
            transform.position = checkpointPosition;
        }
    }
}