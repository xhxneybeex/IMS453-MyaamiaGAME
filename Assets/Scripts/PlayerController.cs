//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private CharacterController controller;
    private Animator animator;
    private AudioSource myAudio;

    public float speed = 3f;
    public bool movementEnabled = true;

    private Vector2 lastMoveDir = Vector2.down; // default facing down
    [SerializeField] private SceneController sceneController;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        sceneController = GetComponent<SceneController>();
        myAudio = GetComponent<AudioSource>();
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
            // Enable steps SFX
            if (!myAudio.isPlaying)
            {
                myAudio.Play();
            }
        } else
        {
            if (myAudio.isPlaying)
            {
                myAudio.Stop();
            }
        }

            float animX = isMoving ? movement.x : lastMoveDir.x;
        float animY = isMoving ? movement.z : lastMoveDir.y;

        animator.SetFloat("MoveX", animX);
        animator.SetFloat("MoveY", animY);
        animator.SetBool("IsMoving", isMoving);

        // Optional debug:
        Debug.Log($"animX={animX}, animY={animY}, isMoving={isMoving}");
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
            if (!myAudio.isPlaying)
            {
                myAudio.Play();
            }
        } else
        {
            if (myAudio.isPlaying)
            {
                myAudio.Stop();
            }
        }

        // Feed animator parameters
        float animX = isMoving ? movement.x : lastMoveDir.x;
        float animY = isMoving ? movement.y : lastMoveDir.y;

        animator.SetFloat("MoveX", animX);
        animator.SetFloat("MoveY", animY);
        animator.SetBool("IsMoving", isMoving);

        // Stop animating when idle (so feet stop)
        animator.speed = isMoving ? 1f : 0f;
    }
}

