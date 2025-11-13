using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item Item;

    public GameObject player;

    private PlayerController playerController;

    public Camera camera;

    private RaycastHit hit;

    private AudioManager audioMan;


    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        audioMan = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        camera = Camera.main;


    }

    void Pickup()
    {
        InventoryManager.Instance.Add(Item);
        audioMan.PlaySFX(0);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        if (Physics.Raycast(camera.transform.position, camera.transform.TransformDirection(Vector3.up), out hit, Mathf.Max(5)))
        {
            Pickup();
            Debug.Log("");
        }
    }
}
