using UnityEngine;
using UnityEngine.EventSystems;

public class Player_Move : MonoBehaviour
{
    private CharacterController controller;
    public Player_Input input;

    [Header("Player Stats")]
    [SerializeField] private float gravity = 9.81f;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpHeight;
    private float verticalVelocity;
    private float groundedTimer;
    private Vector3 moveDirection;
    private Vector3 velocity;

    //checks
    public bool isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Player_Input.jumpAction += Jump;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded)
        {
            groundedTimer = 0.2f;

            if(verticalVelocity < 0)
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
        if (groundedTimer > 0)
        {
            groundedTimer = 0;

            verticalVelocity += Mathf.Sqrt(jumpHeight * 2.0f * gravity);
        }
    }
}
