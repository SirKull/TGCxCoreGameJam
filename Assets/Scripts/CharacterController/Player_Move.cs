using UnityEditor.SceneTemplate;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Player_Move : MonoBehaviour
{
    private CharacterController controller;
    private CapsuleCollider capsuleCollider;
    public Player_Input input;

    [Header("Player Stats")]
    [SerializeField] private float defaultGravity = 9.81f;
    [SerializeField] private float glideGravity = 4.9f;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private int maxJump = 2;

    private float gravity;
    private int jumpCount;
    private float verticalVelocity;
    private float groundedTimer;

    private Vector3 moveDirection;
    private Vector3 velocity;

    //checks
    public bool isGrounded;

    //events
    public UnityEvent jumpEvent = new UnityEvent();
    public UnityEvent crouchEvent = new UnityEvent();
    public UnityEvent glideEvent = new UnityEvent();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jumpCount = maxJump;
        gravity = defaultGravity;

        controller = GetComponent<CharacterController>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        Player_Input.jumpAction += Jump;
        Player_Input.crouchAction += Crouch;
        Player_Input.standAction += Stand;
        Player_Input.glideAction += StartGlide;
        Player_Input.glideStopAction += StopGlide;
    }

    // Update is called once per frame
    void Update()
    {
        //store character controller grounded
        isGrounded = controller.isGrounded;

        if (isGrounded)
        {
            //reset the grounded timer so the player can't spam jump
            groundedTimer = 0.2f;

            //reset jump count
            jumpCount = maxJump;

            //reset gravity 
            gravity = defaultGravity;

            // 0 out the vertical velocity when player lands
            // jumping was inconsistent
            if (verticalVelocity < 0)
            {
                verticalVelocity = 0;
            }
        }

        if(groundedTimer > 0)
        {
            groundedTimer -= Time.deltaTime;
        }

        MovePlayer();
    }

    private void MovePlayer()
    {
        //apply gravity
        verticalVelocity -= gravity * Time.deltaTime;

        //store moveinput from the vector 2
        Vector3 moveInput = input.move.ReadValue<Vector2>();
        moveInput = Vector3.ClampMagnitude(moveInput, 1f); //prevent fast diagonal

        //store move input x and y
        float horizontalMovement = moveInput.x;
        float verticalMovement = moveInput.y;

        //store move direction
        moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;

        //apply move direction to player velocity
        velocity = moveDirection * moveSpeed;
        
        //account for vertical velocity
        velocity.y = verticalVelocity;

        //move controller
        controller.Move(velocity * Time.deltaTime);
    }

    private void Jump()
    {
        if (groundedTimer > 0 && isGrounded || jumpCount > 0)
        {
            jumpEvent?.Invoke();
            jumpCount--;

            groundedTimer = 0f;

            verticalVelocity += Mathf.Sqrt(jumpHeight * 2.0f * gravity);
        }
    }

    private void Crouch()
    {
        crouchEvent?.Invoke();
        capsuleCollider.height = 1f;
        controller.height = 1f;
    }
    private void Stand()
    {
        capsuleCollider.height = 2f;
        controller.height = 2f;
    }

    private void StartGlide()
    {
        if (!isGrounded)
        {
            glideEvent?.Invoke();
            //reduce overall gravity
            gravity = glideGravity;
            //reset vertical velocity to prevent super jumping
            verticalVelocity = 0f;
        }
    }
    private void StopGlide()
    {
        //reset gravity
        gravity = defaultGravity;
    }
}
