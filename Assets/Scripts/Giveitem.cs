using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Giveitem : MonoBehaviour
{

    [SerializeField] public InventoryManager InventoryManager;
    [SerializeField] public DialogueManager DialogueManager;
    public int timesWalkedUpToMom = 0;
    public int timesWalkedUpToDad = 0;
    public int timesWalkedUpToDrew = 0;
    private int timesWalkedUpToLarry = 0;

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
            if (InventoryManager.itemJournal.transform.GetChild(0).gameObject.activeInHierarchy)
            {
                InventoryManager.itemJournal.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "alencihkana";
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
            if (InventoryManager.itemJournal.transform.GetChild(0).gameObject.activeInHierarchy)
            {
                InventoryManager.itemJournal.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "keehpakiikinki naapinaakani";
            }
            else
            {
                Debug.Log("you can interact with Dad now");
                //DialogueManager.StartDialogue("Dad");
                currentChar = "Dad";
            }
        }
        else if (this.gameObject.name.ToString() == "Drew")
        {
            Debug.Log(this.gameObject.name.ToString());
            timesWalkedUpToDrew += 1;
            Debug.Log("times walked up to equals " + timesWalkedUpToDrew);
            if (InventoryManager.itemJournal.transform.GetChild(0).gameObject.activeInHierarchy)
            {
                InventoryManager.itemJournal.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "keehpakiikinki naapinaakani";
            }
            else
            {
                Debug.Log("you can interact with Drew now");
                currentChar = "Drew";
            }
        }
        else if (this.gameObject.name.ToString() == "Larry")
        {
            Debug.Log(this.gameObject.name.ToString());
            timesWalkedUpToDrew += 1;
            Debug.Log("times walked up to equals " + timesWalkedUpToLarry);
            if (InventoryManager.itemJournal.transform.GetChild(0).gameObject.activeInHierarchy)
            {
                InventoryManager.itemJournal.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "kociihsaapowi";
            }
            else
            {
                Debug.Log("you can interact with Larry now");
                currentChar = "Larry";
            }
        }
    }
    private void OnTriggerExit()
    {
        DialogueManager.interactionEnabled = false;
        Debug.Log("You can no longer start dialogue");
    }
}
