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
            GameObject.Find("BridgeBarrier").SetActive(false);
            gameObject.SetActive(true);
        } else
        {
            GameObject.Find("BridgeBarrier").SetActive(true);
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
