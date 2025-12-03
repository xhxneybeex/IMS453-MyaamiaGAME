using UnityEngine;

public class ItemHints : MonoBehaviour
{
    public DialogueManager dm;
    public int glovesHintAdded = 0;


    public void Start()
    {
        Debug.Log("the name of the item controller is " + this.name);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("you entered a task update trigger");
        if (this.name.Equals("GlovesTaskUpdateTrigger") && glovesHintAdded == 0)
        {
            Debug.Log("you entered the trigger for gloves");
            if (dm.talkedToMom == true)
            {
                dm.tasksInBook = dm.tasksInBook.Replace("mom needs me to find my alencihkana\n", "You walked by the alencihkana\n");
                Debug.Log("it should be updating tasksinbook now");
            }
            glovesHintAdded = 1;
        }
    }

    public void Update()
    {
        
    }
}
