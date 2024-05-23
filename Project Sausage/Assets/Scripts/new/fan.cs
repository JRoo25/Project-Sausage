using UnityEngine;

public class CeilingFan : MonoBehaviour
{
    public float rotationSpeed = 100f; // Speed of rotation in degrees per second

    void Update()
    {
        // Rotate the fan around its up (y) axis at the defined rotation speed
        transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
    }
}

