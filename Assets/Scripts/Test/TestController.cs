using UnityEngine;
using UnityEngine.InputSystem;

public class TestController : MonoBehaviour
{
    public float movementSpeed = 1f;
    Rigidbody2D playerRigidBody;
    TestInput testInput;

    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();

        testInput = new TestInput();
        testInput.Player.Enable();
        testInput.Player.Jump.performed += Jump_Performed;
    }

    private void FixedUpdate()
    {
        playerMovement();
    }

    private void playerMovement()
    {
        Vector2 inputVector = testInput.Player.Movement.ReadValue<Vector2>();
        playerRigidBody.AddForce(inputVector * movementSpeed);
    }

    private void Jump_Performed(InputAction.CallbackContext ctx)
    {
        playerRigidBody.AddForce(Vector2.up * 1000);
    }

    private void Debug_Performed(InputAction.CallbackContext ctx)
    {
        Debug.Log("bang");
    }

    public void changeSpacebar()
    {
        testInput.Player.Jump.performed -= Jump_Performed;
        testInput.Player.Jump.performed += Debug_Performed;
    }
}
