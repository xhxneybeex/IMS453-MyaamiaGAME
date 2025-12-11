//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private CharacterController controller;
    private Animator animator;

    public float speed = 3f;
    public bool movementEnabled = true;

    private Vector2 lastMoveDir = Vector2.down; // default facing down
    [SerializeField] private SceneController sceneController;

    public static Vector3 lastEntryPoint = new Vector3(8.866600036621094f, 0.37659740447998049f, -4.867871284484863f); // Player house

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        if ((SceneManager.GetActiveScene().name == "Level_1_Exterior") || (SceneManager.GetActiveScene().name == "Level_2_Exterior") || (SceneManager.GetActiveScene().name == "Town_Exterior"))
        {
            SceneController.is2DScene = false;
            PlayerPrefs.SetFloat("X", lastEntryPoint.x);
            PlayerPrefs.SetFloat("Y", lastEntryPoint.y);
            PlayerPrefs.SetFloat("Z", lastEntryPoint.z);
            gameObject.transform.position = new Vector3(PlayerPrefs.GetFloat("X"), PlayerPrefs.GetFloat("Y"), PlayerPrefs.GetFloat("Z") - 1); // Move player in front of most recent door
        } else
        {
            SceneController.is2DScene = true;
        }
    }

    void Update()
    {
        if (movementEnabled)
        {
            if (!SceneController.is2DScene)
                Movement3D();
            else
                Movement2D(); // still supports 2D fallback
        }
    }

    void Movement3D()
    {
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;

        controller.Move(movement * speed * Time.deltaTime);

        bool isMoving = Mathf.Abs(movement.x) > 0.01f || Mathf.Abs(movement.z) > 0.01f;

        if (isMoving)
        {
            lastMoveDir = new Vector2(movement.x, movement.z);
        }

        float animX = isMoving ? movement.x : lastMoveDir.x;
        float animY = isMoving ? movement.z : lastMoveDir.y;

        animator.SetFloat("MoveX", animX);
        animator.SetFloat("MoveY", animY);
        animator.SetBool("IsMoving", isMoving);

        // Optional debug:
        // Debug.Log($"animX={animX}, animY={animY}, isMoving={isMoving}");

        Camera.main.transform.localRotation = Quaternion.Euler(20f, 0f, 0f);
        Camera.main.transform.localPosition = new Vector3(0f, 3.1f, -7.63f);
    }

    void Movement2D()
    {
        // Read input
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized;

        // Move the player
        controller.Move(movement * speed * Time.deltaTime);

        // Determine if moving
        bool isMoving = movement.sqrMagnitude > 0.01f;

        // Remember the last facing direction so we keep looking the same way when idle
        if (isMoving)
        {
            lastMoveDir = new Vector2(movement.x, movement.y);
        }

        // Feed animator parameters
        float animX = isMoving ? movement.x : lastMoveDir.x;
        float animY = isMoving ? movement.y : lastMoveDir.y;

        animator.SetFloat("MoveX", animX);
        animator.SetFloat("MoveY", animY);
        animator.SetBool("IsMoving", isMoving);

        // Stop animating when idle (so feet stop)
        animator.speed = isMoving ? 1f : 0f;
        Camera.main.transform.localPosition = new Vector3(0f, 0f, -7.63f);
        Camera.main.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
    }
}

