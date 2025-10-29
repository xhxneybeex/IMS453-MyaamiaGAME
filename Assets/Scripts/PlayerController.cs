using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    CharacterController controller;
    public float speed = 3f;
    public bool movementEnabled = true;

    private float prevX;
    private float prevZ;
    private float prevY;

    [SerializeField] private Sprite player_down;
    [SerializeField] private Sprite player_left;
    [SerializeField] private Sprite player_right;
    [SerializeField] private Sprite player_up;
    private SpriteRenderer playerSprite;
    [SerializeField] private SceneController sceneController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerSprite = GetComponentInChildren<SpriteRenderer>();
        sceneController = GetComponent<SceneController>();
    }

    private void Start()
    {
        prevX = transform.position.x;
        prevZ = transform.position.z;
        prevY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (movementEnabled)
        {
            if (SceneController.is2DScene == false)
            {
                Movement3D();
            } 
            else if (SceneController.is2DScene == true)
            {
                Movement2D();
            }
            
        }
    }

    void Movement3D()
    {
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized; //.normalize stops player from moving faster diagonally

        controller.Move(movement * speed * Time.deltaTime);

        if (transform.position.z > prevZ)
        {
            playerSprite.sprite = player_up;
        }
        if (transform.position.x > prevX)
        {
            playerSprite.sprite = player_right;
        }

        if (transform.position.x < prevX)
        {
            playerSprite.sprite = player_left;
        }
        if (transform.position.z < prevZ)
        {
            playerSprite.sprite = player_down;
        }

        prevX = transform.position.x;
        prevZ = transform.position.z;
    }

    void Movement2D()
    {
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized; //.normalize stops player from moving faster diagonally

        controller.Move(movement * speed * Time.deltaTime);

        if (transform.position.y > prevY)
        {
            playerSprite.sprite = player_up;
        }
        if (transform.position.x > prevX)
        {
            playerSprite.sprite = player_right;
        }

        if (transform.position.x < prevX)
        {
            playerSprite.sprite = player_left;
        }
        if (transform.position.y < prevY)
        {
            playerSprite.sprite = player_down;
        }

        prevX = transform.position.x;
        prevY = transform.position.y;
    }
}

