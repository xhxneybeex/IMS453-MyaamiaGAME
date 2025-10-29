using UnityEngine;

public class Giveitem : MonoBehaviour
{

    [SerializeField] public InventoryManager InventoryManager;
    [SerializeField] public DialogueManager DialogueManager;
    public int timesWalkedUpTo = 0;
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
        timesWalkedUpTo += 1;
        Debug.Log("times walked up to equals " + timesWalkedUpTo);
        if (timesWalkedUpTo > 1) {
            InventoryManager.MugText.text = "kociihsaapowi minehkwaakani";
        } else {
            DialogueManager.StartDialogue("Larry");
        }
    }
}
