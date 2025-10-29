using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private string[] myLines;
    [SerializeField] private GameObject dialogueUI;
    [SerializeField] private TMPro.TextMeshProUGUI dialogue;

    public bool interactionEnabled = false;
    private bool dialogueActive = false;
    public bool enterClicked = false;
    private int currentFlag = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogueUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactionEnabled == true)
        {
            Debug.Log("enter was clicked");
            enterClicked = true;
            StartDialogue("Larry");
        } else if (dialogueUI.activeInHierarchy == true && Input.GetKeyDown(KeyCode.E))
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
        Debug.Log("it just checked for e press");
        if (character.Equals("Larry")) //&& enterClicked == true
        {
            dialogueUI.SetActive(true);
        }
    }

}
