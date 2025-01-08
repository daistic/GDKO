using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Input Action")]
    private Rigidbody2D playerRigidbody;
    public PlayerInput playerInput;

    [Header("Movement Modifier")]
    public float jumpForce;
    public float maxVelocity;

    [Header("Movement Bool")]
    [SerializeField] bool isMovingRight;
    [SerializeField] bool isMovingLeft;

    [Header("Layers")]
    [SerializeField] LayerMask platform;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();

        playerInput = new PlayerInput();
        playerInput.Player.Enable();
        playerInput.Player.QKey.performed += OpenComponentMenu;
    }

    private void FixedUpdate()
    {
        if (isMovingRight && playerRigidbody.linearVelocityX < maxVelocity)
        {
            playerRigidbody.linearVelocityX = maxVelocity;
        }

        if (isMovingLeft && playerRigidbody.linearVelocityX > -maxVelocity)
        {
            playerRigidbody.linearVelocityX = -maxVelocity;
        }
    }

    private void MoveRight(InputAction.CallbackContext ctx)
    {
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
        if (ctx.performed)
        {
            isMovingLeft = true;
        }

        if (ctx.canceled)
        {
            isMovingLeft = false;
        }
    }

    private void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (checkIsGrounded())
            {
                playerRigidbody.linearVelocityY = jumpForce;
            }
        }
    }

    private bool checkIsGrounded()
    {
        float ExtraHeight = 0.1f;
        BoxCollider2D playerBoxColidder = this.GetComponent<BoxCollider2D>();

        RaycastHit2D hit = Physics2D.BoxCast(playerBoxColidder.bounds.center, playerBoxColidder.bounds.size, 0, Vector2.down, ExtraHeight, platform);

        if (hit.collider != null)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    private void OpenComponentMenu(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            UIManager.Instance.toggleComponentsMenu();
        }
    }

    public void handleMoveRight(bool isMoveRightActivated)
    {
        if (isMoveRightActivated)
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

    public void handleMoveLeft(bool isMoveLeftActivated)
    {
        if (isMoveLeftActivated)
        {
            playerInput.Player.LArrowKey.performed += MoveLeft;
            playerInput.Player.LArrowKey.canceled += MoveLeft;
        }

        else
        {
            playerInput.Player.LArrowKey.performed -= MoveLeft;
            playerInput.Player.LArrowKey.canceled -= MoveLeft;
        }
    }

    public void handleJump(bool isJumpActivated)
    {
        if (isJumpActivated)
        {
            playerInput.Player.UArrowKey.performed += Jump;
        }

        else
        {
            playerInput.Player.UArrowKey.performed -= Jump;
        }
    }
}
