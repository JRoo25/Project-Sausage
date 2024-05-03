using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Vector3 checkpointPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerLife playerLife = other.GetComponent<PlayerLife>();
            if (playerLife != null)
            {
                playerLife.SetCheckpointPosition(transform.position);
            }
        }
    }
}