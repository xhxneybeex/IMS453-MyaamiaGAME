using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Playables;

public class InventoryManager : MonoBehaviour
{
    //OFFICIAL EXTERIOR IS TOWN_EXTERIOR

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject InventoryHUD;
    public GameObject Notif;
    public UI ui;

    public GameObject left;
    public GameObject right;
    public GameObject polaroidL;
    public GameObject polaroidR;
    //public TextMeshProUGUI MugText;
    public GameObject tasks;

    public GameObject itemJournal;
    //public Image MugSprite;

    //public TextMeshProUGUI GlovesText;
    //public Image GlovesSprite;

    //public TextMeshProUGUI CoatText;
    // public Image CoatSprite;

    // public GameObject PlayGloves;

    //public GameObject PlayCoat;

    //public GameObject gloveAud;

    //public GameObject coatAud;

    //public AudioSource gloves;
    //public AudioSource coat;

    public static InventoryManager Instance;

    public List<Item> Items = new List<Item>();

    public static int currentTwoPages = 1;

    public static bool CoffeeCollected = false;
    public static bool GlovesCollected = false;

    public static bool CoatCollected = false;


    //public InventoryItemController iic;

    public void Add(Item item)
    {
        Items.Add(item);
    }

    private void Awake()
    {
        checkForCollected();
        Instance = this;
        tasks.SetActive(false);
        SetUIItemsFalse();
    }

    /*public void OpenJournal()
     {
         Debug.Log("AAAA");
         if (!InventoryHUD.activeInHierarchy)
         {
             ItemsTab();
             InventoryHUD.SetActive(true);
             Debug.Log("inventory should be open :)");

             if (currentTwoPages == 1 && UI.journalActive == true)
             {
                 Debug.Log("should be showing gloves and/or coat rn");
                 GlovesPolaroid();
                 CoatPolaroid();
             }

             if (Notif.activeInHierarchy)
             {
                 Notif.gameObject.SetActive(false);
             }
         }
         else if (InventoryHUD.activeInHierarchy)
         {
             InventoryHUD.SetActive(false);
             Debug.Log("inventory should be closed :)");
         }
     } */
    public void OpenJournal()
    {
        Debug.Log("AAAA");
        if (!InventoryHUD.activeInHierarchy)
        {
            InventoryHUD.SetActive(true);
            Debug.Log("inventory should be open :)");

            if (Notif.activeInHierarchy)
            {
                Notif.gameObject.SetActive(false);
                Debug.Log("Notification icon dissappears when inventory opens.");
                TasksTab();
            }
        }

        else if (InventoryHUD.activeInHierarchy)
        {
            InventoryHUD.SetActive(false);
            if (Notif.activeInHierarchy)
            {
                Notif.gameObject.SetActive(false);
                Debug.Log("Notification icon should dissappear when inventory closes.");
            }
            Debug.Log("inventory should be closed :)");
        }

        else
        {
            ItemsTab();
            ActivateCorrectPage();
        }
    }



    void Start()
    {
        InventoryHUD.SetActive(false);
        ui = GetComponent<UI>();
    }

    // Update is called once per frame
    void Update()
    {
        //checkForCollected();

        if (UI.journalActive == true)
        {
            ActivateCorrectPage();
        }


        Debug.Log("two current pages are set: " + currentTwoPages);


    }

    public void TasksTab()
    {
        tasks.SetActive(true);
        Debug.Log("on tasks pages");
        polaroidL.SetActive(false);
        polaroidR.SetActive(false);
        left.SetActive(false);
        right.SetActive(false);
        SetUIItemsFalse();
    }


