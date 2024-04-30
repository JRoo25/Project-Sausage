using UnityEngine;

public class RotatingLog : MonoBehaviour
{
    public float rotationSpeed = 50f; // Adjust the speed in the Inspector

    void Update()
    {
        // Rotate the log around its forward axis (Z-axis) with the opposite rotationSpeed
        transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
    }
}

