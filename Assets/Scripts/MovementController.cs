using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    Vector2 moveInput;
    bool isJumpPressed;
    CharacterController controller;
    bool isGrounded;
    float yVelocity = 0f;
    float yCoordinate;
    Vector3 spawnPosition;

    [SerializeField] float moveSpeed = 5f;

    [SerializeField] float gravity = -10f;

    [SerializeField] float jumpHeight = 1f;

    [SerializeField] float rotationAngle;

    [SerializeField] Vector3 rotationAxis;

    public float YVelocity { get => yVelocity; set => yVelocity = value; }
    public float RotationAngle { get => rotationAngle; set => rotationAngle = value; }
    public Vector3 RotationAxis { get => rotationAxis; set => rotationAxis = value; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        yCoordinate = transform.position.y;
        spawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float originalYVelocity = yVelocity;
        isGrounded = controller.isGrounded;

        if (isGrounded)
        {
            if (isJumpPressed) // Can only jump while grounded
            {
                yVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
            else if (yVelocity < 0)
            {
                yVelocity = -2f; // So object stays grounded
            }
        }
        else
        {
            yVelocity += gravity * Time.deltaTime;
        }

        // If player should be going up but does not go up, that means they have hit the ceiling
        // Set yVelocity to 0 so they become unstuck from the ceiling
        float newYCoordinate = transform.position.y;
        float expectedChangeInY = originalYVelocity * Time.deltaTime;
        float actualChangeInY = newYCoordinate - yCoordinate;
        yCoordinate = newYCoordinate;
        if (actualChangeInY == 0 && expectedChangeInY > 0)
        {
            yVelocity = 0;
        }

        float xVelocity = moveSpeed * moveInput.x;
        float zVelocity = moveSpeed * moveInput.y;

        Vector3 movementVec = new Vector3(xVelocity, yVelocity, zVelocity) * Time.deltaTime;
        movementVec = RotateVector(movementVec, rotationAxis, rotationAngle);
        controller.Move(movementVec);

        isJumpPressed = false; // Makes it so pressing space once does not make you jump forever

        if (yCoordinate < -5)
        {
            transform.position = spawnPosition;
            yVelocity = 0;
        }
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        print("Moving");
    }

    public void OnJump(InputValue value)
    {
        isJumpPressed = true;
        print("Jumping");
    }

    private Vector3 RotateVector(Vector3 original, Vector3 axis, float angle)
    {
        return Quaternion.AngleAxis(angle, axis) * original;
    }
}
