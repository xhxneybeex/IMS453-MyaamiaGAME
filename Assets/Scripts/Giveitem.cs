using UnityEngine;

public class Giveitem : MonoBehaviour
{

    [SerializeField] public InventoryManager InventoryManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        //InventoryManager = GetComponent<InventoryManager>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("");
        InventoryManager.MugText.text = "kociihsaapowi minehkwaakani";
    }
}
