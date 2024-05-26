using UnityEngine;

public class BreakablePane : MonoBehaviour
{
    public float fallDelay = 0.5f; // Delay before the pane falls

    private bool isFalling = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isFalling)
        {
            PaneType paneType = GetComponent<PaneType>();
            if (paneType != null && !paneType.isSolid)
            {
                isFalling = true;
                Invoke("Fall", fallDelay);
            }
        }
    }

    private void Fall()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.isKinematic = false;
        Destroy(gameObject, 5f); // Destroy the pane after 5 seconds to clean up
    }
}
