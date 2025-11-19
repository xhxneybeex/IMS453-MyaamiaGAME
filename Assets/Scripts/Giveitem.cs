using UnityEngine;

public class Giveitem : MonoBehaviour
{

    [SerializeField] public InventoryManager InventoryManager;
    [SerializeField] public DialogueManager DialogueManager;
    public int timesWalkedUpTo = 0;

    public string currentChar = "";
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
        DialogueManager.interactionEnabled = true;
        if (this.gameObject.name.ToString() == "Mom")
        {
            timesWalkedUpTo += 1;
            Debug.Log("times walked up to equals " + timesWalkedUpTo);
            if (InventoryManager.MugSprite.gameObject.activeInHierarchy)
            {
                InventoryManager.GlovesText.text = "alencihkana";
            }
            else
            {
                Debug.Log("you can interact with Mom now");
                currentChar = "Mom";
            }
        }
        else if (this.gameObject.name.ToString() == "Dad")
        {
            timesWalkedUpTo += 1;
            Debug.Log("times walked up to equals " + timesWalkedUpTo);
            if (InventoryManager.MugSprite.gameObject.activeInHierarchy)
            {
                InventoryManager.CoatText.text = "keehpakiikinki naapinaakani";
            }
            else
            {
                Debug.Log("you can interact with Dad now");
                DialogueManager.StartDialogue("Dad");
                currentChar = "Dad";
            }
        }
    }
}
