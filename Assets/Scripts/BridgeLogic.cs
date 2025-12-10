using UnityEngine;

public class BridgeLogic : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Awake()
    {
        if (InventoryManager.GlovesCollected && InventoryManager.CoatCollected && InventoryManager.RugCollected && InventoryManager.HammerCollected
            && InventoryManager.SaltCollected && InventoryManager.PepperCollected && InventoryManager.CoffeeCollected && InventoryManager.KeysCollected
            && InventoryManager.BlanketCollected && InventoryManager.ChairCollected && InventoryManager.ShoeCollected)
        {
            gameObject.SetActive(true);
        } else
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
