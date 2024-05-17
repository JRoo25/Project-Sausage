using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 10f;
    public float detectionRange = 10f;
    public float shootingInterval = 2f;

    private float timer;

    private void Update()
    {
        // Check if it's time to shoot
        timer += Time.deltaTime;
        if (timer >= shootingInterval)
        {
            timer = 0f;

            // Find the nearest player
            GameObject nearestPlayer = FindNearestPlayer();

            // Aim towards the nearest player if within detection range
            if (nearestPlayer != null)
            {
                float distanceToPlayer = Vector3.Distance(transform.position, nearestPlayer.transform.position);
                if (distanceToPlayer <= detectionRange)
                {
                    Vector3 direction = nearestPlayer.transform.position - transform.position;
                    Quaternion rotation = Quaternion.LookRotation(direction);
                    transform.rotation = rotation;

                    // Shoot the projectile
                    ShootProjectile();
                }
            }
        }
        else // Continuously aim at the target if detected
        {
            GameObject nearestPlayer = FindNearestPlayer();
            if (nearestPlayer != null)
            {
                Vector3 direction = nearestPlayer.transform.position - transform.position;
                Quaternion rotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5f); // Smoothly rotate towards the target
            }
        }
    }

    private GameObject FindNearestPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject nearestPlayer = null;
        float minDistance = Mathf.Infinity;

        foreach (GameObject player in players)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestPlayer = player;
            }
        }

        return nearestPlayer;
    }

    private void ShootProjectile()
    {
        if (projectilePrefab != null && firePoint != null)
        {
            // Instantiate projectile at the fire point and give it the same rotation as the cannon
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, transform.rotation);
            // Add force to the projectile to shoot it forward
            projectile.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeed, ForceMode.Impulse);
        }
        else
        {
            Debug.LogWarning("Projectile prefab or fire point is not assigned.");
        }
    }
}



