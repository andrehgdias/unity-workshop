using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public bool CanMove { get; private set; } = true;
    public bool IsSprinting => CanMove && Input.GetKey(KeyCode.LeftShift);

    [Header("Movement Parameters")]
    [SerializeField] private float walkSpeed = 4f;
    [SerializeField] private float sprintSpeed = 8f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float gravity = 13f;

    [Header("Camera Parameters")]
    [SerializeField, Range(1, 10)] private float mouseSensitivityX = 2f;
    [SerializeField, Range(1, 10)] private float mouseSensitivityY = 2f;
    [SerializeField, Range(1, 180)] private float upperLookLimit = 80f;
    [SerializeField, Range(1, 180)] private float lowerLookLimit = 80f;

    private Camera playerCamera;
    private CharacterController characterController;
    private Vector3 moveDirection;
    private Vector2 currentInput;
    private float rotationAroundX = 0;

    void Awake()
    {
        playerCamera = GetComponentInChildren<Camera>();
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (CanMove)
        {
            HandleMovementInput();
            HandleMouseLook();
            ApplyFinalMovements();
        }
    }

    private void HandleMovementInput()
    {
        currentInput = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
        float moveDirectionY = moveDirection.y;
        moveDirection = transform.forward * currentInput.x + transform.right * currentInput.y;
        moveDirection.y = moveDirectionY;
    }

    private void HandleMouseLook()
    {
        rotationAroundX -= Input.GetAxis("Mouse Y") * mouseSensitivityY;
        rotationAroundX = Mathf.Clamp(rotationAroundX, -upperLookLimit, lowerLookLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationAroundX, 0, 0);
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivityX);
    }

    private void ApplyFinalMovements()
    {
        if (!characterController.isGrounded)
            moveDirection.y -= gravity * Time.deltaTime;
        else if(Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpForce;
        }
        else
            moveDirection.y = -2f;
            
        characterController.Move(moveDirection * (IsSprinting ? sprintSpeed : walkSpeed) * Time.deltaTime);
    }
}
