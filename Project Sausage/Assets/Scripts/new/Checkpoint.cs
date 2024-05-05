using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public static Checkpoint FindNearestCheckpoint(Transform playerTransform)
    {
        Checkpoint nearestCheckpoint = null;
        float closestDistance = Mathf.Infinity;

        // Assuming all checkpoints are children of a parent object tagged as "Checkpoints"
        Transform[] allCheckpoints = GameObject.FindWithTag("Checkpoints").GetComponentsInChildren<Transform>();

        foreach (Transform checkpointTransform in allCheckpoints)
        {
            if (checkpointTransform.gameObject.CompareTag("Checkpoint"))
            {
                float distance = Vector3.Distance(playerTransform.position, checkpointTransform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    nearestCheckpoint = checkpointTransform.GetComponent<Checkpoint>();
                }
            }
        }

        return nearestCheckpoint;
    }
}
