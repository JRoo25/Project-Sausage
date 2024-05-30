using UnityEngine;

public class PushPlatform : MonoBehaviour
{
    public float pushForce = 10f; // Adjust the force applied by the platform
    public Vector3 pushDirection = Vector3.up; // Direction to push the player, default is upward

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                // Normalize the push direction to ensure consistent force application
                Vector3 normalizedPushDirection = pushDirection.normalized;

                // Apply the push force to the player's Rigidbody
                playerRb.AddForce(normalizedPushDirection * pushForce, ForceMode.Impulse);
            }
        }
    }
}

