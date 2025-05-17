using UnityEngine;

public class Player_Move : MonoBehaviour
{
    private CharacterController controller;
    public Player_Input input;

    [SerializeField] private float gravity;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpHeight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 moveInput = input.move.ReadValue<Vector3>();

        float horizontalMovement = moveInput.x;
        float verticalMovement = moveInput.y;
        Vector3 moveDirect = transform.forward * verticalMovement + transform.right * horizontalMovement;

        controller.Move(moveDirect * Time.deltaTime);
    }
}
