using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Send to the ending
            if (InventoryManager.CoffeeCollected && InventoryManager.GlovesCollected && InventoryManager.CoatCollected && InventoryManager.ChairCollected
                && InventoryManager.HammerCollected && InventoryManager.KeysCollected && InventoryManager.RugCollected && InventoryManager.BlanketCollected
                && InventoryManager.SaltCollected && InventoryManager.PepperCollected && InventoryManager.ShoeCollected && InventoryManager.BallCollected
                && InventoryManager.CornCollected && InventoryManager.PlatesCollected && InventoryManager.ForksCollected && InventoryManager.SpoonsCollected
                && InventoryManager.BrushCollected && InventoryManager.StickCollected && InventoryManager.SoapCollected && InventoryManager.TowelCollected)
            {
                // Trigger the ending
                SceneManager.LoadScene("Ending");
            }
    
        }
    }
}
