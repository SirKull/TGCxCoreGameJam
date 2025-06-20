using UnityEngine;
using UnityEngine.Events;

public class Player_Move : MonoBehaviour
{
    private CharacterController controller;
    private CapsuleCollider capsuleCollider;
    public Player_Input input;
    public GameObject pidgeModel;

    public GameObject pauseObject;

    [Header("Player Stats")]
    [SerializeField] private float defaultGravity = 9.81f;
    [SerializeField] private float glideGravity = 4.9f;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private int maxJump = 2;
    [SerializeField] private float smoothTime = 0.05f;
    [SerializeField] private float slideSpeed = 6f;

    public bool canMove;

    private float gravity;
    private int jumpCount;
    private float verticalVelocity;
    public float groundedTimer;
    private float currentVelocity;

    private Vector3 moveDirection;
    private Vector3 velocity;

    //checks
    public bool isGrounded;
    public bool isMoving;
    public bool onSlope;
    private Vector3 hitNormal;

    //events
    public UnityEvent jumpEvent = new UnityEvent();
    public UnityEvent landEvent = new UnityEvent();
    public UnityEvent glideEvent = new UnityEvent();
    public UnityEvent midAirEvent = new UnityEvent();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jumpCount = maxJump;
        gravity = defaultGravity;

        controller = GetComponent<CharacterController>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        Player_Input.jumpAction += Jump;
        Player_Input.standAction += Stand;
        Player_Input.glideAction += StartGlide;
        Player_Input.glideStopAction += StopGlide;
        Player_Input.pauseAction += Pause;
    }

    // Update is called once per frame
    void Update()
    {
        //store character controller grounded
        isGrounded = controller.isGrounded;
        //store onSlope
        onSlope = Vector3.Angle(Vector3.up, hitNormal) >= controller.slopeLimit;

        if (isGrounded)
        {
            //check if player lands
            if (groundedTimer < 0f)
            {
                landEvent?.Invoke();
            }

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

        if (groundedTimer >= 0)
        {
            groundedTimer -= Time.deltaTime;
        }

        if (canMove)
        {
            MovePlayer();
        }
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
        moveDirection = -transform.forward * verticalMovement + -transform.right * horizontalMovement;

        //apply move direction to player velocity
        velocity = moveDirection * moveSpeed;
        
        //account for vertical velocity
        velocity.y = verticalVelocity;

        if (onSlope)
        {
            velocity.x += ((1f - hitNormal.y) * hitNormal.x) * slideSpeed;
            velocity.z += ((1f - hitNormal.y) * hitNormal.z) * slideSpeed;
        }

        //move controller
        controller.Move(velocity * Time.deltaTime);

        if (moveInput.sqrMagnitude == 0)
        {
            isMoving = false;
            return;
        }

        isMoving = true;
        //store target angle based on the move direction
        //convert radians to degrees
        var targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
        var angle = Mathf.SmoothDampAngle(pidgeModel.transform.eulerAngles.y, targetAngle, ref currentVelocity, smoothTime);
        //apply the target angle to the pidgeModel only
        pidgeModel.transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        hitNormal = hit.normal;
    }

    private void Jump()
    {
        if (canMove)
        {
            if (groundedTimer > 0 && isGrounded || jumpCount > 0)
            {
                jumpEvent?.Invoke();
                jumpCount--;

                groundedTimer = 0f;

                verticalVelocity += Mathf.Sqrt(jumpHeight * 2.0f * gravity);
            }
        }
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

    private void Pause()
    {
        pauseObject.SetActive(true);
    }
}
