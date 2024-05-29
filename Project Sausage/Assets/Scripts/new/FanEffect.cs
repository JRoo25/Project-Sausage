using UnityEngine;

public class FanEffect : MonoBehaviour
{
    public float upwardForce = 10f; // The force applied upwards by the fan

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.SetFanEffect(true, upwardForce);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.SetFanEffect(false, 0f);
            }
        }
    }
}


