using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        // Get the Rigidbody component from the player GameObject.
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check for ground
        CheckGroundStatus();

        // Move the player left or right
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed;
        rb.MovePosition(transform.position + movement * Time.deltaTime);

        // Player Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Assume everything we collide with is the ground
        isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        // When not colliding, we are in the air (not grounded)
        isGrounded = false;
    }

    void CheckGroundStatus()
    {
        // Here you can add additional logic to check if the player is actually grounded,
        // to prevent jumping while in the air. This could be done using Raycast.
    }
}