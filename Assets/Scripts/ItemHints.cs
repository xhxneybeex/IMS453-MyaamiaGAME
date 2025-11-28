using UnityEngine;

public class ItemHints : MonoBehaviour
{
    public DialogueManager dm;
    public int glovesHintAdded = 0;


    public void Start()
    {
        Debug.Log("the name of the item controller is " + this.name);
    }
    public void OnTriggerEnter()
    {
        Debug.Log("you entered the trigger for gloves");
        if (this.name.Equals("GlovesTriggerArea") && glovesHintAdded ==  0)
        {
            glovesHintAdded = 1;
            dm.tasksInBook += "\n You walked by the gloves";
            Debug.Log("it should be updating tasksinbook now");
        }
    }

    public void Update()
    {
        
    }
}
