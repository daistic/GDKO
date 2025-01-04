using UnityEngine;
using UnityEngine.InputSystem;

public class TestPlayerControl : MonoBehaviour
{
    [Header("Input Action")]
    private Rigidbody2D playerRigidbody;
    public PlayerInput playerInput;

    [Header("Movement Modifier")]
    public float moveSpeed;
    public float jumpForce;
    public float maxVelocity;

    [Header("Movement Bool")]
    [SerializeField] bool isMovingRight;
    [SerializeField] bool isMovingLeft;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();

        playerInput = new PlayerInput();
        playerInput.Player.Enable();
    }

    private void OnEnable()
    {
        playerInput.Player.RArrowKey.performed += MoveRight;
        playerInput.Player.RArrowKey.canceled += MoveRight;

        playerInput.Player.LArrowKey.performed += MoveLeft;
        playerInput.Player.LArrowKey.canceled += MoveLeft;

        playerInput.Player.UArrowKey.performed += Jump;
    }

    private void FixedUpdate()
    {
        if (isMovingRight && playerRigidbody.linearVelocityX < maxVelocity)
        {
            playerRigidbody.AddForceX(moveSpeed);
        }

        if (isMovingLeft && playerRigidbody.linearVelocityX > -maxVelocity)
        {
            playerRigidbody.AddForceX(-moveSpeed);
        }
    }

    private void Jump(InputAction.CallbackContext ctx)
    {
        Debug.Log(ctx);
        if (ctx.performed)
        {
            Debug.Log(jumpForce);
            playerRigidbody.AddForceY(jumpForce);
        }
    }

    private void MoveRight(InputAction.CallbackContext ctx)
    {
        Debug.Log(ctx);
        if (ctx.performed)
        {
            isMovingRight = true;
        }

        if (ctx.canceled)
        {
            isMovingRight = false;
        }
    }

    private void MoveLeft(InputAction.CallbackContext ctx)
    {
        Debug.Log(ctx);
        if (ctx.performed)
        {
            isMovingLeft = true;
        }

        if (ctx.canceled)
        {
            isMovingLeft = false;
        }
    }

    public void handleMoveRight(bool isMoveRightActivated)
    {
        if (!isMoveRightActivated)
        {
            playerInput.Player.RArrowKey.performed += MoveRight;
            playerInput.Player.RArrowKey.canceled += MoveRight;
        }

        else
        {
            playerInput.Player.RArrowKey.performed -= MoveRight;
            playerInput.Player.RArrowKey.canceled -= MoveRight;
        }
    }
}
