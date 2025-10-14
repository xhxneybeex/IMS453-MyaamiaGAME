using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    CharacterController controller;
    public float speed = 3f;
    public bool movementEnabled = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movementEnabled)
        {
            Movement();
        }
    }

    void Movement()
    {
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized; //.normalize stops player from moving faster diagonally

        //if (movement.magnitude >= 0.1f)
        //{
        controller.Move(movement * speed * Time.deltaTime);
        //}
    }
}
