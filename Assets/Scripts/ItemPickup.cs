using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item Item;
    public InventoryManager inventoryM;

    public GameObject player;

    private PlayerController playerController;

    public Camera camera;

    private RaycastHit hit;

    [SerializeField] public static bool thisHasBeenCollected = false;

    public bool isGloves;
    public bool isCoat;


    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        camera = Camera.main;
        if (InventoryManager.CoatCollected == true && isCoat == true)
        {
            gameObject.SetActive(false);
        }
        else if (InventoryManager.GlovesCollected == true && isGloves == true)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }


    void Pickup()
    {
        InventoryManager.Instance.Add(Item);
        thisHasBeenCollected = true;

        if (isGloves)
        {
            InventoryManager.GlovesCollected = true;
            Debug.Log("gloves collected was set to true");
        }
        else if (isCoat)
        {
            InventoryManager.CoatCollected = true;
            Debug.Log("coat collected was set to true");
        }


        gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {

        if (inventoryM.InventoryHUD.activeInHierarchy == false)
        {
            Pickup();
            Debug.Log("iT WORKED");
        }
        /*if (Physics.Raycast(camera.transform.position, camera.transform.TransformDirection(Vector3.up), out hit, Mathf.Max(5)))
        {
            Pickup();
            Debug.Log("");
        }*/
    }
}
