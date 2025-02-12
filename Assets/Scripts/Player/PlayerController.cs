using System.Collections;
using Unity.VisualScripting;
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

    [Header("Sword")]
    [SerializeField] GameObject sword;
    [SerializeField] float swordAttackDelay = 2f;
    float swordNextAttack = 0;

    [Header("Shoot")]
    [SerializeField] GameObject bullet;
    [SerializeField] float shootCooldown = 1.5f;
    float nextShot = 0;

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

    private void SwordAttack(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (swordNextAttack < Time.time)
            {      
                Coroutine showingSword = StartCoroutine(swordTime());
                swordNextAttack = Time.time + swordAttackDelay;
            }
        }
    }

    private IEnumerator swordTime()
    {
        BoxCollider2D swordCollider = sword.GetComponent<BoxCollider2D>();

        swordCollider.enabled = true;
        sword.transform.position = this.transform.position + new Vector3(1.3f, 0, 0);
        sword.transform.rotation = Quaternion.Euler(0, 0, 0);

        yield return new WaitForSeconds(2f);

        swordCollider.enabled = false;
        sword.transform.position = this.transform.position;
        sword.transform.rotation = Quaternion.Euler(0, 0, 45);
    }

    private void Shoot(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (nextShot < Time.time)
            {
                BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
                Instantiate(bullet, transform.position + new Vector3(0, boxCollider2D.bounds.extents.y, 0), Quaternion.identity);
                nextShot = Time.time + shootCooldown;
            }            
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

    public void handleMoveSideways(bool isMoveSidewaysActivated)
    {
        if (isMoveSidewaysActivated)
        {
            playerInput.Player.RArrowKey.performed += MoveRight;
            playerInput.Player.RArrowKey.canceled += MoveRight;
            playerInput.Player.LArrowKey.performed += MoveLeft;
            playerInput.Player.LArrowKey.canceled += MoveLeft;
        }

        else
        {
            playerInput.Player.RArrowKey.performed -= MoveRight;
            playerInput.Player.RArrowKey.canceled -= MoveRight;
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

    public void handleSword(bool isSwordActivated)
    {
        if (isSwordActivated)
        {
            sword.SetActive(true);
            playerInput.Player.ZKey.performed += SwordAttack;
        }

        else
        {
            sword.SetActive(false);
            playerInput.Player.ZKey.performed -= SwordAttack;
        }
    }

    public void handleShoot(bool isShootActivated)
    {
        if (isShootActivated)
        {
            playerInput.Player.Shoot.performed += Shoot;
        }

        else
        {
            playerInput.Player.Shoot.performed -= Shoot;
        }
    }
}
