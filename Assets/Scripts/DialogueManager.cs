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
        /*if (character.Equals("Larry") && InventoryManager.CoffeeCollected == false) //&& enterClicked == true
        {
            // person = 
            dialogue.text = currentLine;
            dialogueUI.SetActive(true);
            interactionEnabled = false;
            notificationIcon.SetActive(true);
        }
        else if (character.Equals("Larry") && InventoryManager.CoffeeCollected == true)
        {
            currentLine = "Thanks so much! Now I can get moving.";
            dialogue.text = currentLine;
            dialogueUI.SetActive(true);
            interactionEnabled = false;
        }*/
        if (character.Equals("Mom") && InventoryManager.GlovesCollected == false) //&& enterClicked == true
        {
            dialogueUI.SetActive(true);
            Dad.SetActive(false);
            Portrait.SetActive(true);
            currentLine = "You can play outside for a little while, but be careful! No going out without your alencihkana.\n";
            if (talkedToMom == false)
            {
                tasksInBook += "Mom needs me to find my alencihkana\n";
                notificationIcon.SetActive(true);
            }
            characterNotif = "Mom";
            //tasks.text = tasksInBook;
            dialogue.text = currentLine;
            dialogueUI.SetActive(true);
            interactionEnabled = false;
            talkedToMom = true;
        }
        else if (character.Equals("Mom") && InventoryManager.GlovesCollected == true)
        {
            Dad.SetActive(false);
            Portrait.SetActive(true);
            currentLine = "That should help keep you warm! I also noticed that Angeline’s old naahkiipioni was falling apart, so I thought we could surprise her with a nice new one. I have some work to take care of here, so could you drop off this new naahkiipioni for me?";
            tasksInBook = tasksInBook.Replace("Mom needs me to find my alencihkana\n", "");
            tasksInBook = tasksInBook.Replace("I think I saw the alencihkana on the counter\n", "");
            dialogue.text = currentLine;
            dialogueUI.SetActive(true);
            interactionEnabled = false;
        }
        else if (character.Equals("Dad") && InventoryManager.CoatCollected == false) //&& enterClicked == true
        {
            dialogueUI.SetActive(true);
            Dad.SetActive(true);
            Portrait.SetActive(false);
            currentLine = "Make sure you’re bundled up in your keehpakiikinki naapinaakani before you go outside, kiddo! It’s a cold one!";
            if (talkedToDad == false)
            {
                tasksInBook += "Dad needs me to find my keehpakiikinki naapinaakani.\n";
                notificationIcon.SetActive(true);
            }
            characterNotif = "Dad";
            //tasks.text = tasksInBook;
            dialogue.text = currentLine;
            dialogueUI.SetActive(true);
            interactionEnabled = false;
            talkedToDad = true;
        }
        else if (character.Equals("Dad") && InventoryManager.CoatCollected == true)
        {
            Dad.SetActive(true);
            Portrait.SetActive(false);
            currentLine = "Now you’re ready to brave the cold!";
            tasksInBook = tasksInBook.Replace("Dad needs me to find my keehpakiikinki naapinaakani.\n", "");
            tasksInBook = tasksInBook.Replace("I think the plant is right by the keehpakiikinki naapinaakani\n", "");
            dialogue.text = currentLine;
            dialogueUI.SetActive(true);
            interactionEnabled = false;
        }

        else if (character.Equals("Drew") && InventoryManager.HammerCollected == false) //&& enterClicked == true
        {
            dialogueUI.SetActive(true);
            Dad.SetActive(false);
            Portrait.SetActive(true);
            currentLine = "Hey there! The bridge is out, and nobody can get to the East part of town! But there’s never been a repair job me and my trusty pakantaakani can’t complete! There’s just one problem… I seem to have misplaced my pakantaakani. But I bet you have one at your house, right? Think you could bring me a spare?";
            if (talkedToDrew == false)
            {
                tasksInBook += "Drew needs me to find a pakantaakani\n";
                notificationIcon.SetActive(true);
            }
            characterNotif = "Drew";
            //tasks.text = tasksInBook;
            dialogue.text = currentLine;
            dialogueUI.SetActive(true);
            interactionEnabled = false;
            talkedToDrew = true;
        }
        else if (character.Equals("Drew") && InventoryManager.HammerCollected == true)
        {
            Dad.SetActive(false);
            Portrait.SetActive(true);
            currentLine = "Yes! This pakantaakani is exactly what I need! Just give me some time, and this bridge will be better than ever!";
            tasksInBook = tasksInBook.Replace("Drew needs me to find a pakantaakani\n", "");
            //tasksInBook = tasksInBook.Replace("I think I saw the alencihkana on the counter\n", "");
            dialogue.text = currentLine;
            dialogueUI.SetActive(true);
            interactionEnabled = false;
        } 
        else if (character.Equals("Larry") && InventoryManager.CoffeeCollected == false) //&& enterClicked == true
        {
            dialogueUI.SetActive(true);
            Dad.SetActive(false);
            Portrait.SetActive(true);
            currentLine = "Yawn… oh, hello… when it’s cold like this, I just can’t get myself moving… not without some kociihsaapowi, that is… but I’m just too sleepy to get up and find it…";
            if (talkedToLarry == false)
            {
                tasksInBook += "Larry needs me to find his kociihsaapowi\n";
                notificationIcon.SetActive(true);
            }
            characterNotif = "Larry";
            //tasks.text = tasksInBook;
            dialogue.text = currentLine;
            dialogueUI.SetActive(true);
            interactionEnabled = false;
            talkedToLarry = true;
        }
        else if (character.Equals("Larry") && InventoryManager.CoffeeCollected == true)
        {
            Dad.SetActive(false);
            Portrait.SetActive(true);
            currentLine = "Ah, that’s the stuff! Nothing like some kociihsaapowi to really wake me up. Now I feel ready to face the day! Looks like my plants could use a morning pick-me-up, too. I’d better take care of that!";
            tasksInBook = tasksInBook.Replace("Larry needs me to find his kociihsaapowi\n", "");
            //tasksInBook = tasksInBook.Replace("I think I saw the alencihkana on the counter\n", "");
            dialogue.text = currentLine;
            dialogueUI.SetActive(true);
            interactionEnabled = false;
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
        }
    }

}
