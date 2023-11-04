using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float JumpForce = 7f;
    public Animator animator;
    public AudioClip footstepSound;

    private Rigidbody m_RigidBody;
    private bool m_GroundedFlag;
    private AudioSource footStep;
    private float footstepRate = 0.5f;
    
    public delegate void PlayerMoveHandler();
    public event PlayerMoveHandler OnPlayerMove;
    private float nextFootstepTime = 0f;

    void Start()
    {
        // Get the Rigidbody component from the player GameObject.
        m_RigidBody = GetComponent<Rigidbody>();

        footStep = GetComponent<AudioSource>();
        if (footStep == null) {
            footStep = gameObject.AddComponent<AudioSource>();
        }
        // Configure the AudioSource for footsteps (if necessary)
        footStep.playOnAwake = false;
        footStep.loop = false;
        footStep.volume = 0.3f;
    }

    void Update()
    {
        // Check for ground
        CheckGroundStatus();

        // Move the player left or right
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(-horizontalInput, 0f, -verticalInput) * MoveSpeed;
        m_RigidBody.MovePosition(transform.position + movement * Time.deltaTime);

        // Player Jump
        if (Input.GetButtonDown("Jump") && m_GroundedFlag)
        {
            m_RigidBody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            animator.SetTrigger("Jumping");
        }
        else if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            animator.SetTrigger("Walking");
        }
        else
        {
            animator.SetTrigger("Idle");
        }
        if (Input.GetButtonDown("Jump")|| Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            OnPlayerMove?.Invoke();
        }
          if (movement.magnitude > 0 && m_GroundedFlag && Time.time >= nextFootstepTime)
        {
            m_RigidBody.MovePosition(transform.position + movement * Time.deltaTime);
            PlayFootstepSound();
            OnPlayerMove?.Invoke();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Assume everything we collide with is the ground
        m_GroundedFlag = true;
    }

    void OnCollisionExit(Collision collision)
    {
        // When not colliding, we are in the air (not grounded)
        m_GroundedFlag = false;
    }

    void CheckGroundStatus()
    {
        // Here you can add additional logic to check if the player is actually grounded,
        // to prevent jumping while in the air. This could be done using Raycast.
    }

       private void PlayFootstepSound()
    {
        if (!footStep.isPlaying)
        {
            footStep.clip = footstepSound;
            footStep.Play();
            nextFootstepTime = Time.time + footstepRate; // Set the time for the next footstep
        }
    }



}