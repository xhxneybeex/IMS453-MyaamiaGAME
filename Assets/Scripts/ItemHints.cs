using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemHints : MonoBehaviour
{
    public DialogueManager dm;
    public GameObject ih;
    //public bool glovesHintAdded = false;
    //public bool coatHintAdded = false;

    public Item item;


    public void Start()
    {
        Debug.Log("the name of the item controller is " + this.name);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("you entered a task update trigger");
        if (item.id == 2) // rug
        {
            Debug.Log("you entered the trigger for gloves");
            if (DialogueManager.talkedToRussel == true && InventoryManager.RugCollected == false)
            {
                this.gameObject.SetActive(false);
                DialogueManager.tasksInBook = DialogueManager.tasksInBook.Replace("Russel wants me to return Betsy's wilenaahkhtaakani\n", "I think I saw the wilenaahkhtaakani in Drew's house\n");
                Debug.Log("it should be updating tasksinbook now");
            }
        }
        else if (item.id == 5) // BlueMug
        {
            if (DialogueManager.talkedToLarry == true && InventoryManager.CoffeeCollected == false)
            {
                this.gameObject.SetActive(false);
                DialogueManager.tasksInBook = DialogueManager.tasksInBook.Replace("Larry needs me to find his kociihsaapowi\n", "I think I saw Larry's kociihsaapowi somewhere in his house\n");
                //Debug.Log("it should be updating tasksinbook now");
            }
            //coatHintAdded = true;
        }
        else if (item.id == 6) // gloves
        {
            Debug.Log("you entered the trigger for gloves");
            if (DialogueManager.talkedToMom == true && InventoryManager.GlovesCollected == false)
            {
                this.gameObject.SetActive(false);
                DialogueManager.tasksInBook = DialogueManager.tasksInBook.Replace("Mom needs me to find my alencihkana\n", "I think I saw the alencihkana on the counter\n");
                Debug.Log("it should be updating tasksinbook now");
            }
            //glovesHintAdded = true;
        }
        else if (item.id == 7) // coat
        {
            Debug.Log("You entered the trigger for the coat");
            if (DialogueManager.talkedToDad == true && InventoryManager.CoatCollected == false)
            {
                this.gameObject.SetActive(false);
                DialogueManager.tasksInBook = DialogueManager.tasksInBook.Replace("Dad needs me to find my keehpakiikinki naapinaakani.\n", "I think the plant is right by the keehpakiikinki naapinaakani\n");
                Debug.Log("it should be updating tasksinbook now");
            }
            //coatHintAdded = true;
        }
        else if (item.id == 9) // Chair
        {
            if (DialogueManager.talkedToMom2 == true && InventoryManager.ChairCollected == false)
            {
                this.gameObject.SetActive(false);
                DialogueManager.tasksInBook = DialogueManager.tasksInBook.Replace("Mom wants me to find a naahkiipioni\n", "There's a naahkiipioni in my house.\n");
                //Debug.Log("it should be updating tasksinbook now");
            }
            //coatHintAdded = true;
        }
        else if (item.id == 10) // Hammer
        {
            Debug.Log("You entered the trigger for the hammer");
            if (DialogueManager.talkedToDrew == true && InventoryManager.CoatCollected == false)
            {
                this.gameObject.SetActive(false);
                DialogueManager.tasksInBook = DialogueManager.tasksInBook.Replace("Drew needs me to find a pakantaakani\n", "I think the pakantaakani was somewhere in my house.\n");
                Debug.Log("it should be updating tasksinbook now");
            }
            //coatHintAdded = true;
        }
        else if (item.id == 11) // Keys
        {
            if (DialogueManager.talkedToBetsy == true && InventoryManager.KeysCollected == false)
            {
                this.gameObject.SetActive(false);
                DialogueManager.tasksInBook = DialogueManager.tasksInBook.Replace("Betsy needs me to find her paahpahaakana\n", "I think the paahpahaakana are in Drew's house on the counter\n");
                //Debug.Log("it should be updating tasksinbook now");
            }
            //coatHintAdded = true;
        }
        else if (item.id == 12) // Blanket
        {
            if (DialogueManager.talkedToSam == true && InventoryManager.BlanketCollected == false)
            {
                this.gameObject.SetActive(false);
                DialogueManager.tasksInBook = DialogueManager.tasksInBook.Replace("Sam wants me to find her a waapimotayi\n", "I think I saw a waapimotayi in Drew's house by the laundry\n");
                //Debug.Log("it should be updating tasksinbook now");
            }
            //coatHintAdded = true;
        }
        else if (item.id == 13 || item.id == 14) // Salt or Pepper
        {
            //Debug.Log("You entered the trigger for the salt");
            if (DialogueManager.talkedToTony == true && InventoryManager.SaltCollected == false || DialogueManager.talkedToTony && InventoryManager.PepperCollected == false)
            {
                this.gameObject.SetActive(false);
                DialogueManager.tasksInBook = DialogueManager.tasksInBook.Replace("Tony needs me to find his wiihkapaakani and wiihsakaakani\n", "I think the wiihkapaakani and wiihsakaakani were in Tony's kitchen.\n");
                Debug.Log("it should be updating tasksinbook now");
            }
            //coatHintAdded = true;
        }
        else if (item.id == 15) // Shoe
        {
            if (DialogueManager.talkedToSpot == true && InventoryManager.ShoeCollected == false)
            {
                this.gameObject.SetActive(false);
                DialogueManager.tasksInBook = DialogueManager.tasksInBook.Replace("Spot wants me to find a mahkisini\n", "I think I saw a mahkisini in Tony's house\n");
                //Debug.Log("it should be updating tasksinbook now");
            }
            //coatHintAdded = true;
        }
        else if (item.id == 17) // Corn
        {
            if (DialogueManager.talkedToCaroline == true && InventoryManager.CornCollected == false)
            {
                this.gameObject.SetActive(false);
                DialogueManager.tasksInBook = DialogueManager.tasksInBook.Replace("Caroline wants me to find some miincipi\n", "I think I saw some miincipi in Tony's house\n");
                //Debug.Log("it should be updating tasksinbook now");
            }
            //coatHintAdded = true;
        }
        else if (item.id == 18 || item.id == 19 || item.id == 20) // Plates, Forks, Spoons
        {
            if (DialogueManager.talkedToTony2 == true && InventoryManager.PlatesCollected == false || DialogueManager.talkedToTony2 == true && InventoryManager.ForksCollected == false || DialogueManager.talkedToTony2 == true && InventoryManager.SpoonsCollected == false)
            {
                this.gameObject.SetActive(false);
                DialogueManager.tasksInBook = DialogueManager.tasksInBook.Replace("Tony wants me to find some šinkilaakana, neewikoleekia, and kookaana\n", "kookaana, šinkilaakana, and neewikoleekia were in Tony's house\n");
                //Debug.Log("it should be updating tasksinbook now");
            }
            //coatHintAdded = true;
        }
        else if (item.id == 21) // Brush
        {
            if (DialogueManager.talkedToAngeline == true && InventoryManager.BrushCollected == false)
            {
                this.gameObject.SetActive(false);
                DialogueManager.tasksInBook = DialogueManager.tasksInBook.Replace("Angeline wants me to find her a piiwahaakani\n", "I think I saw a piiwahaakani in Judy's house\n");
                //Debug.Log("it should be updating tasksinbook now");
            }
            //coatHintAdded = true;
        }
        else if (item.id == 22) // Stick
        {
            if (DialogueManager.talkedToMarco == true && InventoryManager.StickCollected == false)
            {
                this.gameObject.SetActive(false);
                DialogueManager.tasksInBook = DialogueManager.tasksInBook.Replace("Marco wants me to find a pakitahaakani\n", "I think I saw a pakitahaakani in Judy's house\n");
                //Debug.Log("it should be updating tasksinbook now");
            }
            //coatHintAdded = true;
        }
        else if (item.id == 23 || item.id == 24) // Soap and Towel
        {
            if (DialogueManager.talkedToJudy == true && InventoryManager.SoapCollected == false || DialogueManager.talkedToJudy == true && InventoryManager.TowelCollected == false)
            {
                this.gameObject.SetActive(false);
                DialogueManager.tasksInBook = DialogueManager.tasksInBook.Replace("Judy wants me to find a waapahaakani and a kišiinkweehaakani\n", "I think I saw a waapahaakani and a kišiinkweehaakani in Judy's house\n");
                //Debug.Log("it should be updating tasksinbook now");
            }
            //coatHintAdded = true;
        }
        dm.tasks.text = DialogueManager.tasksInBook;
    }

    public void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("DrewHouseInterior"))
        {
            ih.transform.GetChild(0).gameObject.SetActive(false);
            ih.transform.GetChild(1).gameObject.SetActive(false);
            ih.transform.GetChild(2).gameObject.SetActive(false);
            ih.transform.GetChild(3).gameObject.SetActive(false);
            ih.transform.GetChild(4).gameObject.SetActive(true);
            ih.transform.GetChild(5).gameObject.SetActive(true);
            ih.transform.GetChild(6).gameObject.SetActive(true);
            ih.transform.GetChild(7).gameObject.SetActive(false);
            ih.transform.GetChild(8).gameObject.SetActive(false);
            ih.transform.GetChild(9).gameObject.SetActive(false);
            ih.transform.GetChild(10).gameObject.SetActive(false);
            ih.transform.GetChild(11).gameObject.SetActive(false);
            ih.transform.GetChild(12).gameObject.SetActive(false);
            ih.transform.GetChild(13).gameObject.SetActive(false);
            ih.transform.GetChild(14).gameObject.SetActive(false);
            ih.transform.GetChild(15).gameObject.SetActive(false);
            ih.transform.GetChild(16).gameObject.SetActive(false);
            ih.transform.GetChild(17).gameObject.SetActive(false);
            ih.transform.GetChild(18).gameObject.SetActive(false);
            ih.transform.GetChild(19).gameObject.SetActive(false);
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Interior_PlayerHouse"))
        {
            ih.transform.GetChild(0).gameObject.SetActive(true);
            ih.transform.GetChild(1).gameObject.SetActive(true);
            ih.transform.GetChild(2).gameObject.SetActive(true);
            ih.transform.GetChild(3).gameObject.SetActive(true);
            ih.transform.GetChild(4).gameObject.SetActive(false);
            ih.transform.GetChild(5).gameObject.SetActive(false);
            ih.transform.GetChild(6).gameObject.SetActive(false);
            ih.transform.GetChild(7).gameObject.SetActive(false);
            ih.transform.GetChild(8).gameObject.SetActive(false);
            ih.transform.GetChild(9).gameObject.SetActive(false);
            ih.transform.GetChild(10).gameObject.SetActive(false);
            ih.transform.GetChild(11).gameObject.SetActive(false);
            ih.transform.GetChild(12).gameObject.SetActive(false);
            ih.transform.GetChild(13).gameObject.SetActive(false);
            ih.transform.GetChild(14).gameObject.SetActive(false);
            ih.transform.GetChild(15).gameObject.SetActive(false);
            ih.transform.GetChild(16).gameObject.SetActive(false);
            ih.transform.GetChild(17).gameObject.SetActive(false);
            ih.transform.GetChild(18).gameObject.SetActive(false);
            ih.transform.GetChild(19).gameObject.SetActive(false);

        } else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("JudyHouseInterior"))
        {
            ih.transform.GetChild(0).gameObject.SetActive(false);
            ih.transform.GetChild(1).gameObject.SetActive(false);
            ih.transform.GetChild(2).gameObject.SetActive(false);
            ih.transform.GetChild(3).gameObject.SetActive(false);
            ih.transform.GetChild(4).gameObject.SetActive(false);
            ih.transform.GetChild(5).gameObject.SetActive(false);
            ih.transform.GetChild(6).gameObject.SetActive(false);
            ih.transform.GetChild(7).gameObject.SetActive(true);
            ih.transform.GetChild(8).gameObject.SetActive(true);
            ih.transform.GetChild(9).gameObject.SetActive(true);
            ih.transform.GetChild(10).gameObject.SetActive(true);
            ih.transform.GetChild(11).gameObject.SetActive(false);
            ih.transform.GetChild(12).gameObject.SetActive(false);
            ih.transform.GetChild(13).gameObject.SetActive(false);
            ih.transform.GetChild(14).gameObject.SetActive(false);
            ih.transform.GetChild(15).gameObject.SetActive(false);
            ih.transform.GetChild(16).gameObject.SetActive(false);
            ih.transform.GetChild(17).gameObject.SetActive(false);
            ih.transform.GetChild(18).gameObject.SetActive(false);
            ih.transform.GetChild(19).gameObject.SetActive(false);

        } else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("LarryHouseInterior"))
        {
            ih.transform.GetChild(0).gameObject.SetActive(false);
            ih.transform.GetChild(1).gameObject.SetActive(false);
            ih.transform.GetChild(2).gameObject.SetActive(false);
            ih.transform.GetChild(3).gameObject.SetActive(false);
            ih.transform.GetChild(4).gameObject.SetActive(false);
            ih.transform.GetChild(5).gameObject.SetActive(false);
            ih.transform.GetChild(6).gameObject.SetActive(false);
            ih.transform.GetChild(7).gameObject.SetActive(false);
            ih.transform.GetChild(8).gameObject.SetActive(false);
            ih.transform.GetChild(9).gameObject.SetActive(false);
            ih.transform.GetChild(10).gameObject.SetActive(false);
            ih.transform.GetChild(11).gameObject.SetActive(true);
            ih.transform.GetChild(12).gameObject.SetActive(false);
            ih.transform.GetChild(13).gameObject.SetActive(false);
            ih.transform.GetChild(14).gameObject.SetActive(false);
            ih.transform.GetChild(15).gameObject.SetActive(false);
            ih.transform.GetChild(16).gameObject.SetActive(false);
            ih.transform.GetChild(17).gameObject.SetActive(false);
            ih.transform.GetChild(18).gameObject.SetActive(false);
            ih.transform.GetChild(19).gameObject.SetActive(false);

        } else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("TonyHouseInterior"))
        {
            ih.transform.GetChild(0).gameObject.SetActive(false);
            ih.transform.GetChild(1).gameObject.SetActive(false);
            ih.transform.GetChild(2).gameObject.SetActive(false);
            ih.transform.GetChild(3).gameObject.SetActive(false);
            ih.transform.GetChild(4).gameObject.SetActive(false);
            ih.transform.GetChild(5).gameObject.SetActive(false);
            ih.transform.GetChild(6).gameObject.SetActive(false);
            ih.transform.GetChild(7).gameObject.SetActive(false);
            ih.transform.GetChild(8).gameObject.SetActive(false);
            ih.transform.GetChild(9).gameObject.SetActive(false);
            ih.transform.GetChild(10).gameObject.SetActive(false);
            ih.transform.GetChild(11).gameObject.SetActive(false);
            ih.transform.GetChild(12).gameObject.SetActive(true);
            ih.transform.GetChild(13).gameObject.SetActive(true);
            ih.transform.GetChild(14).gameObject.SetActive(true);
            ih.transform.GetChild(15).gameObject.SetActive(false);
            ih.transform.GetChild(16).gameObject.SetActive(true);
            ih.transform.GetChild(17).gameObject.SetActive(true);
            ih.transform.GetChild(18).gameObject.SetActive(true);
            ih.transform.GetChild(19).gameObject.SetActive(true);

        }
    }
}
