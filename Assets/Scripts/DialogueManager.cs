using System;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] public InventoryManager inventoryManager;

    [SerializeField] public Giveitem itemGiving;
    [SerializeField] private string[] myLines;
    [SerializeField] private GameObject dialogueUI;
    [SerializeField] private GameObject notificationIcon;
    
    [SerializeField] private TMPro.TextMeshProUGUI dialogue;
    [SerializeField] private TMPro.TextMeshProUGUI ToDoText;

    public Sprite[] portraits;
    
    public TMPro.TextMeshProUGUI tasks;
    
    [SerializeField] GameObject Portrait;
    //[SerializeField] public GameObject Portrait2;

    public bool interactionEnabled = false;
    //private bool dialogueActive = false;
    public bool enterClicked = false;
    //private int currentFlag = 0;
    public String characterNotif = "Larry";

    public string currentLine = "Oh, hi. Isn’t it so hard getting up in the morning? I always need something to wake me up. I really need my kociihsaapowi minehkwaakani, but it takes so much energy to get up. Could you bring it to me? I think I left it on the atoohpooni?";

    public static string tasksInBook  = "";
    public string currentChar = "";
    [SerializeField] private TMPro.TextMeshProUGUI charName;

    public static bool talkedToMom = false;
    public static bool talkedToDad = false;
    public static bool talkedToLarry = false;
    public static bool talkedToDrew = false;
    public static bool talkedToTony = false;
    public static bool talkedToBetsy = false;
    public static bool talkedToRussel = false;
    public static bool talkedToAngeline = false;
    public static bool talkedToSam = false;
    public static bool talkedToMom2 = false;
    public static bool talkedToSpot = false;
    public static bool talkedToJudy = false;
    public static bool talkedToMarco = false;
    public static bool talkedToCaroline = false;
    public static bool talkedToTony2 = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogueUI.SetActive(false);
        Portrait.SetActive(false);
        if (tasksInBook == "")
        {
            tasksInBook = "No current or past tasks";
        }
        tasks.text = tasksInBook;
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
            tasks.text = tasksInBook;
            //Portrait2.SetActive(false);
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
        tasksInBook = tasksInBook.Replace("No current or past tasks", "");
        Portrait.GetComponent<Image>().sprite = ChangePortrait(character);
        charName.text = character;
        //interactionEnabled = false;

        if (character.Equals("Mom"))
        {
            characterNotif = "Mom";
            //Portrait.GetComponent<Image>().sprite = ChangePortrait(character);
            if (InventoryManager.GlovesCollected == false)
            {
                currentLine = "You can play outside for a little while, but be careful! No going out without your alencihkana.\n";
                if (talkedToMom == false)
                {
                    tasksInBook += "Mom needs me to find my alencihkana\n";
                    notificationIcon.SetActive(true);
                }
                dialogue.text = currentLine;
                interactionEnabled = false;
                talkedToMom = true;
            } else if (InventoryManager.GlovesCollected == true)
            {
                currentLine = "That should help keep you warm! I also noticed that Angeline’s old naahkiipioni was falling apart, so I thought we could surprise her with a nice new one. I have some work to take care of here, so could you drop off this new naahkiipioni for me?";
                tasksInBook = tasksInBook.Replace("Mom needs me to find my alencihkana\n", "");
                tasksInBook = tasksInBook.Replace("I think I saw the alencihkana on the counter\n", "");
                ResetToDoText();
                dialogue.text = currentLine;
                interactionEnabled = false;
            }
            
        }

        else if (character.Equals("Dad"))
        {
            characterNotif = "Dad";
            if (InventoryManager.CoatCollected == false)
            {
                //Portrait2.SetActive(true);
                //Portrait.SetActive(false);
                currentLine = "Make sure you’re bundled up in your keehpakiikinki naapinaakani before you go outside, kiddo! It’s a cold one!";
                if (talkedToDad == false)
                {
                    tasksInBook += "Dad needs me to find my keehpakiikinki naapinaakani.\n";
                    notificationIcon.SetActive(true);
                }
                dialogue.text = currentLine;
                dialogueUI.SetActive(true);
                interactionEnabled = false;
                talkedToDad = true;
            }
            else if (InventoryManager.CoatCollected == true)
            {
                //Portrait2.SetActive(true);
                //Portrait.SetActive(false);
                currentLine = "Now you’re ready to brave the cold!";
                tasksInBook = tasksInBook.Replace("Dad needs me to find my keehpakiikinki naapinaakani.\n", "");
                tasksInBook = tasksInBook.Replace("I think the plant is right by the keehpakiikinki naapinaakani\n", "");
                ResetToDoText();
                dialogue.text = currentLine;
                interactionEnabled = false;
            }
        }

        else if (character.Equals("Drew"))
        {
            characterNotif = "Drew";
            if (InventoryManager.HammerCollected == false)
            {
                currentLine = "Hey there! The bridge is out, and nobody can get to the East part of town! But there’s never been a repair job me and my trusty pakantaakani can’t complete! There’s just one problem… I seem to have misplaced my pakantaakani. But I bet you have one at your house, right? Think you could bring me a spare?";
                if (talkedToDrew == false)
                {
                    tasksInBook += "Drew needs me to find a pakantaakani\n";
                    notificationIcon.SetActive(true);
                }
                dialogue.text = currentLine;
                interactionEnabled = false;
                talkedToDrew = true;                
            }
            else if (InventoryManager.HammerCollected == true)
            {
                currentLine = "Yes! This pakantaakani is exactly what I need! Just give me some time, and this bridge will be better than ever!";
                tasksInBook = tasksInBook.Replace("Drew needs me to find a pakantaakani\n", "");
                ResetToDoText();
                dialogue.text = currentLine;
                interactionEnabled = false;
            }

        }

        else if (character.Equals("Larry"))
        {
            characterNotif = "Larry";
            if (InventoryManager.CoffeeCollected == false)
            {
                currentLine = "Yawn… oh, hello… when it’s cold like this, I just can’t get myself moving… not without some kociihsaapowi, that is… but I’m just too sleepy to get up and find it…";
                if (talkedToLarry == false)
                {
                    tasksInBook += "Larry needs me to find his kociihsaapowi\n";
                    notificationIcon.SetActive(true);
                }
                dialogue.text = currentLine;
                interactionEnabled = false;
                talkedToLarry = true;
            }
            else if (InventoryManager.CoffeeCollected == true)
            {
                currentLine = "Ah, that’s the stuff! Nothing like some kociihsaapowi to really wake me up. Now I feel ready to face the day! Looks like my plants could use a morning pick-me-up, too. I’d better take care of that!";
                tasksInBook = tasksInBook.Replace("Larry needs me to find his kociihsaapowi\n", "");
                tasksInBook = tasksInBook.Replace("I think I saw Larry's kociihsaapowi somewhere in his house\n", "");
                ResetToDoText();
                dialogue.text = currentLine;
                interactionEnabled = false;                
            }
        }

        else if (character.Equals("Tony"))
        {
            characterNotif = "Tony";
            if (InventoryManager.PepperCollected == true && InventoryManager.SaltCollected == true)
            {
                currentLine = "Ah, that’s just what I need! I am inspired! A dash of this, a sprinkle of that… this dish will be unparalleled! Allow my culinary genius to stew for a bit, and when Summer comes, we shall feast!";
                tasksInBook = tasksInBook.Replace("Tony needs me to find his wiihkapaakani and wiihsakaakani\n", "");
                tasksInBook = tasksInBook.Replace("I think the wiihkapaakani and wiihsakaakani were in Tony's kitchen.\n", "");
                ResetToDoText();
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
                dialogue.text = currentLine;
                interactionEnabled = false;
                talkedToTony = true;
            }
            
        }

        else if (character.Equals("Betsy"))
        {
            characterNotif = "Betsy";
            if (InventoryManager.KeysCollected == true)
            {
                //Portrait2.SetActive(true);
                //Portrait.SetActive(false);
                currentLine = "Finally, a kid who knows how to show their elders some respect! But you didn’t catch the thief, eh? And while you were gone, they struck again! My wilenaahkhtaakani is nowhere to be seen, and the floor looks positively barren without it. I’ll catch that thief yet, I tell you…";
                tasksInBook = tasksInBook.Replace("Betsy needs me to find her paahpahaakana\n", "");
                tasksInBook = tasksInBook.Replace("I think the paahpahaakana is in Drew's house\n", "");
                ResetToDoText();
                dialogue.text = currentLine;
                interactionEnabled = false;

            } else
            {
                //Portrait2.SetActive(true);
                //Portrait.SetActive(false);
                currentLine = "They all say I’m crazy, I know they do… you probably think I’m crazy. The crazy old lady lost her paahpahaakana again, hm? No! There’s a thief, I tell you! A thief has stolen my paahpahaakana, and now I can’t open my own door! Ooh, that nasty thief…";
                if (talkedToBetsy == false)
                {
                    tasksInBook += "Betsy needs me to find her paahpahaakana\n";
                    notificationIcon.SetActive(true);
                }
                dialogue.text = currentLine;
                interactionEnabled = false;
                talkedToBetsy = true;
            }
        }

        else if (character.Equals("Russel"))
        {
            characterNotif = "Russel";
            
            if (InventoryManager.RugCollected == true)
            {
                //Portrait2.SetActive(true);
                //Portrait.SetActive(false);
                currentLine = "Thanks for helping me return that wilenaahkhtaakani. I like to pull pranks on Old Lady Betsy, but I don’t want her to feel bad!";
                tasksInBook = tasksInBook.Replace("Russel wants me to return Betsy's wilenaahkhtaakani\n", "");
                tasksInBook = tasksInBook.Replace("I think I saw the wilenaahkhtaakani in Drew's house\n", "");
                ResetToDoText();
                dialogue.text = currentLine;
                interactionEnabled = false;

            } else
            {
                //Portrait2.SetActive(true);
                //Portrait.SetActive(false);
                currentLine = "I like to mess with the Old Lady Betsy. I swipe things when she’s not looking, and then put them back when she’s not looking! Heh heh! But, I do feel a little bad, because now everybody thinks she’s crazy… maybe you could help me return the last thing I stole. Here - could you get this wilenaahkhtaakani back to Old Lady Betsy?";
                if (talkedToRussel == false)
                {
                    tasksInBook += "Russel wants me to return Betsy's wilenaahkhtaakani\n";
                    notificationIcon.SetActive(true);
                }
                dialogue.text = currentLine;
                interactionEnabled = false;
                talkedToRussel = true;
            }
        }

        else if (character.Equals("Angeline"))
        {
            characterNotif = "Angeline";
            
            if (InventoryManager.BrushCollected == true)
            {
                currentLine = "Ah, I’m saved! Now that I look presentable, I can make sure everything is on track for the Summer gathering. Your continued help is much appreciated!";
                tasksInBook = tasksInBook.Replace("Angeline wants me to find her a piiwahaakani\n", "");
                tasksInBook = tasksInBook.Replace("I think I saw a piiwahaakani in Judy's house\n", "");
                ResetToDoText();
                dialogue.text = currentLine;
                interactionEnabled = false;

            } else
            {
                currentLine = "The Summer gathering will be here before we know it, and there’s so much to be done! The community needs someone to keep everything on track - but I can’t possibly go out with my hair in this state! I’ll be the laughingstock of the town! Child, have you seen a piiwahaakani anywhere that could solve my crisis?";
                if (talkedToAngeline == false)
                {
                    tasksInBook += "Angeline wants me to find her a piiwahaakani\n";
                    notificationIcon.SetActive(true);
                }
                dialogue.text = currentLine;
                interactionEnabled = false;
                talkedToAngeline = true;
            }
        }

        else if (character.Equals("Sam"))
        {
            characterNotif = "Sam";
            
            if (InventoryManager.BlanketCollected == true)
            {
                currentLine = "That’s Ryan’s waapimotayi alright! And he’s finally quieted down! Now we can both get some rest. Thank you!";
                tasksInBook = tasksInBook.Replace("Sam wants me to find her a waapimotayi\n", "");
                tasksInBook = tasksInBook.Replace("I think I saw a waapimotayi in Drew's house\n", "");
                ResetToDoText();
                dialogue.text = currentLine;
                interactionEnabled = false;

            } else
            {
                currentLine = "Little Ryan has been crying nonstop… I think he must be missing his favorite waapimotayi, but I’m not sure where it could be… if you see a cozy blue waapimotayi, would you bring it here?";
                if (talkedToSam == false)
                {
                    tasksInBook += "Sam wants me to find her a waapimotayi\n";
                    notificationIcon.SetActive(true);
                }
                dialogue.text = currentLine;
                interactionEnabled = false;
                talkedToSam = true;
            }
        }

        else if (character.Equals("Mom2"))
        {
            characterNotif = "Mom2";
            charName.text = "Mom";
            Portrait.GetComponent<Image>().sprite = ChangePortrait("Mom");
            if (InventoryManager.ChairCollected == true)
            {
                currentLine = "Thanks for making the delivery!";
                tasksInBook = tasksInBook.Replace("Mom wants me to find a naahkiipioni\n", "");
                tasksInBook = tasksInBook.Replace("There's a naahkiipioni in my house.\n", "");
                ResetToDoText();
                dialogue.text = currentLine;
                interactionEnabled = false;

            } else
            {
                currentLine = "I noticed that Angeline’s old naahkiipioni was falling apart, so I thought we could surprise her with a nice new one. I have some work to take care of here, so could you drop off this new naahkiipioni for me?";
                if (talkedToMom2 == false)
                {
                    tasksInBook += "Mom wants me to find a naahkiipioni\n";
                    notificationIcon.SetActive(true);
                }
                dialogue.text = currentLine;
                interactionEnabled = false;
                talkedToMom2 = true;
            }
        }

        else if (character.Equals("Spot"))
        {
            characterNotif = "Spot";
            
            if (InventoryManager.ShoeCollected == true && InventoryManager.BallCollected == true)
            {
                currentLine = "Hey, thanks for the tasty shoe, bucko. Yeah, I can talk. But keep this between us, okie dokie?";
                dialogue.text = currentLine;
                interactionEnabled = false;

            } else if (InventoryManager.ShoeCollected == true)
            {
                currentLine = "Woof! (He looks grateful, and digs up a pakwaahkoni for you!";
                InventoryManager.BallCollected = true;
                tasksInBook = tasksInBook.Replace("Spot wants me to find a mahkisini\n", "");
                tasksInBook = tasksInBook.Replace("I think I saw a mahkisini in Tony's house\n", "");
                ResetToDoText();
                dialogue.text = currentLine;
                interactionEnabled = false;

            } else
            {
                currentLine = "Woof! (He looks hungry for a mahkisini to chew on…)";
                if (talkedToSpot == false)
                {
                    tasksInBook += "Spot wants me to find a mahkisini\n";
                    notificationIcon.SetActive(true);
                }
                dialogue.text = currentLine;
                interactionEnabled = false;
                talkedToSpot = true;
            }
        }

        else if (character.Equals("Judy"))
        {
            characterNotif = "Judy";
            
            if (InventoryManager.SoapCollected == true && InventoryManager.TowelCollected == true)
            {
                currentLine = "Hey, that’s just what I needed! You’re the best! Time to get squeaky clean!";
                tasksInBook = tasksInBook.Replace("Judy wants me to find a waapahaakani and a kišiinkweehaakani\n", "");
                tasksInBook = tasksInBook.Replace("I think I saw a waapahaakani and a kišiinkweehaakani in Judy's house\n", "");
                ResetToDoText();
                dialogue.text = currentLine;
                interactionEnabled = false;

            } else
            {
                currentLine = "My parents say I can’t do any of the fun stuff at the gathering while I’m all messy. I like being messy, but I also really like the gathering, so I guess I should get cleaned up! But I’m too messy to go in the house to get clean! I can use a hose for water, but to really get clean, I need some waapahaakani, and a kišiinkweehaakani to dry off!";
                if (talkedToJudy == false)
                {
                    tasksInBook += "Judy wants me to find a waapahaakani and a kišiinkweehaakani\n";
                    notificationIcon.SetActive(true);
                }
                dialogue.text = currentLine;
                interactionEnabled = false;
                talkedToJudy = true;
            }
        }

        else if (character.Equals("Marco"))
        {
            characterNotif = "Marco";
            if (InventoryManager.StickCollected == true)
            {
                currentLine = "Thanks";
                tasksInBook = tasksInBook.Replace("Marco wants me to find a pakitahaakani\n", "");
                tasksInBook = tasksInBook.Replace("I think I saw a pakitahaakani in Judy's house\n", "");
                ResetToDoText();
                dialogue.text = currentLine;
                interactionEnabled = false;

            } else
            {
                currentLine = "We’re almost ready for the big lacrosse game! Only problem is, I think I left my pakitahaakani at home. I’m making sure the field is ready - could you maybe bring me my pakitahaakani?";
                if (talkedToMarco == false)
                {
                    tasksInBook += "Marco wants me to find a pakitahaakani\n";
                    notificationIcon.SetActive(true);
                }
                dialogue.text = currentLine;
                interactionEnabled = false;
                talkedToMarco = true;
            }
        }

        else if (character.Equals("Caroline"))
        {
            characterNotif = "Caroline";
            if (InventoryManager.CornCollected == true)
            {
                currentLine = "Perfect, thank you!";
                tasksInBook = tasksInBook.Replace("Caroline wants me to find some miincipi\n", "");
                tasksInBook = tasksInBook.Replace("I think I saw some miincipi in Tony's house\n", "");
                ResetToDoText();
                dialogue.text = currentLine;
                interactionEnabled = false;

            } else
            {
                currentLine = "I can’t wait to try Tony’s meal for this year! But every good meal needs a good side - and you can’t go wrong with miincipi. I promised I’d send some to the feast site, but I’ve just been so busy here, I can’t find the time to go myself. Could you bring it over there?";
                if (talkedToCaroline == false)
                {
                    tasksInBook += "Caroline wants me to find some miincipi\n";
                    notificationIcon.SetActive(true);
                }
                dialogue.text = currentLine;
                interactionEnabled = false;
                talkedToCaroline = true;
            }
        }
        else if (character.Equals("Tony2"))
        {
            characterNotif = "Tony2";
            charName.text = "Tony";
            Portrait.GetComponent<Image>().sprite = ChangePortrait("Tony");
            if (InventoryManager.ForksCollected == true && InventoryManager.PlatesCollected == true && InventoryManager.SpoonsCollected == true)
            {
                currentLine = "Now everyone will be able to enjoy my masterpiece without making a mess! Thank you!";
                tasksInBook = tasksInBook.Replace("Tony wants me to find some šinkilaakana, neewikoleekia, and kookaana\n", "");
                tasksInBook = tasksInBook.Replace("kookaana, šinkilaakana, and Neewikoleekia were in Tony's house\n", "");
                ResetToDoText();
                dialogue.text = currentLine;
                interactionEnabled = false;

            } else
            {
                currentLine = "It’s finally time for everyone to try my latest masterpiece, my culinary concerto! But this remarkable meal is no mere finger food, no! The table must be set! Think you can put some šinkilaakana, neewikoleekia, and kookaana at each seat?";
                if (talkedToTony2 == false)
                {
                    tasksInBook += "Tony wants me to find some šinkilaakana, neewikoleekia, and kookaana\n";
                    notificationIcon.SetActive(true);
                }
                dialogue.text = currentLine;
                interactionEnabled = false;
                talkedToTony2 = true;
            }
        }
        ShowTextNotification(characterNotif);
    }

    public void ResetToDoText()
    {
        ToDoText.text = "To Do: ";
    }

    public Sprite ChangePortrait(string character)
    {
        switch (character) 
        {
            case "Mom":
                return portraits[8];
            case "Dad":
                return portraits[3];
            case "Drew":
                return portraits[4];
            case "Larry":
                return portraits[6];
            case "Tony":
                return portraits[12];
            case "Betsy":
                return portraits[1];
            case "Russel":
                return portraits[9];
            case "Angeline":
                return portraits[0];
            case "Caroline":
                return portraits[2];
            case "Judy":
                return portraits[5];
            case "Marco":
                return portraits[7];
            case "Sam":
                return portraits[10];
            case "Spot":
                return portraits[11];
            default:
                return portraits[0];
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
        } else if (character.Equals("Betsy"))
        {
            ToDoText.text = "To Do: Find Betsy's paahpahaakana";
        } else if (character.Equals("Russel"))
        {
            ToDoText.text = "To Do: Find Betsy's stolen wilenaahkhtaakani for Russel";
        } else if (character.Equals("Angeline"))
        {
            ToDoText.text = "To Do: Find a piiwahaakani for Angeline";
        } else if (character.Equals("Sam"))
        {
            ToDoText.text = "To Do: Find a waapimotayi for Sam";
        } else if (character.Equals("Mom2"))
        {
            ToDoText.text = "To Do: Find a naahkiipioni for Mom";
        } else if (character.Equals("Spot"))
        {
            ToDoText.text = "To Do: Find a mahkisini for Spot";
        } else if (character.Equals("Judy"))
        {
            ToDoText.text = "To Do: Find a waapahaakani and a kišiinkweehaakani for Judy";
        } else if (character.Equals("Marco"))
        {
            ToDoText.text = "To Do: Find a pakitahaakani Marco";
        } else if (character.Equals("Caroline"))
        {
            ToDoText.text = "To Do: Find some miincipi for Caroline";
        } else if (character.Equals("Tony2"))
        {
            ToDoText.text = "To Do: Find some šinkilaakana, neewikoleekia, and kookaana";
        }
    }

}
