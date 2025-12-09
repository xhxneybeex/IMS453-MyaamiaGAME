using UnityEngine;

public class DebuggerHelper : MonoBehaviour
{

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InventoryManager[] IMs = FindObjectsByType<InventoryManager>(FindObjectsInactive.Include, FindObjectsSortMode.None); 
        foreach (InventoryManager i in IMs)
        {
            Debug.Log("inventory manager on object : " + i.gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
