using UnityEngine;

public class PlayerSurfaceRotationRight : MonoBehaviour
{
    private bool isOnConveyorBelt = false;
    private Vector3 conveyorBeltDirection;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RotatingObjRight"))
        {
            isOnConveyorBelt = true;
            conveyorBeltDirection = collision.transform.forward; // Get the direction of the conveyor belt
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("RotatingObjRight"))
        {
            isOnConveyorBelt = false;
            conveyorBeltDirection = Vector3.zero; // Reset the direction when leaving the conveyor belt
        }
    }

    void FixedUpdate()
    {
        if (isOnConveyorBelt)
        {
            // Apply a constant force in the direction of the conveyor belt
            rb.AddForce(conveyorBeltDirection * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }
}






