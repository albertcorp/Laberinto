using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 720f;

    public float lookSensitivity = 2f; // Sensibilidad del mouse
    private Vector2 movementInput;
    private Vector2 lookInput;      // Entrada de rotación del mouse
    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }

    public void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }

    private void Update()
    {
        Vector3 moveDirection = new Vector3(movementInput.x, 0f, movementInput.y);
        moveDirection = Camera.main.transform.TransformDirection(moveDirection);
        moveDirection.y = 0f;

        characterController.Move(moveDirection * speed * Time.deltaTime);

        Look();
    }

    private void Look()
    {
        float mouseX = lookInput.x * lookSensitivity;
        transform.Rotate(Vector3.up * mouseX);
    }
}
