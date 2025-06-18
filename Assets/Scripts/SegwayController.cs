using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegwayController : MonoBehaviour
{

    public float moveMult = 5;
    public float tiltRate = 1;
    public float turnRateVel = 10;
    public float maxTurnRate = 10;
    public float initTurnVel = 1;

    public Vector2 maxMoveAngle = new Vector2(25f, 25f);
    public float jumpForce = 1000;
    public float maxVelocity = 5f;

    public Transform handle;
    Quaternion initRotation;

    Vector2 velocity = new Vector2(0,0);

    float rotationY = 0f;
    float rotationYVelocity = 0f;
    Vector3 moveInput;

    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initRotation = handle.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.MovePosition(rb.position + velocity.x * Time.deltaTime * transform.forward);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        float moveForce = moveInput.z * moveMult;
        velocity.x += moveForce * Time.deltaTime;
        if (moveInput.z == 0) velocity.x *= 0.95f;
        velocity.x = Mathf.Clamp(velocity.x, -maxVelocity, maxVelocity);

        Debug.DrawRay(rb.position, velocity.x * transform.forward, Color.red);
        // rb.MovePosition(rb.position + velocity.x * Time.fixedDeltaTime * transform.forward);

        // Quaternion newRotation = Quaternion.Euler(0, moveInput.x * turnRate * Time.fixedDeltaTime, 0);
        float thisrotationY = moveInput.x * turnRateVel * Time.fixedDeltaTime;
        if (((Mathf.Sign(rotationYVelocity) != Mathf.Sign(moveInput.x)) && moveInput.x != 0 && rotationYVelocity != 0) || (moveInput.x != 0 && Mathf.Abs(rotationYVelocity) < initTurnVel)) rotationYVelocity = Mathf.Sign(moveInput.x) * initTurnVel;
        // if (moveInput.x > 0 != rotationYVelocity > 0) rotationYVelocity = 0f;
        rotationYVelocity += thisrotationY!=0 ? thisrotationY * Time.fixedDeltaTime : -rotationYVelocity*0.3f;
        if (Mathf.Abs(rotationYVelocity) < 0.0001) rotationYVelocity = 0;
        rotationYVelocity = Mathf.Clamp(rotationYVelocity, -maxTurnRate, maxTurnRate);
        rotationY += rotationYVelocity;
        // Debug.Log(rotationYVelocity);
        Quaternion thisRotation = Quaternion.AngleAxis(rotationYVelocity, Vector3.up);
        transform.rotation *= thisRotation;

        Quaternion turnRotationY = Quaternion.AngleAxis(rotationY, Vector3.forward); // foward cus of the dumb rotation of the segway model


        float xRotation = moveInput.x * -maxMoveAngle.x;
        float zRotation = moveInput.z * -maxMoveAngle.y;
        Quaternion targetRotation = initRotation * turnRotationY * Quaternion.Euler(xRotation, -zRotation, 0);
        handle.rotation = Quaternion.RotateTowards(handle.rotation, targetRotation, tiltRate * Time.fixedDeltaTime);
    }
}
