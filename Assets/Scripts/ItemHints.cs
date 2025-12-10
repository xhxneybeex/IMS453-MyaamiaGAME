using UnityEngine;

public class ItemHints : MonoBehaviour
{
    public DialogueManager dm;
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
        } else if (item.id == 7) // coat
        {
            Debug.Log("You entered the trigger for the coat");
            if (DialogueManager.talkedToDad == true && InventoryManager.CoatCollected == false)
            {
                this.gameObject.SetActive(false);
                DialogueManager.tasksInBook = DialogueManager.tasksInBook.Replace("Dad needs me to find my keehpakiikinki naapinaakani.\n", "I think the plant is right by the keehpakiikinki naapinaakani\n");
                Debug.Log("it should be updating tasksinbook now");
            }
            //coatHintAdded = true;
        } else if (item.id == 10) // Hammer
        {
            Debug.Log("You entered the trigger for the hammer");
            if (DialogueManager.talkedToDrew == true && InventoryManager.CoatCollected == false)
            {
                this.gameObject.SetActive(false);
                DialogueManager.tasksInBook = DialogueManager.tasksInBook.Replace("Drew needs me to find a pakantaakani\n", "I think the pakantaakani was somewhere in my house.\n");
                Debug.Log("it should be updating tasksinbook now");
            }
            //coatHintAdded = true;
        } else if (item.id == 11) // Keys
        {
            if (DialogueManager.talkedToBetsy == true && InventoryManager.KeysCollected == false)
            {
                this.gameObject.SetActive(false);
                DialogueManager.tasksInBook = DialogueManager.tasksInBook.Replace("Betsy needs me to find her paahpahaakana\n", "I think the paahpahaakana is in Drew's house\n");
                //Debug.Log("it should be updating tasksinbook now");
            }
            //coatHintAdded = true;
        } else if (item.id == 12) // Blanket
        {
            if (DialogueManager.talkedToSam == true && InventoryManager.BlanketCollected == false)
            {
                this.gameObject.SetActive(false);
                DialogueManager.tasksInBook = DialogueManager.tasksInBook.Replace("Sam wants me to find her a waapimotayi\n", "I think I saw a waapimotayi in Drew's house\n");
                //Debug.Log("it should be updating tasksinbook now");
            }
            //coatHintAdded = true;
        } else if (item.id == 13 || item.id == 14) // Salt or Pepper
        {
            //Debug.Log("You entered the trigger for the salt");
            if (DialogueManager.talkedToTony == true && InventoryManager.SaltCollected == false || DialogueManager.talkedToTony && InventoryManager.PepperCollected == false)
            {
                this.gameObject.SetActive(false);
                DialogueManager.tasksInBook = DialogueManager.tasksInBook.Replace("Tony needs me to find his wiihkapaakani and wiihsakaakani\n", "I think the wiihkapaakani and wiihsakaakani were in Tony's kitchen.\n");
                Debug.Log("it should be updating tasksinbook now");
            }
            //coatHintAdded = true;
        } else if (item.id == 21) // Brush
        {
            if (DialogueManager.talkedToAngeline == true && InventoryManager.BrushCollected == false)
            {
                this.gameObject.SetActive(false);
                DialogueManager.tasksInBook = DialogueManager.tasksInBook.Replace("Angeline wants me to find her a piiwahaakani\n", "I think I saw a piiwahaakani in Judy's house\n");
                //Debug.Log("it should be updating tasksinbook now");
            }
            //coatHintAdded = true;
        }
        dm.tasks.text = DialogueManager.tasksInBook;
    }

    public void Update()
    {
        
    }
}
