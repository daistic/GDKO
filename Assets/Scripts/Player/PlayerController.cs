using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Input Action")]
    private Rigidbody2D playerRigidbody;
    public PlayerInput playerInput;

    [Header("Movement Modifier")]
    public float moveSpeed;
    public float jumpForce;

    [Header("Movement Bool")]
    [SerializeField] bool isMovingRight;
    [SerializeField] bool isMovingLeft;

    [Header("Talk Bool")]
    public bool isSpacebarPressed;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();

        playerInput = new PlayerInput();
        playerInput.Player.Enable();
    }

    private void OnEnable()
    {
        playerInput.Player.SpaceButton.performed += Talk;
        playerInput.Player.SpaceButton.canceled += Talk;
    }

    private void FixedUpdate()
    {
        if (isMovingRight)
        {
            playerRigidbody.AddForceX(moveSpeed);
        }

        if (isMovingLeft)
        {
            playerRigidbody.AddForceX(-moveSpeed);
        }
    }

    private void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
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
        if (ctx.performed)
        {
            isMovingLeft = true;
        }

        if (ctx.canceled)
        {
            isMovingLeft = false;
        }
    }

    private void Talk(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            isSpacebarPressed = true;
        }

        if (ctx.canceled)
        {
            isSpacebarPressed = false;
        }
    }

    public void activateMoveRight()
    {
        playerInput.Player.Dbutton.performed += MoveRight;
        playerInput.Player.Dbutton.canceled += MoveRight;
    }

    public void disableMoveRight()
    {
        playerInput.Player.Dbutton.performed -= MoveRight;
        playerInput.Player.Dbutton.canceled -= MoveRight;
    }
}
