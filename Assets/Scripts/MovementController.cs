using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    Vector2 moveInput;
    CharacterController controller;

    [SerializeField]
    float moveSpeed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        controller.Move(moveSpeed * Time.deltaTime * new Vector3(moveInput.x, 0, moveInput.y));
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
