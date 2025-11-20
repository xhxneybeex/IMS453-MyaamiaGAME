using UnityEngine;

public class Giveitem : MonoBehaviour
{

    [SerializeField] public InventoryManager InventoryManager;
    [SerializeField] public DialogueManager DialogueManager;
    public int timesWalkedUpToMom = 0;
    public int timesWalkedUpToDad = 0;

    public static string currentChar = "";
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        //InventoryManager = GetComponent<InventoryManager>();
    }
    void Start()
    {
        currentChar = "Rose";
        Debug.Log(currentChar);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        DialogueManager.interactionEnabled = true;
        if (this.gameObject.name.ToString() == "MomSomewhere")
        {
            Debug.Log(this.gameObject.name.ToString());
            timesWalkedUpToMom += 1;
            Debug.Log("times walked up to equals " + timesWalkedUpToMom);
            if (InventoryManager.GlovesSprite.gameObject.activeInHierarchy)
            {
                InventoryManager.GlovesText.text = "alencihkana";
            }
            else
            {
                Debug.Log("you can interact with Mom now");
                currentChar = "Mom";
            }
        }
        else if (this.gameObject.name.ToString() == "DadSomewhere")
        {
            Debug.Log(this.gameObject.name.ToString());
            timesWalkedUpToDad += 1;
            Debug.Log("times walked up to equals " + timesWalkedUpToDad);
            if (InventoryManager.CoatSprite.gameObject.activeInHierarchy)
            {
                InventoryManager.CoatText.text = "keehpakiikinki naapinaakani";
            }
            else
            {
                Debug.Log("you can interact with Dad now");
                //DialogueManager.StartDialogue("Dad");
                currentChar = "Dad";
            }
        }
    }
}
