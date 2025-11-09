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
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 50))
        {
            Pickup();
            Debug.Log("iT WORKED");
        }
    }
}
