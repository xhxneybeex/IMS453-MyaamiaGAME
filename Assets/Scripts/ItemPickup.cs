using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item Item;

    public GameObject player;

    private PlayerController playerController;

    public Camera camera;

    private RaycastHit hit;

    [SerializeField] public static GameObject thisObject;


    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        camera = Camera.main;



    }

    void Pickup()
    {
        InventoryManager.Instance.Add(Item);
        Destroy(thisObject);
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
