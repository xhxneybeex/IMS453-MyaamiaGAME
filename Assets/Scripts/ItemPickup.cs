using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item Item;

    public GameObject player;

    private PlayerController playerController;

    public Camera camera;

    private RaycastHit hit;

    [SerializeField] public static bool thisHasBeenCollected = false;


    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        camera = Camera.main;
        if (thisHasBeenCollected == true)
        {
            InventoryManager.Instance.Add(Item);
            Destroy(gameObject);
        }
    }

    void Pickup()
    {
        InventoryManager.Instance.Add(Item);
        thisHasBeenCollected = true;
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        
            Pickup();
            Debug.Log("iT WORKED");
        
        
        /*if (Physics.Raycast(camera.transform.position, camera.transform.TransformDirection(Vector3.up), out hit, Mathf.Max(5)))
        {
            Pickup();
            Debug.Log("");
        }*/
    }
}
