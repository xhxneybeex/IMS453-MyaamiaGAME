using System;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] public InventoryManager inventoryManager;

    [SerializeField] public Giveitem itemGiving;
    [SerializeField] private string[] myLines;
    [SerializeField] private GameObject dialogueUI;
    [SerializeField] private GameObject notificationIcon;
    
    [SerializeField] private TMPro.TextMeshProUGUI dialogue;
    [SerializeField] private TMPro.TextMeshProUGUI ToDoText;
    
    public TMPro.TextMeshProUGUI tasks;
    
    [SerializeField] GameObject Portrait;
    [SerializeField] public GameObject Dad;

    public bool interactionEnabled = false;
    //private bool dialogueActive = false;
    public bool enterClicked = false;
    //private int currentFlag = 0;
    public String characterNotif = "Larry";

    public string currentLine = "Oh, hi. Isn’t it so hard getting up in the morning? I always need something to wake me up. I really need my kociihsaapowi minehkwaakani, but it takes so much energy to get up. Could you bring it to me? I think I left it on the atoohpooni?";

    public string tasksInBook  = "";
    public string currentChar = "";

    public bool talkedToMom = false;
    public bool talkedToDad = false;
    public bool talkedToLarry = false;
    public bool talkedToDrew = false;
    public bool talkedToTony = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogueUI.SetActive(false);
        Dad.SetActive(false);
        Portrait.SetActive(false);
        tasksInBook = "";
        Debug.Log(tasksInBook);
    }

    // Update is called once per frame
    void Update()
    {
        currentChar = Giveitem.currentChar;
        if (Input.GetKeyDown(KeyCode.E) && interactionEnabled == true)
        {
            Debug.Log("e was clicked");
            enterClicked = true;
            //if ()
            StartDialogue(currentChar);
            Debug.Log("the current character is " + currentChar);
        }
        else if (dialogueUI.activeInHierarchy == true && Input.GetKeyDown(KeyCode.E))
        {
            dialogueUI.SetActive(false);
            ShowTextNotification(characterNotif);
            tasks.text = tasksInBook;
            Dad.SetActive(false);
            Portrait.SetActive(false);
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
        Portrait.SetActive(true);
        dialogueUI.SetActive(true);
        
        if (character.Equals("Mom") && InventoryManager.GlovesCollected == false)
        {
            if (InventoryManager.GlovesCollected == false)
            {
                currentLine = "You can play outside for a little while, but be careful! No going out without your alencihkana.\n";
                if (talkedToMom == false)
                {
                    tasksInBook += "Mom needs me to find my alencihkana\n";
                    notificationIcon.SetActive(true);
                }
                characterNotif = "Mom";
                dialogue.text = currentLine;
                dialogueUI.SetActive(true);
                interactionEnabled = false;
                talkedToMom = true;
            } else if (InventoryManager.GlovesCollected == true)
            {
                currentLine = "That should help keep you warm! I also noticed that Angeline’s old naahkiipioni was falling apart, so I thought we could surprise her with a nice new one. I have some work to take care of here, so could you drop off this new naahkiipioni for me?";
                tasksInBook = tasksInBook.Replace("Mom needs me to find my alencihkana\n", "");
                tasksInBook = tasksInBook.Replace("I think I saw the alencihkana on the counter\n", "");
                dialogue.text = currentLine;
                interactionEnabled = false;
            }
            
        }

        else if (character.Equals("Dad") && InventoryManager.CoatCollected == false)
        {
            if (InventoryManager.CoatCollected == false)
            {
                Dad.SetActive(true);
                Portrait.SetActive(false);
                currentLine = "Make sure you’re bundled up in your keehpakiikinki naapinaakani before you go outside, kiddo! It’s a cold one!";
                if (talkedToDad == false)
                {
                    tasksInBook += "Dad needs me to find my keehpakiikinki naapinaakani.\n";
                    notificationIcon.SetActive(true);
                }
                characterNotif = "Dad";
                dialogue.text = currentLine;
                dialogueUI.SetActive(true);
                interactionEnabled = false;
                talkedToDad = true;
            }
            else if (InventoryManager.CoatCollected == true)
            {
                Dad.SetActive(true);
                Portrait.SetActive(false);
                currentLine = "Now you’re ready to brave the cold!";
                tasksInBook = tasksInBook.Replace("Dad needs me to find my keehpakiikinki naapinaakani.\n", "");
                tasksInBook = tasksInBook.Replace("I think the plant is right by the keehpakiikinki naapinaakani\n", "");
                dialogue.text = currentLine;
                interactionEnabled = false;
            }
            
        }

        else if (character.Equals("Drew"))
        {
            if (InventoryManager.HammerCollected == false)
            {
                currentLine = "Hey there! The bridge is out, and nobody can get to the East part of town! But there’s never been a repair job me and my trusty pakantaakani can’t complete! There’s just one problem… I seem to have misplaced my pakantaakani. But I bet you have one at your house, right? Think you could bring me a spare?";
                if (talkedToDrew == false)
                {
                    tasksInBook += "Drew needs me to find a pakantaakani\n";
                    notificationIcon.SetActive(true);
                }
                characterNotif = "Drew";
                dialogue.text = currentLine;
                interactionEnabled = false;
                talkedToDrew = true;                
            }
            else if (InventoryManager.HammerCollected == true)
            {
                currentLine = "Yes! This pakantaakani is exactly what I need! Just give me some time, and this bridge will be better than ever!";
                tasksInBook = tasksInBook.Replace("Drew needs me to find a pakantaakani\n", "");
                dialogue.text = currentLine;
                interactionEnabled = false;
            }

        }

        else if (character.Equals("Larry"))
        {
            if (InventoryManager.CoffeeCollected == false)
            {
                currentLine = "Yawn… oh, hello… when it’s cold like this, I just can’t get myself moving… not without some kociihsaapowi, that is… but I’m just too sleepy to get up and find it…";
                if (talkedToLarry == false)
                {
                    tasksInBook += "Larry needs me to find his kociihsaapowi\n";
                    notificationIcon.SetActive(true);
                }
                characterNotif = "Larry";
                dialogue.text = currentLine;
                interactionEnabled = false;
                talkedToLarry = true;
            }
            else if (InventoryManager.CoffeeCollected == true)
            {
                currentLine = "Ah, that’s the stuff! Nothing like some kociihsaapowi to really wake me up. Now I feel ready to face the day! Looks like my plants could use a morning pick-me-up, too. I’d better take care of that!";
                tasksInBook = tasksInBook.Replace("Larry needs me to find his kociihsaapowi\n", "");
                dialogue.text = currentLine;
                interactionEnabled = false;                
            }
        }

        else if (character.Equals("Tony"))
        {
            if (InventoryManager.PepperCollected == true && InventoryManager.SaltCollected == true)
            {
                currentLine = "Ah, that’s just what I need! I am inspired! A dash of this, a sprinkle of that… this dish will be unparalleled! Allow my culinary genius to stew for a bit, and when Summer comes, we shall feast!";
                tasksInBook = tasksInBook.Replace("Tony needs me to find his wiihkapaakani and wiihsakaakani\n", "");
                dialogue.text = currentLine;
                interactionEnabled = false;
            } else
            {
                currentLine = "Oh, hello, kid! Maybe you can help me! I’m trying to figure out the perfect recipe for a dish for this year’s Summer gathering. It’s never too early to start preparing, and perfection takes time! But I’m at a bit of a loss… the flavors aren’t coming together without a little wiihkapaakani and wiihsakaakani! I just can’t find my shakers anywhere!";
                if (talkedToTony == false)
                {
                    tasksInBook += "Tony needs me to find his wiihkapaakani and wiihsakaakani\n";
                    notificationIcon.SetActive(true);
                }
                characterNotif = "Tony";
                dialogue.text = currentLine;
                interactionEnabled = false;
                talkedToTony = true;
            }
            
        }
    }

    public void ShowTextNotification(String character)
    {
        if (character.Equals("Dad"))
        {
            ToDoText.text = "To Do: Find your keehpakiikinki naapinaakani";
        } else if (character.Equals("Mom"))
        {
            ToDoText.text = "To Do: Find your alencihkana";
        } else if (character.Equals("Drew"))
        {
            ToDoText.text = "To Do: Find a Pakantaakani for Drew";
        } else if (character.Equals("Tony"))
        {
            ToDoText.text = "To Do: Find some wiihkapaakani and wiihsakaakani for Tony";
        } else if (character.Equals("Larry"))
        {
            ToDoText.text = "To Do: Find Larry's kociihsaapowi";
        }
    }

}
