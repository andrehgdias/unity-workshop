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
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private float gravity = 20f;

    [Header("Headbob Parameters")]
    [SerializeField] private float walkBobSpeed = 10f;
    [SerializeField] private float walkBobAmountH = 0.025f;
    [SerializeField] private float walkBobAmountV = 0.05f;
    [SerializeField] private float sprintBobSpeed = 13.5f;
    [SerializeField] private float sprintBobAmountH = 0.08f;
    [SerializeField] private float sprintBobAmountV = 0.15f;

    [Header("Camera Parameters")]
    [SerializeField, Range(1, 10)] private float mouseSensitivityX = 2f;
    [SerializeField, Range(1, 10)] private float mouseSensitivityY = 2f;
    [SerializeField, Range(1, 180)] private float upperLookLimit = 80f;
    [SerializeField, Range(1, 180)] private float lowerLookLimit = 80f;

    private Camera playerCamera;
    private CharacterController characterController;
    public Vector3 moveDirection;
    private Vector2 currentInput;
    private float rotationAroundX = 0;
    private float defaultXPosition;
    private float defaultYPosition;
    private float timer;

    void Awake()
    {
        playerCamera = GetComponentInChildren<Camera>();
        characterController = GetComponent<CharacterController>();
        defaultXPosition = playerCamera.transform.localPosition.x;
        defaultYPosition = playerCamera.transform.localPosition.y;
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
        currentInput = new Vector2((IsSprinting ? sprintSpeed : walkSpeed) * Input.GetAxis("Vertical"), (IsSprinting ? sprintSpeed : walkSpeed) * Input.GetAxis("Horizontal"));
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

    private void HandleHeadBob()
    {
        if (!characterController.isGrounded) return;

        if(Mathf.Abs(moveDirection.x) > 0.1f || Mathf.Abs(moveDirection.z) > 0.1f)
        {
            timer += Time.deltaTime * (IsSprinting ? sprintBobSpeed : walkBobSpeed);
            playerCamera.transform.localPosition = new Vector3(
                defaultXPosition + Mathf.Cos(timer) * (IsSprinting ? sprintBobAmountH : walkBobAmountH),
                defaultYPosition + Mathf.Sin(timer) * (IsSprinting ? sprintBobAmountV : walkBobAmountV),
                playerCamera.transform.localPosition.z
            );
        }
    }

    private void ApplyFinalMovements()
    {
        if (!characterController.isGrounded)
            moveDirection.y -= gravity * Time.deltaTime;
        else if(Input.GetButtonDown("Jump"))
            moveDirection.y = jumpForce;

        if (characterController.velocity.y < -gravity)
            if(!characterController.isGrounded)
                moveDirection.y = -gravity;
            else
                moveDirection.y = 0;

        characterController.Move(moveDirection * Time.deltaTime);
        HandleHeadBob();
    }
}
