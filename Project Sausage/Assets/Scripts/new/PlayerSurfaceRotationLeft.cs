using UnityEngine;

public class PlayerSurfaceRotationLeft : MonoBehaviour
{
    public float movementSpeed = 5f; // Adjust the movement speed in the Inspector

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                // Calculate movement direction based on the log's rotation
                Vector3 movementDirection = transform.right; // Assuming the log's rotation axis is aligned with its right direction

                // Apply a constant force to move the player in the direction of the log's rotation
                playerRigidbody.AddForce(movementDirection * movementSpeed, ForceMode.Impulse);
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // When the player falls off the log, remove the applied force
            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                playerRigidbody.velocity = Vector3.zero;
            }
        }
    }
}







