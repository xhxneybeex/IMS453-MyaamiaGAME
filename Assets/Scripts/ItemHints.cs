using UnityEngine;

public class ItemHints : MonoBehaviour
{
    public DialogueManager dm;
    public bool glovesHintAdded = false;
    public bool coatHintAdded = false;

    public Item item;


    public void Start()
    {
        Debug.Log("the name of the item controller is " + this.name);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("you entered a task update trigger");
        //if (this.name.Equals("GlovesTaskUpdateTrigger") && glovesHintAdded == 0)
        if (item.id == 6)
        {
            Debug.Log("you entered the trigger for gloves");
            if (dm.talkedToMom == true && InventoryManager.GlovesCollected == false)
            {
                this.gameObject.SetActive(false);
                //dm.tasksInBook += "\nYou walked by the alencihkana\n";
                dm.tasksInBook = dm.tasksInBook.Replace("Mom needs me to find my alencihkana\n", "I think I saw the alencihkana on the counter\n");
                Debug.Log("it should be updating tasksinbook now");
            }
            glovesHintAdded = true;
        } else if (item.id == 7)
        {
            Debug.Log("You entered the trigger for the coat");
            if (dm.talkedToDad == true && InventoryManager.CoatCollected == false)
            {
                this.gameObject.SetActive(false);
                //dm.tasksInBook += "\nYou walked by the keehpakiikinki naapinaakani\n";
                dm.tasksInBook = dm.tasksInBook.Replace("Dad needs me to find my keehpakiikinki naapinaakani.\n", "I think the plant is right by the keehpakiikinki naapinaakani\n");
                Debug.Log("it should be updating tasksinbook now");
            }
            coatHintAdded = true;
        } else if (item.id == 10) // Hammer
        {
            Debug.Log("You entered the trigger for the hammer");
            if (dm.talkedToDrew == true && InventoryManager.CoatCollected == false)
            {
                this.gameObject.SetActive(false);
                //dm.tasksInBook += "\nYou walked by the keehpakiikinki naapinaakani\n";
                dm.tasksInBook = dm.tasksInBook.Replace("Drew needs me to find a pakantaakani\n", "I think the pakantaakani was somewhere in my house.\n");
                Debug.Log("it should be updating tasksinbook now");
            }
            coatHintAdded = true;
        }
        dm.tasks.text = dm.tasksInBook;
    }

    public void Update()
    {
        
    }
}
