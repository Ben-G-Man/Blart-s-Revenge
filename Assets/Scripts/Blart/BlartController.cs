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

  public float jumpforce = 1;

  private bool jumpInput;

  void Start()
  {
    rb = GetComponent<Rigidbody>();
    rb.maxAngularVelocity = maxAngularSpeed * Mathf.Deg2Rad; // Convert to radians/sec
  }

  void Update()
  {
    jumpInput = Input.GetKeyDown(KeyCode.Space);
    if (jumpInput && !MallStateDTO.isPaused)
    {
      rb.AddForce(Vector3.up * jumpforce);
    }
  }

  void FixedUpdate()
  {
    if (!MallStateDTO.isPaused)
    {
      moveInput = Input.GetAxis("Vertical");
      turnInput = Input.GetAxis("Horizontal");
    }
    else
    {
      moveInput = 0f;
      turnInput = 0f;
    }

    Vector3 desiredAcceleration = transform.forward * moveInput * acceleration;
    rb.AddForce(desiredAcceleration, ForceMode.Acceleration);

    float torque = turnInput * rotationAcceleration;
    rb.AddTorque(Vector3.up * torque, ForceMode.Acceleration);

    Vector3 horizontalVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
    if (horizontalVelocity.magnitude > maxSpeed)
    {
      Vector3 limitedVelocity = horizontalVelocity.normalized * maxSpeed;
      rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
    }
  }
}