    public void SetUIItemsFalse()
    {
        itemJournal.transform.GetChild(0).gameObject.SetActive(false); //gloves entry
        itemJournal.transform.GetChild(1).gameObject.SetActive(false); //coat entry
        itemJournal.transform.GetChild(2).gameObject.SetActive(false); //coffee entry
        itemJournal.transform.GetChild(3).gameObject.SetActive(false); //keys entry
        itemJournal.transform.GetChild(4).gameObject.SetActive(false); //rug entry
        itemJournal.transform.GetChild(5).gameObject.SetActive(false); //salt entry
        itemJournal.transform.GetChild(6).gameObject.SetActive(false); //pepper entry
        itemJournal.transform.GetChild(7).gameObject.SetActive(false); //hairbrush entry

    }

    public void ItemsTab()
    {
        tasks.SetActive(false);
        checkForCollected();
        Debug.Log("on items pages");
        polaroidL.SetActive(true);
        polaroidR.SetActive(true);
        left.SetActive(true);
        right.SetActive(true);
        ActivateCorrectPage();
        // CoffeePolaroid();
    }


    void checkForCollected()
    {
        foreach (Item i in Items)
        {
            if (i.id == 5)
            {
                CoffeeCollected = true;
                Debug.Log("mug was collected");
            }

            if (i.id == 6)
            {
                GlovesCollected = true;
                Debug.Log("gloves were collected"); //it's running this when the coat is collected...?
            }

            if (i.id == 7)
            {
                CoatCollected = true;
                Debug.Log("coat was collected");
            }
        }
    }

    public void PlayGloveAudio()
    {
        itemJournal.transform.GetChild(0).gameObject.GetComponentInChildren<AudioSource>().Play();

        // PlayGloves.SetActive(true);
        // gloves.Play();
        Debug.Log("playing glove sound");
    }

    public void PlayCoatAudio()
    {
        itemJournal.transform.GetChild(1).gameObject.GetComponentInChildren<AudioSource>().Play();

        // coat.Play();
        Debug.Log("playing coat sound");
    }

    public void PlayCoffeeAudio()
    {
        itemJournal.transform.GetChild(2).gameObject.GetComponentInChildren<AudioSource>().Play();

        Debug.Log("playing coffee sound");
    }

    public void PlayKeysAudio()
    {
        itemJournal.transform.GetChild(3).gameObject.GetComponentInChildren<AudioSource>().Play();

        Debug.Log("playing keys sound");
    }

    public void PlayRugAudio()
    {
        itemJournal.transform.GetChild(4).gameObject.GetComponentInChildren<AudioSource>().Play();

        Debug.Log("playing rug sound");
    }

    public void PlaySaltAudio()
    {
        itemJournal.transform.GetChild(5).gameObject.GetComponentInChildren<AudioSource>().Play();

        Debug.Log("playing salt sound");
    }

    public void PlayPepperAudio()
    {
        itemJournal.transform.GetChild(6).gameObject.GetComponentInChildren<AudioSource>().Play();

        Debug.Log("playing pepper sound");
    }

    public void PlayHairAudio()
    {
        itemJournal.transform.GetChild(7).gameObject.GetComponentInChildren<AudioSource>().Play();

        Debug.Log("playing hair sound");
    }

    public void PreviousPage()
    {
        if (currentTwoPages > 1 && currentTwoPages < 11)
        {
            currentTwoPages--;
        }

        ActivateCorrectPage();
    }

    public void NextPage()
    {
        currentTwoPages++;
        if (currentTwoPages > 1 && currentTwoPages < 11)
        {
            ActivateCorrectPage();
        }
    }

