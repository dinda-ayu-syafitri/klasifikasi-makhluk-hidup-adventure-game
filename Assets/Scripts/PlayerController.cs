using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class PlayerController : MonoBehaviour, IDataPersistence
{
    [SerializeField]
    public float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    [SerializeField]
    private float rotationSpeed = 5f;

    private CharacterController controller;
    private PlayerInput playerInput;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Transform cameraTransform;

    private InputAction moveAction;
    private InputAction jumpAction;

    private Animator animator;

    public bool canMove = true;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        cameraTransform = Camera.main.transform;
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        animator = GetComponentInChildren<Animator>();
    }

    public void LoadData(GameData gameData)
    {
        Vector3 newPosition = new Vector3(gameData.playerPosition.x, 10f, gameData.playerPosition.z);
        this.transform.localPosition = newPosition;
        Debug.Log("Player position loaded");
    }

    public void SaveData(GameData gameData)
    {
        gameData.playerPosition = this.transform.localPosition;
        Debug.Log("Player position: " + gameData.playerPosition);
        Debug.Log("Player Local Postition: " + this.transform.localPosition);
    }

    private void Update()
    {
        if (!canMove)
        {
            // If the player can't move, just return early from Update
            return;
        }

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        move = move.x * cameraTransform.right.normalized + move.z * cameraTransform.forward.normalized;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (jumpAction.triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            Debug.Log("Jump");
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        bool isMoving = input.magnitude > 0;

        animator.SetBool("isMove", isMoving);

        // Rotate the player to the direction of movement
        float targetAngle = cameraTransform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, targetAngle, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    public void FreezePlayer()
    {
        canMove = false;
        animator.SetBool("isMove", false);  
        playerVelocity = Vector3.zero; 
    }

}