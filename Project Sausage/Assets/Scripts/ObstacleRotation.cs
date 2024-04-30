using UnityEngine;

public class ObstacleRotation : MonoBehaviour
{
    public float rotationSpeed = 50f; // Adjust the speed in the Inspector

    void Update()
    {
        // Rotate the log around its up axis (Y-axis) based on the rotationSpeed
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
