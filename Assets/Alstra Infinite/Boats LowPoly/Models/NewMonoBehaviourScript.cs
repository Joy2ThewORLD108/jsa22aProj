using UnityEngine;


public class BoatMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float forwardSpeed = 10f;
    public float turnSpeed = 50f;

    private Rigidbody rb;
    private float moveInput;
    private float turnInput;

    void Start()
    {
        // Get the Rigidbody component attached to the boat
        rb = GetComponent<Rigidbody>();

        // Optional: Drag helps the boat slow down naturally in water
        rb.drag = 1f;
        rb.angularDrag = 1f;
    }

    void Update()
    {
        // Get input from WASD or Arrow keys
        moveInput = Input.GetAxis("Vertical");   // W/S or Up/Down
        turnInput = Input.GetAxis("Horizontal"); // A/D or Left/Right
    }

    void FixedUpdate()
    {
        MoveBoat();
        TurnBoat();
    }

    void MoveBoat()
    {
        // Apply force in the direction the boat is facing
        Vector3 movement = transform.forward * moveInput * forwardSpeed;
        rb.AddForce(movement, ForceMode.Acceleration);
    }

    void TurnBoat()
    {
        // Rotate the boat based on horizontal input
        float rotation = turnInput * turnSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, rotation, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}