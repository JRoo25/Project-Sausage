using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float pushForce = 10f; // Adjust the force applied by the jump pad

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                // Calculate the direction in which to push the player
                Vector3 pushDirection = transform.forward; // Assuming the jump pad is facing forward

                // Apply the push force to the player's Rigidbody
                playerRb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
            }
        }
    }
}

