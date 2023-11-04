using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float JumpForce = 7f;
    public Animator Animator;
    public AudioSource FootStep;
    public HeartbeatSound Heartbeat;
    private Rigidbody m_RigidBody;
    private bool m_GroundedFlag;
    private int coinsCollected = 0;
    public float GridSize = 0.01f;
    public delegate void PlayerMoveHandler();
    public event PlayerMoveHandler OnPlayerMove;

    void Start()
    {
        // Get the Rigidbody component from the player GameObject.
        m_RigidBody = GetComponent<Rigidbody>();

        if (FootStep == null)
            FootStep = gameObject.AddComponent<AudioSource>();
        FootStep = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Move the player left or right
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        // Vector3 movement = new Vector3(-horizontalInput, 0f, -verticalInput) * MoveSpeed;
        // m_RigidBody.MovePosition(transform.position + movement * Time.deltaTime);
        if (horizontalInput != 0 || verticalInput != 0)
        {
            // Calculate the discrete movement
            Vector3 moveDirection = new Vector3(-horizontalInput, 0, -verticalInput).normalized;
            Vector3 moveAmount = moveDirection * GridSize;
            m_RigidBody.MovePosition(transform.position + moveAmount * Time.deltaTime);
        }

        // Player Jump
        if (Input.GetButtonDown("Jump") && m_GroundedFlag)
        {
            m_RigidBody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            Animator.SetTrigger("Jumping");
        }
        else if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            Animator.SetTrigger("Walking");
        }
        else
        {
            Animator.SetTrigger("Idle");
        }
        if (Input.GetButtonDown("Jump")|| Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            OnPlayerMove?.Invoke();         
            if (!Heartbeat.DetectPulse())
                PlayFootstepSound();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            // We collide with is the ground
            m_GroundedFlag = true;
        }
        if (collision.gameObject.CompareTag("coin"))
        {
            Animator.SetTrigger("Picking");
            // Deactivate the coin GameObject
            collision.gameObject.SetActive(false);
            // Increment the coins collected count
            coinsCollected++;

            // Print out the number of coins collected
            Debug.Log("Coins Collected: " + coinsCollected);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            // When not colliding, we are in the air (not grounded)
            m_GroundedFlag = false;
        }
    }
    
    private void PlayFootstepSound()
    {   
        FootStep.Play();
    }
}
