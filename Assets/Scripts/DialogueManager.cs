using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] public InventoryManager inventoryManager;

    [SerializeField] public Giveitem itemGiving;
    [SerializeField] private string[] myLines;
    [SerializeField] private GameObject dialogueUI;
    [SerializeField] private TMPro.TextMeshProUGUI dialogue;
    [SerializeField] GameObject Mom;
    [SerializeField] public GameObject Dad;

    public bool interactionEnabled = false;
    private bool dialogueActive = false;
    public bool enterClicked = false;
    private int currentFlag = 0;

    public string currentLine = "Oh, hi. Isn’t it so hard getting up in the morning? I always need something to wake me up. I really need my kociihsaapowi minehkwaakani, but it takes so much energy to get up. Could you bring it to me? I think I left it on the atoohpooni?";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogueUI.SetActive(false);
        Dad.SetActive(false);
        Mom.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactionEnabled == true)
        {
            Debug.Log("e was clicked");
            enterClicked = true;
            //if ()
            StartDialogue(itemGiving.currentChar.ToString());
            Debug.Log(itemGiving.currentChar.ToString());
        }
        else if (dialogueUI.activeInHierarchy == true && Input.GetKeyDown(KeyCode.E))
        {
            dialogueUI.SetActive(false);
        }
        // If dialogue is active...
        /*  if (dialogueActive)
          {
              // If the player presses E...
              if (Input.GetKeyDown(KeyCode.E))
              {
                  // Close dialogue
                  ToggleDialogue(false);
              }
          } else
          {
              // If interaction is enabled...
              if (interactionEnabled)
              {
                  // If the player presses E...
                  if (Input.GetKeyDown(KeyCode.E))
                  {
                      // Open dialogue
                      ToggleDialogue(true);
                  }
              }
          } */
    }

    /*  private void OnTriggerEnter(Collider collision)
      {
          // If the player entered the zone...
          if (collision.CompareTag("Player"))
          {
              // Enable conversation
              interactionEnabled = true;
          }  
      } */

    /* private void OnTriggerExit(Collider collision)
     {
         // If the player exits the zone...
         if (collision.CompareTag("Player"))
         {
             // Disable conversation
             interactionEnabled = false;
         }
     } */

    /*  private void ToggleDialogue(bool active)
      {
          dialogueActive = active;
          // Disable movement
          GameObject.Find("Player").GetComponent<PlayerController>().movementEnabled = !active;
          // Update dialogue text
          dialogue.text = myLines[currentFlag];
          // Enable UI
          dialogueUI.SetActive(active);
      } */

    public void StartDialogue(string character)
    {
        Debug.Log("it just checked for e press for " + character);
        if (character.Equals("Larry") && inventoryManager.MugCollected == false) //&& enterClicked == true
        {
            // person = 
            dialogue.text = currentLine;
            dialogueUI.SetActive(true);
            interactionEnabled = false;
        }
        else if (character.Equals("Larry") && inventoryManager.MugCollected == true)
        {
            currentLine = "Thanks so much! Now I can get moving.";
            dialogue.text = currentLine;
            dialogueUI.SetActive(true);
            interactionEnabled = false;
        }
        else if (character.Equals("Mom") && inventoryManager.GlovesCollected == false) //&& enterClicked == true
        {
            Dad.SetActive(false);
            Mom.SetActive(true);
            currentLine = "You can play outside for a little while, but be careful! No going out without your alencihkana.";
            dialogue.text = currentLine;
            dialogueUI.SetActive(true);
            interactionEnabled = false;
        }
        else if (character.Equals("Mom") && inventoryManager.GlovesCollected == true)
        {
            Dad.SetActive(false);
            Mom.SetActive(true);
            currentLine = "That should help keep you warm!";
            dialogue.text = currentLine;
            dialogueUI.SetActive(true);
            interactionEnabled = false;
        }
        else if (character.Equals("Dad") && inventoryManager.GlovesCollected == false) //&& enterClicked == true
        {
            Dad.SetActive(true);
            Mom.SetActive(false);
            currentLine = "Make sure you’re bundled up in your keehpakiikinki naapinaakani before you go outside, kiddo! It’s a cold one!";
            dialogue.text = currentLine;
            dialogueUI.SetActive(true);
            interactionEnabled = false;
        }
        else if (character.Equals("Dad") && inventoryManager.GlovesCollected == true)
        {
            Dad.SetActive(true);
            Mom.SetActive(false);
            currentLine = "Now you’re ready to brave the cold!";
            dialogue.text = currentLine;
            dialogueUI.SetActive(true);
            interactionEnabled = false;
        }
    }

}
