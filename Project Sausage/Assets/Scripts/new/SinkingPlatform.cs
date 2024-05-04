using UnityEngine;

public class SinkingPlatform : MonoBehaviour
{
    public float sinkDistance = 2f; // Distance the platform sinks
    public float sinkSpeed = 1f;    // Speed at which the platform sinks
    public float riseSpeed = 1f;    // Speed at which the platform rises
    public float sinkIntervalMin = 2f; // Minimum interval between sinking (in seconds)
    public float sinkIntervalMax = 4f; // Maximum interval between sinking (in seconds)

    private Vector3 initialPosition;
    private bool isSinking = false;
    private bool isRising = false;
    private float nextSinkTime;

    void Start()
    {
        initialPosition = transform.position;
        nextSinkTime = Time.time + Random.Range(sinkIntervalMin, sinkIntervalMax);
    }

    void Update()
    {
        if (Time.time >= nextSinkTime && !isSinking && !isRising)
        {
            StartSinking();
        }

        if (isSinking)
        {
            Sink();
        }

        if (isRising)
        {
            Rise();
        }
    }

    void StartSinking()
    {
        isSinking = true;
    }

    void Sink()
    {
        float step = sinkSpeed * Time.deltaTime;
        transform.Translate(Vector3.down * step);

        if (transform.position.y <= initialPosition.y - sinkDistance)
        {
            isSinking = false;
            Invoke("StartRising", Random.Range(sinkIntervalMin, sinkIntervalMax)); // Randomize next sink time
        }
    }

    void StartRising()
    {
        isRising = true;
    }

    void Rise()
    {
        float step = riseSpeed * Time.deltaTime;
        transform.Translate(Vector3.up * step);

        if (transform.position.y >= initialPosition.y)
        {
            isRising = false;
            nextSinkTime = Time.time + Random.Range(sinkIntervalMin, sinkIntervalMax); // Randomize next sink time
        }
    }
}

