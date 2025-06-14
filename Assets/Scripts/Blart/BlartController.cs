using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BlartController : MonoBehaviour
{
    public float acceleration = 50f;
    public float rotationAcceleration = 10f;
    public float maxSpeed = 20f;
    public float maxAngularSpeed = 90f;

    private Rigidbody rb;
    private float moveInput;
    private float turnInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = maxAngularSpeed * Mathf.Deg2Rad; // Convert to radians/sec
    }

    void FixedUpdate()
    {
        // Get player input
        moveInput = Input.GetAxis("Vertical");   // W/S or Up/Down
        turnInput = Input.GetAxis("Horizontal"); // A/D or Left/Right

        // Apply directional acceleration (forward/backward)
        Vector3 desiredAcceleration = transform.forward * moveInput * acceleration;
        rb.AddForce(desiredAcceleration, ForceMode.Acceleration);

        // Apply rotational acceleration
        float torque = turnInput * rotationAcceleration;
        rb.AddTorque(Vector3.up * torque, ForceMode.Acceleration);

        // Clamp maximum speed manually
        Vector3 horizontalVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (horizontalVelocity.magnitude > maxSpeed)
        {
            Vector3 limitedVelocity = horizontalVelocity.normalized * maxSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }
}
