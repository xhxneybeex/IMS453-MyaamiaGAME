using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item Item;

    public GameObject player;

    private PlayerController playerController;

    public Camera camera;

    private RaycastHit hit;


    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        camera = Camera.main;


    }

    void Pickup()
    {
        InventoryManager.Instance.Add(Item);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        if (Physics.Raycast(camera.transform.position, camera.transform.TransformDirection(Vector3.forward), out hit, Mathf.Max(5)))
        {
            Pickup();
        }
    }
}
