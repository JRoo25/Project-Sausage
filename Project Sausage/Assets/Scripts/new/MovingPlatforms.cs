using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 3f;
    public float distance = 5f;
    public float pauseDuration = 1f;

    private Vector3 startPosition;
    private bool movingForward = true;
    private bool isPaused = false;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (!isPaused)
        {
            MovePlatform();
        }
    }

    void MovePlatform()
    {
        float movement = speed * Time.deltaTime;
        if (movingForward)
        {
            transform.position += transform.forward * movement;
            if (Vector3.Distance(startPosition, transform.position) >= distance)
            {
                StartCoroutine(PauseBeforeChangingDirection());
                movingForward = false;
            }
        }
        else
        {
            transform.position -= transform.forward * movement;
            if (Vector3.Distance(startPosition, transform.position) <= 0)
            {
                StartCoroutine(PauseBeforeChangingDirection());
                movingForward = true;
            }
        }
    }

    IEnumerator PauseBeforeChangingDirection()
    {
        isPaused = true;
        yield return new WaitForSeconds(pauseDuration);
        isPaused = false;
    }
}

