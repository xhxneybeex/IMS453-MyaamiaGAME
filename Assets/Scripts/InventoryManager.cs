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

    public GameObject itemCanvas;
    public static InventoryManager Instance;

    public List<Item> Items = new List<Item>();

    public static int currentTwoPages = 1;

    public static bool MugCollected = false;
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
        ui.transform.GetChild(0).gameObject.SetActive(false); //gloves entry
        ui.transform.GetChild(1).gameObject.SetActive(false); //coat entry
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
            else
            {
                ItemsTab();
                if (currentTwoPages == 1 && UI.journalActive == true)
                {
                    Debug.Log("should be showing gloves and/or coat rn");
                    GlovesPolaroid();
                    CoatPolaroid();
                }
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

        if (currentTwoPages == 1 && UI.journalActive == true)
        {
            Debug.Log("should be showing gloves and/or coat rn");
            GlovesPolaroid();
            CoatPolaroid();
        }


    }

    public void TasksTab()
    {
        tasks.SetActive(true);
        Debug.Log("on tasks pages");
        polaroidL.SetActive(false);
        polaroidR.SetActive(false);
        left.SetActive(false);
        right.SetActive(false);
        ui.transform.GetChild(0).gameObject.SetActive(false); //gloves entry
        ui.transform.GetChild(1).gameObject.SetActive(false); //coat entry
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
        GlovesPolaroid();
        CoatPolaroid();
        MugPolaroid();
    }


    void checkForCollected()
    {
        foreach (Item i in Items)
        {
            if (i.id == 5)
            {
                MugCollected = true;
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
        // PlayGloves.SetActive(true);
        // gloves.Play();
        Debug.Log("playing glove sound");
    }

    public void PlayCoatAudio()
    {
        // coat.Play();
        Debug.Log("playing coat sound");
    }

    public void PreviousPage()
    {
        if (currentTwoPages > 1 && currentTwoPages < 12)
        {
            currentTwoPages--;
            if (currentTwoPages == 1)
            {
                GlovesPolaroid();
                CoatPolaroid();
            }
            else
            {
                GlovesOff();
                CoatOff();
            }
        }
    }

    public void NextPage()
    {
        currentTwoPages++;
        if (currentTwoPages > 1 && currentTwoPages < 12)
        {
            if (currentTwoPages == 1)
            {
                GlovesPolaroid();
                CoatPolaroid();
            }
            else
            {
                GlovesOff();
                CoatOff();
            }
        }
    }

    public void GlovesPolaroid()
    {
        if (GlovesCollected == true)
        {
            ui.transform.GetChild(0).gameObject.SetActive(true); //gloves entry
            //gloveAud.SetActive(true);
            //gloves.Stop();
        }
    }

    public void GlovesOff()
    {
        ui.transform.GetChild(0).gameObject.SetActive(false); //gloves entry
    }

    public void CoatPolaroid()
    {
        if (CoatCollected == true)
        {
            ui.transform.GetChild(1).gameObject.SetActive(true); //coat entry
            //coatAud.SetActive(true);
            //coat.Stop();

        }
    }

    public void CoatOff()
    {
        ui.transform.GetChild(1).gameObject.SetActive(false); //coat entry

    }

    public void MugPolaroid()
    {
        if (MugCollected == true)
        {
            //MugText.gameObject.SetActive(true);
            //MugSprite.gameObject.SetActive(true);
            // PlayGloves.gameObject.SetActive(true);
        }
    }
}