    public void ActivateCorrectPage()
    {
        if (currentTwoPages == 1)
        {
            GlovesPolaroid();
            CoatPolaroid();
            CoffeeOff();
            KeysOff();
            RugOff();
            SaltOff();
            PepperOff();
            HairOff();
        }
        else if (currentTwoPages == 2)
        {
            GlovesOff();
            CoatOff();
            RugOff();
            SaltOff();
            CoffeePolaroid();
            KeysPolaroid();
            PepperOff();
            HairOff();
        }
        else if (currentTwoPages == 3)
        {
            RugPolaroid();
            SaltPolaroid();
            GlovesOff();
            CoatOff();
            CoffeeOff();
            KeysOff();
            PepperOff();
            HairOff();
        }
        else if (currentTwoPages == 4)
        {
            PepperPolaroid();
            HairPolaroid();
            GlovesOff();
            CoatOff();
            CoffeeOff();
            KeysOff();
            SaltOff();
            RugOff();
        }
        else
        {
            GlovesOff();
            CoatOff();
            CoffeeOff();
            KeysOff();
            SaltOff();
            RugOff();
            PepperOff();
            HairOff();
        }

    }

    public void GlovesPolaroid()
    {
        if (GlovesCollected == true)
        {
            itemJournal.transform.GetChild(0).gameObject.SetActive(true); //gloves entry
                                                                          //gloveAud.SetActive(true);
                                                                          //gloves.Stop();
        }
    }

    public void GlovesOff()
    {
        itemJournal.transform.GetChild(0).gameObject.SetActive(false); //gloves entry
    }

    public void CoatPolaroid()
    {
        if (CoatCollected == true)
        {
            itemJournal.transform.GetChild(1).gameObject.SetActive(true); //coat entry
                                                                          //coatAud.SetActive(true);
                                                                          //coat.Stop();

        }
    }

    public void CoatOff()
    {
        itemJournal.transform.GetChild(1).gameObject.SetActive(false); //coat entry

    }

    public void CoffeePolaroid()
    {
        //if (MugCollected == true)
        // {
        itemJournal.transform.GetChild(2).gameObject.SetActive(true); //coffee entry
                                                                      //coatAud.SetActive(true);
                                                                      //coat.Stop();

        // }
    }

    public void CoffeeOff()
    {
        itemJournal.transform.GetChild(2).gameObject.SetActive(false); //coffee entry

    }

    public void KeysPolaroid()
    {
        //if (MugCollected == true)
        // {
        itemJournal.transform.GetChild(3).gameObject.SetActive(true); //coffee entry
                                                                      //coatAud.SetActive(true);
                                                                      //coat.Stop();

        // }
    }

    public void KeysOff()
    {
        itemJournal.transform.GetChild(3).gameObject.SetActive(false); //coffee entry

    }

    public void RugPolaroid()
    {
        //if (MugCollected == true)
        // {
        itemJournal.transform.GetChild(4).gameObject.SetActive(true); //coffee entry
                                                                      //coatAud.SetActive(true);
                                                                      //coat.Stop();

        // }
    }

    public void RugOff()
    {
        itemJournal.transform.GetChild(4).gameObject.SetActive(false); //coffee entry

    }

    public void SaltPolaroid()
    {
        //if (MugCollected == true)
        // {
        itemJournal.transform.GetChild(5).gameObject.SetActive(true); //coffee entry
                                                                      //coatAud.SetActive(true);
                                                                      //coat.Stop();

        // }
    }

    public void SaltOff()
    {
        itemJournal.transform.GetChild(5).gameObject.SetActive(false); //coffee entry

    }

    public void PepperPolaroid()
    {
        //if (MugCollected == true)
        // {
        itemJournal.transform.GetChild(6).gameObject.SetActive(true); //coffee entry
                                                                      //coatAud.SetActive(true);
                                                                      //coat.Stop();

        // }
    }

    public void PepperOff()
    {
        itemJournal.transform.GetChild(6).gameObject.SetActive(false); //coffee entry

    }

    public void HairPolaroid()
    {
        //if (MugCollected == true)
        // {
        itemJournal.transform.GetChild(7).gameObject.SetActive(true); //coffee entry
                                                                      //coatAud.SetActive(true);
                                                                      //coat.Stop();

        // }
    }

    public void HairOff()
    {
        itemJournal.transform.GetChild(7).gameObject.SetActive(false); //coffee entry

    }
}

