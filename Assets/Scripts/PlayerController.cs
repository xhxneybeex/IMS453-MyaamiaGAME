using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    CharacterController controller;
    public float speed = 3f;

    private float prevX;
    private float prevZ;

    [SerializeField] private Sprite player_down;
    [SerializeField] private Sprite player_left;
    [SerializeField] private Sprite player_right;
    [SerializeField] private Sprite player_up;
    private SpriteRenderer playerSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerSprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        prevX = transform.position.x;
        prevZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
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
}
