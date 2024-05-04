using UnityEngine;

public class KnifeChopping : MonoBehaviour
{
    public Transform knifeTransform; // Reference to the Transform component of the knife
    public float chopSpeed = 2f; // Speed of the chopping motion
    public float chopDistance = 0.1f; // Maximum distance the knife moves up and down
    public Vector3 choppingAxis = Vector3.up; // Axis along which the knife moves

    private float initialYPosition; // Initial Y position of the knife

    void Start()
    {
        // Store the initial Y position of the knife
        initialYPosition = knifeTransform.position.y;

        // Start the chopping motion immediately when the game starts
        StartChopping();
    }

    void Update()
    {
        // Calculate the new Y position based on sine wave oscillation
        float newYPosition = initialYPosition + Mathf.Sin(Time.time * chopSpeed) * chopDistance;

        // Apply the new position to the knife
        Vector3 newPosition = knifeTransform.position;
        newPosition.y = newYPosition;
        knifeTransform.position = newPosition;
    }

    void StartChopping()
    {
        // Ensure the knifeTransform is not null before starting the chopping motion
        if (knifeTransform != null)
        {
            // Ensure the chopping motion is smoothly continuous by setting the initial Y position
            initialYPosition = knifeTransform.position.y;
        }
        else
        {
            Debug.LogError("Knife Transform is not assigned!");
        }
    }
}


