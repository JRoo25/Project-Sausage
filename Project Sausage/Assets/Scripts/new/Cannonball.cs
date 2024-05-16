using UnityEngine;

public class Cannonball : MonoBehaviour
{
    public float lifespan = 5f; // Adjust this value in the Inspector to set the lifespan of the cannonball

    private float timer;

    private void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // Check if the timer exceeds the lifespan
        if (timer >= lifespan)
        {
            // Destroy the cannonball
            Destroy(gameObject);
        }
    }
}

